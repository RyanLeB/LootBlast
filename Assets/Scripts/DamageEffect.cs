using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageEffect : MonoBehaviour
{
    public Image damageImage;
    public float fadeSpeed = 5f; 

    private void Start()
    {
        Color color = damageImage.color;
        
        color.a = 0f;
        damageImage.color = color;
    }

    public void ShowDamageEffect()
    {
        Color color = damageImage.color;
        
        color.a = 1f;
        damageImage.color = color;

        
        StartCoroutine(FadeDamageEffect());
    }

    public void HideDamageEffect()
    {
        damageImage.enabled = false;
    }

    private IEnumerator FadeDamageEffect()
    {
        while (damageImage.color.a > 0f)
        {
            Color color = damageImage.color;
            color.a -= fadeSpeed * Time.deltaTime;
            damageImage.color = color;

            yield return null;
        }
    }
}
