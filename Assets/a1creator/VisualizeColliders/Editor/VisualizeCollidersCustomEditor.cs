using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System;

namespace a1creator
{


    [CustomEditor(typeof(VisualizeColliders))]
    public class VisualizeCollidersCustomEditor : EasyEditor
    {

        protected override Color _disabled { get; } = new Color(0.6f, 0.6f, 0.6f);

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var script = (VisualizeColliders)target;

            EditorGUILayout.HelpBox("Enable Gizmos in your Game view to use this asset. ", MessageType.Warning);

            GUILayout.Space(12);
            script._settings = (VisualizeColliders_Settings)EditorGUILayout.ObjectField("Settings", script._settings, typeof(VisualizeColliders_Settings), false);
            script._gameCam = (Camera)EditorGUILayout.ObjectField("Game Camera", script._gameCam, typeof(Camera), true);
            //EditorGUILayout.PropertyField(serializedObject.FindProperty("yourFieldName"));

            GUILayout.Space(12);
            EditorGUILayout.HelpBox("Loading thousands of colliders isn't good. If you have a very large and complex map, this will scan inside the selected radius only. It will also refresh to keep up if the center moves.\n\nIf false, all colliders in the scene will be shown.\n\nIt will never rescan if the center did not move.", MessageType.None);
            GUILayout.Space(8);
            FeatureToggle("Very Large Map", script.VeryLargeMap, (val) =>
            {
                script.VeryLargeMap = val;
                if (EditorApplication.isPlaying)
                    script.LoadAllColliders();
            });
            if (script.VeryLargeMap)
            {
                Rect rect = EditorGUILayout.GetControlRect();
                rect.height = 66;
                EditorGUI.DrawRect(rect, new Color(0.18f, 0.18f, 0.18f)); // Darker background

                GUILayout.Space(-16);

                script.ScanCenter = (Transform)EditorGUILayout.ObjectField(" Scan Center", script.ScanCenter, typeof(Transform), true);
                script.ScanRate = EditorGUILayout.FloatField(" Rescan Every X Seconds", script.ScanRate);
                script.ScanRadius = EditorGUILayout.FloatField(" Scan Radius", script.ScanRadius);

            }

            GUILayout.Space(12);
            string[] layerNames = UnityEditorInternal.InternalEditorUtility.layers;
            script.LayersToShow = EditorGUILayout.MaskField("Layers To Show:", script.LayersToShow, layerNames);


            GUILayout.Space(12);
            script.DrawColor = EditorGUILayout.ColorField("Gizmos Color:", script.DrawColor);

            GUILayout.Space(12);

            if (script._isShowing)
                GUI.color = script.DrawColor;

            if (EditorApplication.isPlaying && GUILayout.Button(script._isShowing ? "Stop Showing Colliders" : "Show All Colliders", GUILayout.Height(50)))
            {
                script.ShowAllColliders(!script._isShowing);
                if (script._isShowing)
                    Debug.Log("Is showing all colliders");
            }
            GUI.color = Color.white; // Reset to default


            // there should be a gizmo way too

            serializedObject.ApplyModifiedProperties();
        }
    }

}