using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class IndieAd_3D_Material : MonoBehaviour, IIndieAd
{
    [SerializeField] private AdResolutions resolution;

    public AdResolutions Resolution { get => resolution; set => resolution = value; }

    // Set to true if you implement your own click behaviour to SetURL()
    public bool FetchLink { get => false; set => FetchLink = value; }

    private MeshRenderer meshRenderer;

    public void SetTexture(Texture2D myTexture)
    {
        meshRenderer.materials[0].mainTexture = myTexture;
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        a1_IndieAds.SubmitIndieAd(this);
    }

    public void SetURL(string url)
    {
        // 3D ads aren't clickable by default. If you want them to be, you can write your own code here to open the webpage.
        //
        // if ( Insert click check here )
        // {
        //      Application.OpenURL(url);
        // }
    }
}
