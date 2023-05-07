using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonTransition : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu"); // load back into main menu
    }

    public void Game()
    {
        SceneManager.LoadScene("Battle Scene"); // load back into main menu
    }

    public void Quit()
    {
        Application.Quit();
    }
}
