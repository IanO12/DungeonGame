using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    GameObject player;
    PowerUpEffect powerUpEffect;
    Stats playerStats;
    void Start(){
        player = GameObject.FindWithTag("Player");
        powerUpEffect = player.GetComponentInChildren<PowerUpEffect>();
        playerStats = player.GetComponent<Stats>();
    }
    public void IncreaseDamage(){
        playerStats.damage = 2;
        powerUpEffect.Activate();
        Invoke(nameof(resetPowerUp), 5f);
    }

    public void resetPowerUp(){
        playerStats.damage = 1;
        powerUpEffect.Deactivate();
    }

}
