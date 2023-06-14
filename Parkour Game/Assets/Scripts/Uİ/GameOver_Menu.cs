using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Menu : MonoBehaviour
{
    public void Restart_btn()
    {
        SceneManager.LoadScene("Main");
    }
    public void MainMenu_btn()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit_btn()
    {
        Application.Quit();
    }
    
}
