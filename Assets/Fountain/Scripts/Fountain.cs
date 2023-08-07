using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    [SerializeField] private string tagToCollideWith = "Player";
    [SerializeField] private ParticleSystem[] particles;
    public bool blocked { get; set; } = false;
    public DynamicFountain fountainParent { get; set; }
    private int collissionCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCollideWith))
        {
            collissionCount++;
            blocked = true;
            fountainParent.SetForces();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCollideWith))
        {
            collissionCount--;
            if (collissionCount <= 0)
            {
                blocked = false;
                fountainParent.SetForces();
            }
        }
    }

    public void SetSprayForce(float force)
    {
        for (int i = 0; i < particles.Length; i++)
        {
            var main = particles[i].main;
            main.startSpeed = force;
        }
    }

}
