using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_Level : MonoBehaviour
{
    public Level_Maneger lm;
    public bool enter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enter)
            {
                lm.player_enter = true;
            }
            else
            {
                lm.player_exit = true;
            }
        }
    }
}
