using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject gameplayUI;
    [SerializeField] FPSController player;
    [SerializeField] GunFire gunFire;
    [SerializeField] Animator gunAnim;
    [SerializeField] EnemyStateAI enemy;
    [SerializeField] Button resumeButton; 
    [SerializeField] Button quitButton;
    public static bool IsGamePaused { get; private set; }


    void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(QuitToMainMenu);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            PauseMenu.SetActive(true);
            gameplayUI.SetActive(false);
            player.enabled = false;
            IsGamePaused = true;
            gunFire.enabled = false;
            gunAnim.enabled = false;
            enemy.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            

        }

    }


   

    public void Resume()
    {
        PauseMenu.SetActive(false);
        gameplayUI.SetActive(true);
        player.enabled = true;
        IsGamePaused = false;
        gunFire.enabled = true;
        gunAnim.enabled = true;
        enemy.enabled = true;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        
    }
}