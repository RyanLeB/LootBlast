using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreGainedText;
    public TMP_Text scoreText;
    private int score = 0;
    public TMP_Text ammoText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        UpdateScoreUI();
    }

    private void Update()
    {

    } 
       


        


    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
        scoreGainedText.text = "+" + value.ToString();
        StartCoroutine(FadeScoreGainedText());

    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();

    }


    IEnumerator FadeScoreGainedText()
    {
        
        Color color = scoreGainedText.color;
        color.a = 1f;
        scoreGainedText.color = color;

        
        yield return new WaitForSeconds(0.5f);

        
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime;
            scoreGainedText.color = color;
            yield return null;
        }

        
        color.a = 0f;
        scoreGainedText.color = color;
    }

}