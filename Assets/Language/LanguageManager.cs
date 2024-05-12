using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanguageManager : MonoBehaviour
{
    [SerializeField] private GameObject languageSelectPanel;

    public UnityEvent<SupportedLanguages> onLanguageChanged;

    private static LanguageManager instance;
    public static LanguageManager AskFor { get => instance; }


    private void Awake()
    {
        instance = this;

        LoadSelectedLanguage();
        languageSelectPanel.SetActive(false);
        // if we havent saved a language yet
        if (GameSave.GetString("AppLanguage") == "")
        {
            languageSelectPanel.SetActive(true);
        }
    }

    public void SetLanguageFromInspector(string language)
    {
        SaveSelectedLanguage((SupportedLanguages)Enum.Parse(typeof(SupportedLanguages), language));
        languageSelectPanel.SetActive(false);
    }

    public void SaveSelectedLanguage(SupportedLanguages selectedLang)
    {
        GameSave.SaveString("AppLanguage", selectedLang.ToString());
        GlobalVariables.AppLanguage = selectedLang;
        onLanguageChanged?.Invoke(selectedLang);
    }



    public void LoadSelectedLanguage()
    {
        var lang = GameSave.GetString("AppLanguage");
        var enumCount = Enum.GetValues(typeof(SupportedLanguages)).Length;

        for (int i = 0; i < enumCount; i++)
        {
            if (lang == ((SupportedLanguages)i).ToString())
            {
                GlobalVariables.AppLanguage = (SupportedLanguages)i;
                //Debug.Log("Selected the language: " + lang);
            }
        }
    }
}
