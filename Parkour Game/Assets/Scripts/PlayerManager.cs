using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool player_alive = true;
    public GameObject death_effect;

    public GameObject hand;
    public GameObject crosshiar;

    public GameObject gameovermenu;

    public Pause pause_m; 

 public void death()
    {
        if(player_alive)
        {
            //Set Boolean
            player_alive= false;

            //Disaeble Pause Menu
            pause_m.ÝsGameOver = true;


            //Particle Effect
            Instantiate(death_effect, transform.position, Quaternion.identity);
            //Disable Player 
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshiar.SetActive(false);

            //Curser Activate
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //Enable GameOver Menu
           gameovermenu.SetActive(true);

        }
    }
}
