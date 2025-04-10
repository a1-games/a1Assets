
using System.Collections;
using System.Generic.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.Events;


//[Serializable]
public struct AdResolution
{
    public int width;
    public int height;

    public AdResolution(int w, int h)
    {
        width = w; 
        height = h;
    }
}

[System.Serializable]
public struct FolderNames
{
    public string[] foldernames;

    public FolderNames(string[] foldernames)
    {
        this.foldernames = foldernames;
    }
}




public class a1_IndieAds : MonoBehaviour
{


    // Either try fastly first, then akamai
    // Fastly is better in europe and america, akamai has better global coverage
    // or:
    // Decide which links use which providers
    public enum AdImageProvider
    {
        fastly,
        akamai,
    }
    // https://noblesteedgames.com/blog/a-handy-guide-to-graphical-assets-on-your-steam-store-page/
    public enum AdImageName
    {
        // Small capsule
        capsule_184x69,
        capsule_231x87,
        // 331x155
        header
    
        // Big capsule
        capsule_616x353,
        capsule_767x433,

        // Big banner
        capsule_920x430 = 0,
        capsule_748x896 = 1,


        Landscape_460x215 = 2,
        Portrait_374x448 = 4,
        capsule_600x900 = 5,
    }

    // This doesnt work because appID has to be passed from the very top.
    // Use it as an example to do it correctly
    private readonly Dictionary<AdImageName, string> ImageLinks = new Dictionary<AdImageName, string>()
    {
        { AdImageName.capsule_184x69, GetImageLink(AdImageProvider.fastly, "appID", AdImageName.capsule_184x69) }
        { AdImageName.header, GetImageLink(AdImageProvider.akamai, "appID", AdImageName.header) }
    };

    private string GetImageLink(AdImageProvider provider, string appID, AdImageName imageName)
    {
        return $"shared.{provider}.steamstatic.com/store_item_assets/steam/apps/{appID}/{imageName}";
    }


    private AdResolution[] resolutions = new AdResolution[]
    {
        new AdResolution (320, 50),
        new AdResolution (231, 87),
        new AdResolution (460, 215),
        new AdResolution (616, 353),
        new AdResolution (374, 448),
        new AdResolution (600, 900),
    };


    private static List<IIndieAd> ads = new List<IIndieAd>();
    [Header("If you want the ads to refresh. <=0 means disabled")]
    [SerializeField] private float secondsBetweenAdRefresh = 0f;
    [Header("Write your game name to avoid it displaying ads for itself\nAll lowercase, no spaces. Example: \"spacevoyage\"")]
    [SerializeField] private string myGame = "gametitle";

    private Coroutine refreshRoutine;

    public static void SubmitIndieAd(IIndieAd ad)
    {
        ads.Add(ad);
    }

    private void OnDisable()
    {
        // remove all ad references when the scene closes so it doesnt duplicate on reload
        ads.Clear();

        if (refreshRoutine != null)
            StopCoroutine(refreshRoutine);
    }

    private void Start()
    {
        FetchAllAds();

        if (secondsBetweenAdRefresh > 0)
        {
            refreshRoutine = StartCoroutine(RefreshAdsRoutine());
        }
    }

    private IEnumerator RefreshAdsRoutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(secondsBetweenAdRefresh);
            FetchAllAds();
        }
    }

    private void FetchAllAds()
    {
        for (int i = 0; i < ads.Count; i++)
        {
            AdFetch(ads[i]);
        }
    }

    private async void AdFetch(IIndieAd ad)
    {
        string folder = await GetAdFolderAsync(myGame);
        //print(folder);

        StartCoroutine(SetSpriteTexture((tx) => ad.SetTexture(tx), resolutions[(int)ad.Resolution], folder));
        //print("Fetched ad and closed thread");

        if (ad.FetchLink)
            StartCoroutine(GetHref($"https://indieads.github.io/stnemesitrevda/{folder}/href", (x) => ad.SetURL(x)));
    }

    private async Task<string> GetAdFolderAsync(string mygame)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync("https://indieads.github.io/foldernames.json");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        var folders = JsonUtility.FromJson<FolderNames>(responseBody).foldernames;

        // UnityEngine.Random.Range() can only be used on the main thread, so we use System.Eandom()
        var rnd = new System.Random();
        var rndindex = rnd.Next(0, folders.Length);


        while (folders[rndindex] == mygame)
        {
            //print("foldername is not valid");
            rndindex = rnd.Next(0, folders.Length);
        }
        
            

        var selectedFolder = folders[rndindex];

        return selectedFolder;
    }

    // GetTexture() can only be called on main thread, so this has to be a coroutine
    private IEnumerator SetSpriteTexture(UnityAction<Texture2D> setTexture, AdResolution res, string folder)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture($"https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/{appid}/capsule_{res.width}x{res.height}.jpg");


        //print(www.uri);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            print(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            setTexture((Texture2D)myTexture);
        }
    }


    private IEnumerator GetHref(string fileURL, UnityAction<string> executeOnSuccess)
    {
        UnityWebRequest req = UnityWebRequest.Get(fileURL);

        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            print(req.error);
        }
        else
        {
            var adURL = req.downloadHandler.text;
            executeOnSuccess(adURL);
        }

    }

}



