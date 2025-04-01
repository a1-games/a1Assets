using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace a1creator
{
    
#if UNITY_EDITOR
    [CustomEditor(typeof(NoBckgSS))]
    public class NoBckgSSEditor : Editor
    {
        [SerializeField] public SerializedProperty onScreenshotTakenEvent;

        private void OnEnable()
        {
            onScreenshotTakenEvent = serializedObject.FindProperty("onScreenshotTaken");
            EditorGUIUtility.labelWidth = 1;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var script = (NoBckgSS)target;

            // title
            EditorGUILayout.LabelField("Screenshot Settings:", EditorStyles.boldLabel);
            // indent everything under this title
            EditorGUI.indentLevel++;

            // default screenshot png name
            script.defaultScreenshotName = EditorGUILayout.TextField("Default Screenshot Name", script.defaultScreenshotName);

            // custom resolution options
            script.useCustomResolution = EditorGUILayout.ToggleLeft("Custom Resolution:", script.useCustomResolution);

            if (script.useCustomResolution)
            {
                EditorGUI.indentLevel++;
                script.resX = EditorGUILayout.IntField("Width:", script.resX, GUILayout.ExpandWidth(false));
                script.resY = EditorGUILayout.IntField("Height:", script.resY, GUILayout.ExpandWidth(false));
                EditorGUI.indentLevel--;
            }
            else
            {
                //EditorGUILayout.EndHorizontal();
                EditorGUILayout.HelpBox("Screenshots will use the screen resolution by default.", MessageType.Info);
            }

            // make space before the next subject
            EditorGUILayout.Separator();

            // remove indentation before new title
            EditorGUI.indentLevel--;


            if (GUILayout.Button("Take Screenshot (Only in playmode)", GUILayout.Height(50)))
            {
                script.TakeScreenshot();
            }

            EditorGUILayout.Separator();

            // hide devtools? + title
            script.hideDeveloperTools = EditorGUILayout.ToggleLeft("Extra options", script.hideDeveloperTools, EditorStyles.boldLabel);

            // return if true so we dont draw the rest
            if (!script.hideDeveloperTools) return;

            // a little space between
            EditorGUILayout.Separator();


            EditorGUILayout.LabelField("On Screenshot Taken Event:", EditorStyles.boldLabel);

            EditorGUILayout.HelpBox("Returns a Texture2D of the screenshot that was taken. You could for example use this to show a pop up of the taken screenshot.\nDrag your own script into the event here and your function will trigger every time the user takes a screenshot.", MessageType.Info);

            // a little space between
            EditorGUILayout.Separator();

            EditorGUILayout.PropertyField(onScreenshotTakenEvent, new GUIContent("OnScreenshotTakenEvent"));

            // a little space between
            EditorGUILayout.Separator();

            EditorGUILayout.HelpBox("The script uses the \"Assets/Resources/\" folder to load the screenshots. I would not advise changing its location.", MessageType.Warning);

            // a little space between
            EditorGUILayout.Separator();
            EditorGUI.indentLevel--;

            EditorGUILayout.LabelField("Access all screenshots:", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Reference the Screenshot script and access the function called \"GetAllScreenshots\". It returns a List<Texture2D> with all screenshots. Use \"GetAllScreenshotsAsArray\" for the same list as array.", MessageType.Info);


            serializedObject.ApplyModifiedProperties();
        }
    }



#endif
    public class NoBckgSS : MonoBehaviour
    {
        [SerializeField] public bool useCustomResolution = false;
        [SerializeField] public string defaultScreenshotName = "Screenshot";
        [SerializeField] public int resX = 0;
        [SerializeField] public int resY = 0;
        [SerializeField] public UnityEvent<Texture2D> onScreenshotTaken;
        // I advise against changing this but go ahead if you know what you're doing
        private string screenshotsFoldername = "Screenshots";

        // had to put this here bc unity is confusing but it is only related to the custom editor scipt, don't touch
        [SerializeField] public bool hideDeveloperTools = false;

        private int highestUnusedScreenshotNr = 0;

        public List<Texture2D> GetAllScreenshots()
        {
            // get all files in the folder as Object type
            var filesInScreenShotsFolder = Resources.LoadAll(screenshotsFoldername);
            List<Texture2D> screenshots = new List<Texture2D>();
            // go through all
            for (int i = 0; i < filesInScreenShotsFolder.Length; i++)
            {
                // if the file is a screenshot by name, add it to our list if it is a Texture2D
                if (filesInScreenShotsFolder[i].name.Contains(defaultScreenshotName))
                {
                    // try converting
                    var file = filesInScreenShotsFolder[i] as Texture2D;
                    // if successful, add to our list
                    if (file != null)
                        screenshots.Add(file);
                }
            }
            // return as array for better optional performance
            return screenshots;
        }
        public Texture2D[] GetAllScreenshotsAsArray()
        {
            var list = GetAllScreenshots();
            return list.ToArray();
        }


        public void TakeScreenshot()
        {
            StartCoroutine(EndOfFrameRoutine());
        }

        private IEnumerator EndOfFrameRoutine()
        {
            yield return new WaitForEndOfFrame();
            ProcessScreenshotTaken();
        }

        private void ProcessScreenshotTaken()
        {
            var path = Application.dataPath + "/Resources/" + screenshotsFoldername + "/";

            var texture = ScreenCapture.CaptureScreenshotAsTexture();
            // invoke the event and send out the screenshot as Texture2D
            onScreenshotTaken.Invoke(texture);

            // if a custom resolution is set, use that
            if (useCustomResolution && resX != 0 && resY != 0)
            {
                // For older unity versions, uncomment this and delete the other:
                texture.Reinitialize(resX, resY);
                //texture.Reinitialize(resX, resY);
            }

            // encode to bytes in png format
            var texturebytes = texture.EncodeToPNG();

            // create directory if it doesn't exist
            Directory.CreateDirectory(path);

            // if directory was found, save the image with a number corresponding to (the amount of screenshots in the folder + 1)
            File.WriteAllBytes(path + GetAvailableFileName() + ".png", texturebytes);

            // debug information if we are in unity editor
#if UNITY_EDITOR
            Debug.Log("Screenshot was saved at " + path);
            // force unity to reload screenshot folder, because it otherwise doesn't read screenshots that were taken in this session
            AssetDatabase.Refresh();
            //----
#endif
        }

        private string GetAvailableFileName()
        {
            // get all file names to compare
            var filesInScreenShotsFolder = Resources.LoadAll(screenshotsFoldername);
            var fileNames = new string[filesInScreenShotsFolder.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = filesInScreenShotsFolder[i].name;
            }
            Array.Sort(fileNames, new NumericOrderComparer());

            // iterate through all files from first to last
            for (int i = highestUnusedScreenshotNr; i < fileNames.Length; i++)
            {
                var name = fileNames[i];
                var expectedName = defaultScreenshotName + "_" + (i + 1);

                // if the expectedName isn't taken already, take it.
                if (name.ToLower() != expectedName.ToLower())
                {
                    highestUnusedScreenshotNr = i + 1;
                    return expectedName;
                }
            }
            // we expect not to reach the following code unless all screenshot names are taken:
            // in case we didn't find a usable expectedName, we know the highest unsaved is length + 1
            highestUnusedScreenshotNr = filesInScreenShotsFolder.Length + 1;
            return defaultScreenshotName + "_" + highestUnusedScreenshotNr;

        }

        // This is definitely stolen from somewhere but I forgot it. I would give credit if I knew! :(
        public class NumericOrderComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                var regex = new Regex("^(d+)");

                // run the regex on both strings
                var xRegexResult = regex.Match(x);
                var yRegexResult = regex.Match(y);

                // check if they are both numbers
                if (xRegexResult.Success && yRegexResult.Success)
                {
                    return int.Parse(xRegexResult.Groups[1].Value).CompareTo(int.Parse(yRegexResult.Groups[1].Value));
                }

                // otherwise return as string comparison
                return x.CompareTo(y);
            }
        }
    }

}