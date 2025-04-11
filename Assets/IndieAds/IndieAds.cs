using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.Networking;

#if UNITY_EDITOR
[CustomEditor(typeof(IndieAds))]
public class IndieAdsCustomEditor : Editor
{

    private void OnEnable()
    {
        EditorGUIUtility.labelWidth = 1;
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var script = (IndieAds)target;

        GUILayout.Space(12);
        EditorGUILayout.LabelField("Write the ID of this game to avoid it displaying ads for itself", EditorStyles.boldLabel);
        script._myGameID = EditorGUILayout.TextField("My Game ID:", script._myGameID);

        GUILayout.Space(12);
        EditorGUILayout.LabelField("If you want the ads to refresh. <=0 means disabled", EditorStyles.boldLabel);
        script._secondsBetweenAdRefresh = EditorGUILayout.FloatField("Ad Refresh Timer (Seconds):", script._secondsBetweenAdRefresh);

        GUILayout.Space(12);

        if (GUILayout.Button("Test My Game ID", GUILayout.Height(50)))
        {
            script.FetchAllAds(script._myGameID);
        }


        serializedObject.ApplyModifiedProperties();
    }
}
#endif


public interface IIndieAd
{
    public void SetTexture(Texture2D texture);
    public void SetURL(string url);
    public AdResolutions Resolution { get; set; }
    public bool FetchLink { get; set; }
}

// https://noblesteedgames.com/blog/a-handy-guide-to-graphical-assets-on-your-steam-store-page/
public enum AdResolutions
{
    //Banner_320x50,// Standard mobile banner size
    Landscape_184x69,
    Landscape_231x87,
    Landscape_331x155,
    //Landscape_460x215,
    Landscape_616x353,
    Landscape_1920x620,
    Landscape_1920x620_Blurred,
    //Portrait_374x448,
    Portrait_600x900,
    Logo_640x360,// Height varies
}

public class IndieAds : MonoBehaviour
{


    [SerializeField] internal string _myGameID = "2101690";
    [SerializeField] internal float _secondsBetweenAdRefresh = 0f;


    private static List<IIndieAd> Ads { get; set; } = new List<IIndieAd>();

    public static void SubmitIndieAd(IIndieAd ad)
    {
        Ads.Add(ad);
    }

    private static List<FakeKeyValPair> AppIDS { get; set; } = new List<FakeKeyValPair>();



    private Coroutine RefreshRoutine { get; set; }
    private System.Random Rnd { get; set; }

    private async void Awake()
    {
        Rnd = new System.Random();

        await GetRandomAppIDAsync();

        FetchAllAds();

        if (_secondsBetweenAdRefresh > 0)
            RefreshRoutine = StartCoroutine(RefreshAdsRoutine());
    }

    private void OnDisable()
    {
        // remove all ad references when the scene closes so it doesnt duplicate on reload
        Ads.Clear();

        if (RefreshRoutine != null)
            StopCoroutine(RefreshRoutine);
    }


    private IEnumerator RefreshAdsRoutine()
    {
        // this needs to be awaited before the first fetchallads call
        while (true)
        {
            yield return new WaitForSecondsRealtime(_secondsBetweenAdRefresh);
            FetchAllAds();
        }
    }
    internal void FetchAllAds(string forcedAppID = "-1")
    {
        for (int i = 0; i < Ads.Count; i++)
        {
            AdFetch(Ads[i], forcedAppID);
        }
    }


    // Only used to parse json file
    [System.Serializable]
    public struct FakeKeyValPair
    {
        public string Title;
        public string ID;

        public FakeKeyValPair(string Title, string ID)
        {
            this.Title = Title;
            this.ID = ID;
        }
    }
    [System.Serializable]
    public struct AppIDsStruct
    {
        public FakeKeyValPair[] IDs;

        public AppIDsStruct(FakeKeyValPair[] IDs)
        {
            this.IDs = IDs;
        }
    }
    private async Task GetRandomAppIDAsync()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync("https://indieads.github.io/appIDs.json");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        var jsonResponse = JsonUtility.FromJson<AppIDsStruct>(responseBody);

        foreach (var item in jsonResponse.IDs)
        {
            AppIDS.Add(item);
        }
    }



    private async void AdFetch(IIndieAd ad, string forcedAppID = "-1")
    {
        string appID = AppIDS[Rnd.Next(0, AppIDS.Count)].ID;
        // If no internet connection, default to spacevoyage.
        // You can put your own app id here, idc.
        if (appID == null)
            appID = "2101690";

        if (forcedAppID != "-1")
            appID = forcedAppID;

        StartCoroutine(SetSpriteTexture((tx) => ad.SetTexture(tx), ad.Resolution, appID));
        //print("Fetched ad and closed thread");

        if (ad.FetchLink)
            ad.SetURL($"https://store.steampowered.com/app/{appID}");
    }


    // GetTexture() can only be called on main thread, so this has to be a coroutine
    private IEnumerator SetSpriteTexture(UnityAction<Texture2D> setTexture, AdResolutions res, string appID)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(IndieAds_External.GetImageLink(appID, res));

        //print(www.uri);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogWarning(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            setTexture((Texture2D)myTexture);
        }
    }

}
