using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace a1creator
{



    [CreateAssetMenu(fileName = "VisualizeColliders_Settings", menuName = "a1creator/VisualizeColliders_Settings")]
    public class VisualizeColliders_Settings : ScriptableObject
    {



        // Sphere Colliders
        [field: SerializeField] public bool EnableDraw_Spheres { get; set; } = true;

        [field: SerializeField] public bool SphereLines_Horizontal { get; set; } = true;
        [field: SerializeField] public bool SphereLines_Vertical { get; set; } = true;
        [field: SerializeField] public bool SphereLines_Diagonal { get; set; } = true;

        [field: SerializeField] public int SphereEdges { get; set; } = 10;
        [field: SerializeField] public float DistancePerSphereEdgeReduction { get; set; } = 50f;
        [field: SerializeField] public bool ReduceSphereEdgesByDistance { get; set; } = true;


        // Box Colliders
        [field: SerializeField] public bool EnableDraw_Boxes { get; set; } = true;


    }




}