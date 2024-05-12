using AYellowpaper.SerializedCollections;
using System;
using System.Collections.Generic;
using UnityEngine;





[Serializable]
public struct BigTranslationPair
{
    public SupportedLanguages language;
    [TextArea(6, 999)]
    public string bigString;
}

[CreateAssetMenu(fileName = "TranslatedText", menuName = "a1games/TranslatedText", order = 1)]
public class TranslatedText_SO : Translation_SO
{
    [SerializeField]
    private BigTranslationPair[] bigStringTranslations = new BigTranslationPair[]
    {
        new BigTranslationPair() { language = SupportedLanguages.Danish, bigString = "" },
        new BigTranslationPair() { language = SupportedLanguages.English, bigString = "" },
    };

    private string GetTranslation(SupportedLanguages lang)
    {
        for (int i = 0; i < bigStringTranslations.Length; i++)
        {
            if (bigStringTranslations[i].language == lang)
                return bigStringTranslations[i].bigString;
        }
        return "ERROR NO TRANSLATION FOUND";
    }

    public override string this[SupportedLanguages lang]
    {
        get { return GetTranslation(lang); }
    }
}
