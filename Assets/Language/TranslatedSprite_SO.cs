using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslatedSprite", menuName = "a1games/TranslatedSprite", order = 1)]
public class TranslatedSprite_SO : ScriptableObject
{
    [SerializeField] [SerializedDictionary]
    private SerializedDictionary<SupportedLanguages, Sprite> TranslatedMessages = new SerializedDictionary<SupportedLanguages, Sprite>()
    {
    };

    public Sprite this[SupportedLanguages lang]
    {
        get { return TranslatedMessages[lang]; }
    }
}
