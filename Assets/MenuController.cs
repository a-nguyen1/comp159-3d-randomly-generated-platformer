using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Opens Game Scene
    public void Game()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    //Opens Controls Scene
    public void Controls()
    {
        SceneManager.LoadScene("Scenes/ControlsScene");
    }

    //Opes Main Menu Scene
    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
