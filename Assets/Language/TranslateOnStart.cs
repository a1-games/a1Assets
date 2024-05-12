using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateOnStart : MonoBehaviour
{
    [SerializeField] private TMP_Text message_Text;
    [SerializeField] private Translation_SO translation;

    private void Start()
    {
        message_Text.text = translation[GlobalVariables.AppLanguage];
        if (LanguageManager.AskFor != null)
            LanguageManager.AskFor.onLanguageChanged.AddListener((lang) => { message_Text.text = translation[lang]; } );
    }
}
