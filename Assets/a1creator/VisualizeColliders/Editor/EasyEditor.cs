using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace a1creator
{


    public class EasyEditor : Editor
    {
        protected virtual Color _enabled { get; } = new Color(0.5f, 0.5f, 0.5f);
        protected virtual Color _disabled { get; } = new Color(0.75f, 0.5f, 0.5f);

        protected virtual void OnEnable()
        {
            EditorGUIUtility.labelWidth = 1;
        }

        protected virtual void FeatureToggle(string title, bool toggleValue, Action<bool> setValue)
        {
            var enabled_string = toggleValue ? $"[Enabled] " : $"[Disabled] ";

            GUI.backgroundColor = toggleValue ? _enabled : _disabled;

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontStyle = FontStyle.Bold;
            buttonStyle.fixedHeight = 30f;

            if (GUILayout.Button(enabled_string + title, buttonStyle))
            {
                setValue(!toggleValue);
            }

            GUI.backgroundColor = Color.white;
        }
    }




}