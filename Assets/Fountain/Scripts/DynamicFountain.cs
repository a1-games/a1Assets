using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFountain : MonoBehaviour
{
    [SerializeField] private Fountain[] ConnectedWaterSprays;
    [SerializeField] private float totalSprayForce = 50f;
    [Tooltip("This value controls how much of the excess spray power should be applied. 0 is no extra power, 1 is default, 2 is a lot of extra power.")]
    [SerializeField] private float sprayForceStabilizer = 0.8f;

    private float initialSprayForce = 0f;

    private void Awake()
    {
        initialSprayForce = totalSprayForce / ConnectedWaterSprays.Length;

        for (int i = 0; i < ConnectedWaterSprays.Length; i++)
        {
            ConnectedWaterSprays[i].fountainParent = this;
            ConnectedWaterSprays[i].SetSprayForce(initialSprayForce);
        }
    }

    public void SetForces()
    {
        var fountains = ConnectedWaterSprays.Length;
        var unblockedCount = 0;
        // get amount of unblocked fountains
        for (int i = 0; i < fountains; i++)
        {
            if (!ConnectedWaterSprays[i].blocked)
                unblockedCount++;
        }

        float factor = ((float)unblockedCount / (float)fountains) * sprayForceStabilizer;
        print("factor " + factor);

        float excessPower = totalSprayForce / (float)unblockedCount - initialSprayForce;
        print("excess power " + excessPower);

        float calculatedPower = initialSprayForce + excessPower * factor;

        // go through them
        for (int i = 0; i < fountains; i++)
        {
            var fountain = ConnectedWaterSprays[i];
            if (!fountain.blocked) // total force / unblocked count but we decrease it the higher the blocked count is
                fountain.SetSprayForce(calculatedPower);
            else
                fountain.SetSprayForce(0f);
        }
    }
}
