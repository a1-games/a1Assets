using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace a1creator
{



    [CustomEditor(typeof(VisualizeColliders_Settings))]
    public class VisualizeCollidersSettingsCustomEditor : EasyEditor
    {

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var script = (VisualizeColliders_Settings)target;

            EditorGUILayout.LabelField("[ Settings ]", EditorStyles.boldLabel);

            EditorGUILayout.HelpBox(" Settings can be updated realtime.\n Values persist between playmode and editor. ", MessageType.Info);


            // --------------------------------------------------------------------------
            GUILayout.Space(12);
            FeatureToggle("Box Colliders", script.EnableDraw_Boxes, (val) =>
            {
                script.EnableDraw_Boxes = val;
            });


            // --------------------------------------------------------------------------
            GUILayout.Space(12);
            FeatureToggle("Sphere Colliders", script.EnableDraw_Spheres, (val) =>
            {
                script.EnableDraw_Spheres = val;
            });

            if (script.EnableDraw_Spheres)
            {
                script.SphereLines_Horizontal = EditorGUILayout.ToggleLeft("Draw Horizontal Lines", script.SphereLines_Horizontal);
                script.SphereLines_Vertical = EditorGUILayout.ToggleLeft("Draw Vertical Lines", script.SphereLines_Vertical);
                script.SphereLines_Diagonal = EditorGUILayout.ToggleLeft("Draw Diagonal Lines", script.SphereLines_Diagonal);

                EditorGUILayout.LabelField("Corners Per Axis", EditorStyles.boldLabel);
                script.SphereEdges = EditorGUILayout.IntSlider(script.SphereEdges, 3, 20);
                EditorGUILayout.HelpBox(" How many corners horizontally and vertically. 3 makes a three sided diamond. 6 makes a rugged ball. 10 makes a nice sphere. ", MessageType.None);
                script.ReduceSphereEdgesByDistance = EditorGUILayout.ToggleLeft("Reduce sphere edges by distance", script.ReduceSphereEdgesByDistance);
                if (script.ReduceSphereEdgesByDistance)
                    script.DistancePerSphereEdgeReduction = EditorGUILayout.FloatField(script.DistancePerSphereEdgeReduction);
            }




            // Reset to default - Button
            







            serializedObject.ApplyModifiedProperties();
        }
    }
}