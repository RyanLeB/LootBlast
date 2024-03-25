using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInEffect : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image image;
    [SerializeField] Image image2;
    [SerializeField] Image image3;
    [SerializeField] Image image4;

    [SerializeField] float fadeInTime = 2f;

    void Start()
    {
        
        Color buttonColor = button.image.color;
        button.image.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 0);

        Color imageColor = image.color; 
        image.color = new Color(imageColor.r, imageColor.g, imageColor.b, 0);

        Color imageColor2 = image2.color;
        image2.color = new Color(imageColor2.r, imageColor2.g, imageColor2.b, 0);

        Color imageColor3 = image3.color;
        image3.color = new Color(imageColor3.r, imageColor3.g, imageColor3.b, 0);

        Color imageColor4 = image4.color;
        image4.color = new Color(imageColor4.r, imageColor4.g, imageColor4.b, 0);

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInTime);

            Color buttonColor = button.image.color;
            button.image.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);

            Color imageColor = image.color;
            image.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);

            Color imageColor2 = image2.color;
            image2.color = new Color(imageColor2.r, imageColor2.g, imageColor2.b, alpha);

            Color imageColor3 = image3.color;
            image3.color = new Color(imageColor3.r, imageColor3.g, imageColor3.b, alpha);

            Color imageColor4 = image4.color;
            image4.color = new Color(imageColor4.r, imageColor4.g, imageColor4.b, alpha);

            yield return null;
        }
    }
}
