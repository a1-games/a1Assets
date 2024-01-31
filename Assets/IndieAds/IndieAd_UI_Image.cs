using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IndieAd_UI_Image : MonoBehaviour, IIndieAd
{
    [SerializeField] private AdResolutions resolution;

    [Header("Opens _target in a browser when the ad is clicked.\nIf unwanted, just leave empty. (Saves performance too)")]
    [SerializeField] private Button button;

    public AdResolutions Resolution { get => resolution; set => resolution = value; }

    public bool FetchLink { get => button != null ? true : false; set => FetchLink = value; }

    private Image image;

    public void SetTexture(Texture2D myTexture)
    {
        image.color = Color.white;
        image.sprite = Sprite.Create((Texture2D)myTexture, new Rect(0.0f, 0.0f, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
    }

    private void Awake()
    {
        image = GetComponent<Image>();

        a1_IndieAds.SubmitIndieAd(this);
    }

    public void SetURL(string url)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => { Application.OpenURL(url); });
    }
}
