using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeGem_Effect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.IncreaseHealthPercent();
        }
    }
}
