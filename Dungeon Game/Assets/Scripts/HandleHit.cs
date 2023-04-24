using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HandleHit : MonoBehaviour
{
    public static void Hit(GameObject go){
        PowerUp powerUp = go.GetComponentInChildren<PowerUp>();
        EnemyController enemyController = go.GetComponent<EnemyController>();
        Stats stats = go.GetComponent<Stats>();
        if(powerUp != null){
            powerUp.IncreaseDamage();
            Debug.Log("PowerUp");
            return;
        }
        if(stats != null){
            stats.health -= 1f;
            if(enemyController != null){
                enemyController.knockBack(go);
            }
            if(stats.health <= 0){
                if(go.tag == "Player"){
                    SceneManager.LoadScene("Game Over Screen");
                }else if(go.tag == "Enemy"){
                    EnemyManager.instance.enemiesLeft -= 1;
                    if(EnemyManager.instance.enemiesLeft <= 0){
                        SceneManager.LoadScene("Credit Screen");
                    }
                    Destroy(go);
                }
            }
        }
        Effects(go);
    }

    static void Effects(GameObject go){
        HitEffect[] hitEffects = go.GetComponentsInChildren<HitEffect>();
        if(hitEffects != null){
            for(int i = 0; i < hitEffects.Length; i++){
                hitEffects[i].hitEffect();
            }
        }
    }
}
