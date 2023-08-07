using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ScreenshotPopUp : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Image screenshotThumbnail;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        this.gameObject.SetActive(false);
    }

    public void OnScreenShotTaken(Texture2D tex)
    {

        screenshotThumbnail.sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        screenshotThumbnail.GetComponent<RectTransform>().sizeDelta = new Vector2(tex.width, tex.height) / 6;

        this.gameObject.SetActive(true);
        animator.SetTrigger("Enter");
    }

    public void ClosePopUp()
    {
        animator.SetTrigger("Exit");
    }
}
