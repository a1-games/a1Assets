using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace a1creator
{


    public partial class VisualizeColliders : MonoBehaviour
    {

        private void DrawSphereCollider(SphereCollider sphereCollider)
        {
            Vector3 center = sphereCollider.transform.position;
            float radius = sphereCollider.radius * sphereCollider.transform.lossyScale.x;

            // vertical divisions
            int latitudeCount = _settings.SphereEdges;
            // horizontal divisions
            int longitudeCount = _settings.SphereEdges;

            if (_settings.ReduceSphereEdgesByDistance)
            {
                float distFromLoadPoint = 0f;
                if (VeryLargeMap)
                    distFromLoadPoint = Vector3.Distance(ScanCenter.position, center);
                else
                {
                    if (_gameCam != null)
                        distFromLoadPoint = Vector3.Distance(_gameCam.transform.position, center);
                    else
                        distFromLoadPoint = Vector3.Distance(transform.position, center);
                }

                // For each 50 units, lose one edgepoint. Going negative is safe (will not draw anything).
                for (int i = 50; i < distFromLoadPoint; i++)
                {
                    latitudeCount--;
                    latitudeCount--;
                }
            }

            List<Vector3> vertices = new List<Vector3>();

            // Generate the vertices 
            for (int i = 0; i < latitudeCount; i++)
            {
                // Angle from top center to the next horizontal ring
                float latAngle = Mathf.PI * i / (latitudeCount - 1);
                // y position
                float y = Mathf.Cos(latAngle) * radius;
                // Radius of this circle on the vertical axis
                float latRadius = Mathf.Sin(latAngle) * radius;

                for (int j = 0; j < longitudeCount; j++)
                {
                    // Angle from forward to the next vertical ring
                    float lonAngle = 2 * Mathf.PI * j / longitudeCount;
                    float x = latRadius * Mathf.Cos(lonAngle);
                    float z = latRadius * Mathf.Sin(lonAngle);

                    vertices.Add(center + new Vector3(x, y, z));
                }
            }

            // Draw the edges to form triangles
            for (int i = 0; i < latitudeCount - 1; i++)
            {
                for (int j = 0; j < longitudeCount; j++)
                {
                    // Wrap around to the first longitude for each row
                    int nextJ = (j + 1) % longitudeCount;

                    int currentVertex = i * longitudeCount + j;
                    int nextRowVertex = (i + 1) * longitudeCount + j;
                    int nextRowNextVertex = (i + 1) * longitudeCount + nextJ;

                    if (_settings.SphereLines_Vertical)
                        Debug.DrawLine(vertices[currentVertex], vertices[nextRowVertex], DrawColor);
                    if (_settings.SphereLines_Diagonal)
                        Debug.DrawLine(vertices[currentVertex], vertices[nextRowNextVertex], DrawColor);
                    if (_settings.SphereLines_Horizontal)
                        Debug.DrawLine(vertices[nextRowVertex], vertices[nextRowNextVertex], DrawColor);
                }
            }
        }








        private void DrawBoxCollider(BoxCollider boxCollider)
        {
            Vector3 center = boxCollider.transform.position;
            Vector3 scale = boxCollider.transform.lossyScale;
            Quaternion rotation = boxCollider.transform.rotation;

            Vector3 halfExtents = boxCollider.size * 0.5f;

            Vector3[] corners = new Vector3[8]
            {
            new Vector3(-halfExtents.x, -halfExtents.y, -halfExtents.z),
            new Vector3(halfExtents.x, -halfExtents.y, -halfExtents.z),
            new Vector3(halfExtents.x, -halfExtents.y, halfExtents.z),
            new Vector3(-halfExtents.x, -halfExtents.y, halfExtents.z),
            new Vector3(-halfExtents.x, halfExtents.y, -halfExtents.z),
            new Vector3(halfExtents.x, halfExtents.y, -halfExtents.z),
            new Vector3(halfExtents.x, halfExtents.y, halfExtents.z),
            new Vector3(-halfExtents.x, halfExtents.y, halfExtents.z)
            };

            // Rotate the corners based on the collider's rotation and move them to the world space
            for (int i = 0; i < corners.Length; i++)
            {
                corners[i] = boxCollider.transform.TransformPoint(corners[i]);
            }

            Debug.DrawLine(corners[0], corners[1], DrawColor); // Bottom front
            Debug.DrawLine(corners[1], corners[2], DrawColor); // Bottom right
            Debug.DrawLine(corners[2], corners[3], DrawColor); // Bottom back
            Debug.DrawLine(corners[3], corners[0], DrawColor); // Bottom left

            Debug.DrawLine(corners[4], corners[5], DrawColor); // Top front
            Debug.DrawLine(corners[5], corners[6], DrawColor); // Top right
            Debug.DrawLine(corners[6], corners[7], DrawColor); // Top back
            Debug.DrawLine(corners[7], corners[4], DrawColor); // Top left

            Debug.DrawLine(corners[0], corners[4], DrawColor); // Front left
            Debug.DrawLine(corners[1], corners[5], DrawColor); // Front right
            Debug.DrawLine(corners[2], corners[6], DrawColor); // Back right
            Debug.DrawLine(corners[3], corners[7], DrawColor); // Back left
        }






    }
}