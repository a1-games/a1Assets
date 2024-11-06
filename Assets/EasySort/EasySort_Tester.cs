using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySort_Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        var thing = Casino.GetOneOfItems(2, 6, 7);

        Debug.Log(thing);

        var nextThing = Casino.GetOneOfWeightedItems(new WeightedItem<float>(23, 5555f), new WeightedItem<float>(93, 9999f)
            );

        Debug.Log(nextThing);

    }

}
