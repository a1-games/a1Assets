using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySort_Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var strings = new List<string>()
        {
            "asd",
            "dsa",
            "XXXXXXXAAAA",
            "abcABC",
            "martin",
            "abcZebra",
        };

        print("---");
        for (int i = 0; i < strings.Count; i++)
        {
            print(strings[i]);
        }


        //var sortedstrings = EasySort.Sort(strings, StringSortBy.String_Length_Smallest_First);

        //print("---");
        //for (int i = 0; i < sortedstrings.Count; i++)
        //{
        //    print(sortedstrings[i]);
        //}

    }

}
