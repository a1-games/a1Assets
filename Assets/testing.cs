using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{


    private void Start()
    {

        for (int i = 0; i < 100; i++)
        {
            var thing = Casino.GetOneOfWeightedItems(new WeightedItem<string>(88, "88"), new WeightedItem<string>(12, "12"));

            switch (thing == "88")
            {
                case true:
                    Debug.LogError("true");
                    break;
                default:
                    Debug.LogWarning("false");
                    break;
            }
        }

    }
}
