using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslatedTitle", menuName = "a1games/TranslatedTitle", order = 1)]
public class TranslatedTitle_SO : Translation_SO
{
    [SerializeField] [SerializedDictionary]
    private SerializedDictionary<SupportedLanguages, string> TranslatedMessages = new SerializedDictionary<SupportedLanguages, string>()
    {
        { SupportedLanguages.Danish, "" },
        { SupportedLanguages.English, "" },
    };

    public override string this[SupportedLanguages lang]
    {
        get { return TranslatedMessages[lang]; }
    }
}
