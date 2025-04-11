
using System.Collections.Generic;
using UnityEngine;

public class IndieAds_External : MonoBehaviour
{
    // Working test ID: 2101690


    public enum ImgFileType
    {
        png,
        jpg,
    }

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
        header,// 331x155

        // Big capsule
        capsule_616x353,

        // Banner
        library_600x900,

        // Header
        library_hero, // 1920x620
        library_hero_blur, // 1920x620

        // Logo
        logo, // 640x360, height varies

        // cant find:
        //capsule_767x433,
        //capsule_920x430,
        //capsule_748x896,
        //Landscape_460x215,
        //Portrait_374x448,
    }



    private static Dictionary<AdResolutions, AdImageName> ImageNames { get; } = new Dictionary<AdResolutions, AdImageName>()
    {
        { AdResolutions.Landscape_184x69, AdImageName.capsule_184x69 },
        { AdResolutions.Landscape_231x87, AdImageName.capsule_231x87 },
        { AdResolutions.Landscape_331x155, AdImageName.header },
        { AdResolutions.Landscape_616x353, AdImageName.capsule_616x353 },
        { AdResolutions.Landscape_1920x620, AdImageName.library_hero },
        { AdResolutions.Landscape_1920x620_Blurred, AdImageName.library_hero_blur },
        { AdResolutions.Portrait_600x900, AdImageName.library_600x900 },
        { AdResolutions.Logo_640x360, AdImageName.logo },
    };

    private static Dictionary<AdResolutions, ImgFileType> ImgFileTypes { get; } = new Dictionary<AdResolutions, ImgFileType>()
    {
        { AdResolutions.Landscape_184x69, ImgFileType.jpg },
        { AdResolutions.Landscape_231x87, ImgFileType.jpg },
        { AdResolutions.Landscape_331x155, ImgFileType.jpg },
        { AdResolutions.Landscape_616x353, ImgFileType.jpg },
        { AdResolutions.Landscape_1920x620, ImgFileType.jpg },
        { AdResolutions.Landscape_1920x620_Blurred, ImgFileType.jpg },
        { AdResolutions.Portrait_600x900, ImgFileType.jpg },
        { AdResolutions.Logo_640x360, ImgFileType.png },
    };


    private static string GetImageLink(AdImageProvider provider, string appID, AdImageName imageName, ImgFileType fileType)
    {
        return $"shared.{provider}.steamstatic.com/store_item_assets/steam/apps/{appID}/{imageName}.{fileType}";
    }

    public static string GetImageLink(string appID, AdResolutions size, AdImageProvider provider = AdImageProvider.fastly)
    {
        return GetImageLink(provider, appID, ImageNames[size], ImgFileTypes[size]);
    }




}
