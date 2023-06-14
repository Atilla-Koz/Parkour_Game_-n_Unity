using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
   private bool �sGamePaused = false;

    public GameObject pauseMenu;

    public bool �sGameOver = false;

    public GameObject player, pistol;

    public AudioSource music;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !�sGameOver )
        {
            if (!�sGamePaused)
            {

                PauseGame();
            }
            else
            {
                Resume();
            }
        }
    }

   private void PauseGame()
    {
        //Set Time Scale
        Time.timeScale = 0;

        //Pause The Music
        music.Pause();

        //Diaseble PlayerMovement And Pistol
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeponControl>().enabled = false;

        //Set Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        


        //Pause Menu
        pauseMenu.SetActive(true);

        //Set Boolean
        �sGamePaused = true;
    }
    private void Resume()
    {
        //Set Time Scale
        Time.timeScale = 1;

        //Resume The Music
        music.UnPause();

        //Set Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;

        //Enable PlayerMovement And Pistol
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeponControl>().enabled = true;

        //Pause Menu
        pauseMenu.SetActive(false);

        //Set Boolean
        �sGamePaused = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
