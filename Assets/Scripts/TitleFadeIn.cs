using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TitleFadeIn : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] float fadeInTime = 2f;

    void Start()
    {
        
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 0);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInTime);
            titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, alpha);
            yield return null;
        }
    }
}