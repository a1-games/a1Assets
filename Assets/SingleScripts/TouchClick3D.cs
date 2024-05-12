using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchClick3D : MonoBehaviour
{

    [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private UnityEvent<RaycastHit> on3DObjectClicked;

    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f, clickableLayer))
            {
                // object was clicked
                on3DObjectClicked.Invoke(hit);
            }
        }
    }
}
