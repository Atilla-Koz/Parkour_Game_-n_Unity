using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_scripts : MonoBehaviour
{
    public void play_btn()
    {
        SceneManager.LoadScene("Main");
    }

    public void Exit_btn()
    {
        Application.Quit();
    }


}
