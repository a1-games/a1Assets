
using System;
using System.Collections;
using System.Reflection;
using System.Security;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace a1creator
{


    public partial class VisualizeColliders : MonoBehaviour
    {

        // --- Editor ---
        [field: SerializeField] public VisualizeColliders_Settings _settings { get; set; }
        [field: SerializeField] public Camera _gameCam { get; set; }

        [SerializeField] public LayerMask LayersToShow = ~0; // Everything

        [SerializeField] public Color DrawColor { get; set; } = Color.blue;

        [field: SerializeField] public bool VeryLargeMap { get; set; } = false;
        [field: SerializeField] public Transform ScanCenter { get; set; }
        [field: SerializeField] public float ScanRadius { get; set; } = 30f;
        [field: SerializeField] public float ScanRate { get; set; } = 3f;

        // --- Private ---

        // test large map changed runtime does something?

        private Coroutine _rescanRoutine;
        private Vector3 _scanCenter_LastPos;
        private float _rescanTimer = 0f;
        private bool _canRescan = true;

        [SerializeField] public bool _isShowing = false;

        private Collider[] _cachedColliders;

        // --- Setup ---

        internal void Reset()
        {
            LayersToShow = ~0;
            DrawColor = Color.blue;
            _isShowing = false;
        }

        private void Awake()
        {
            if (VeryLargeMap)
            {
                if (ScanCenter == null)
                {
                    Debug.LogWarning("ScanCenter is not assigned.");
                    ScanCenter = transform;
                }
            }

            // Do Last
            LoadAllColliders();
        }

        private void Update()
        {
            if (VeryLargeMap && _canRescan)
            {
                _rescanTimer += Time.deltaTime;
                if (_rescanTimer >= ScanRate)
                {
                    _canRescan = false;
                    _rescanTimer = 0f;
                    LoadAllColliders();
                }
            }
            // TODO: Debug.DrawRay can be set to draw every 2 seconds instead of every frame. This could save immense performance.
            DrawAllColliders();
        }

        private void OnDisable()
        {
            if (_rescanRoutine != null)
                StopCoroutine(_rescanRoutine);
        }

        // --- Callable ---

        public void ShowAllColliders(bool visible)
        {
            _isShowing = visible;
            if (!visible)
                StopCoroutine(_rescanRoutine);
        }

        // --- Logic ---

        public void LoadAllColliders()
        {
            if (!VeryLargeMap)
            {
                _cachedColliders = FindObjectsOfType<Collider>();
                print(_cachedColliders.Length);
            }
            else
            {
                // Force reload once
                _cachedColliders = Physics.OverlapSphere(ScanCenter.position, ScanRadius);
                if (_rescanRoutine != null)
                    StopCoroutine(_rescanRoutine);
                _rescanRoutine = StartCoroutine(RescanRoutine());
            }
        }

        private IEnumerator RescanRoutine()
        {
            while (true)
            {
                if (_scanCenter_LastPos != ScanCenter.position)
                {
                    _scanCenter_LastPos = ScanCenter.position;
                    _cachedColliders = Physics.OverlapSphere(ScanCenter.position, ScanRadius);
                    break;
                }
                yield return new WaitForSeconds(1f);
            }
            _canRescan = true;
        }

        private void DrawAllColliders()
        {
            if (!_isShowing) return;

            foreach (Collider collider in _cachedColliders)
            {
                if (collider == null) continue;

                if (_settings.EnableDraw_Spheres && collider is SphereCollider)
                {
                    DrawSphereCollider((SphereCollider)collider);
                }

                if (_settings.EnableDraw_Boxes && collider is BoxCollider)
                {
                    DrawBoxCollider((BoxCollider)collider);
                }
            }

        }


    }
}


