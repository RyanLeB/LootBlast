using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    
    
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        
        
    }
    
   

    public void QuitGame()
    {
        Application.Quit();
    }
}
