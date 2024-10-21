using AYellowpaper.SerializedCollections;
using UnityEngine;

public abstract class Translation_SO : ScriptableObject
{
    public abstract string this[SupportedLanguages lang]
    {
        get;
    }
}
