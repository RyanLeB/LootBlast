using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameplay;
    public GameObject paused;
    public GameObject options;
    public GameObject gameWin;
    public GameObject gameOver;

    public void UIMainMenu()
    {
        mainMenu.SetActive(true);
        gameplay.SetActive(false);
        paused.SetActive(false);
        options.SetActive(false);
        gameWin.SetActive(false);
        gameOver.SetActive(false);
    }

    public void UIGameplay()
    {
        mainMenu.SetActive(false);
        gameplay.SetActive(true);
        paused.SetActive(false);
        options.SetActive(false);
        gameWin.SetActive(false);
        gameOver.SetActive(false);
    }

    public void UIpause()
    {
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        paused.SetActive(true);
        options.SetActive(false);
        gameWin.SetActive(false);
        gameOver.SetActive(false);
    }

    public void UIoptions()
    {
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        paused.SetActive(false);
        options.SetActive(true);
        gameWin.SetActive(false);
        gameOver.SetActive(false);
    }

    public void UIGameWin()
    {
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        paused.SetActive(false);
        options.SetActive(false);
        gameWin.SetActive(true);
        gameOver.SetActive(false);
    }

    public void UIGameOver()
    {
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        paused.SetActive(false);
        options.SetActive(false);
        gameWin.SetActive(false);
        gameOver.SetActive(true);
    }

}
