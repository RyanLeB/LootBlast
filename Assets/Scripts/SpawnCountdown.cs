using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnCountdown : MonoBehaviour
{
    public FPSController playerScript;
    public GunFire gunControl;
    public TMP_Text ammoText;
    public TMP_Text healthText;
    public TMP_Text scoreText;
    public Image reticle;
    public AudioSource walkingSound;
    public AudioSource runningSound;
    public Animator gunAnim;
    public MeshRenderer gunRender;
    public Light flashLight;
   
    public float countdownTime = 22.5f;

    void Awake()
    {
        StartCoroutine(StartCountdown(countdownTime));
    }

    private IEnumerator StartCountdown(float countdownValue)
    {
        
        playerScript.enabled = false;
        gunControl.enabled = false;
        gunRender.enabled = false;
        walkingSound.enabled = false;
        runningSound.enabled = false;
        flashLight.enabled = false;
        gunAnim.enabled = false;
        healthText.enabled = false;
        scoreText.enabled = false;
        reticle.enabled = false;
        yield return new WaitForSeconds(countdownValue);
        playerScript.enabled = true;
        gunControl.enabled = true;
        gunRender.enabled = true;
        walkingSound.enabled = true;
        flashLight.enabled = true;
        runningSound.enabled = true;
        gunAnim.enabled = true;
        healthText.enabled = true;
        scoreText.enabled = true;
        reticle.enabled = true;

    }
}