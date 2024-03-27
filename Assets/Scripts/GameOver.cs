using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] FPSController player;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GunFire gunFire;
    [SerializeField] Animator gunAnim;
    

    public void GameOverSequence()
    {
        
        player.enabled = false;
        gunFire.enabled = false;
        gunAnim.enabled = false;
        

        gameOverUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        Time.timeScale = 0f;

        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        
    }
}
