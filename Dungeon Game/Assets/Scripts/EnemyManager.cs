using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    void Awake(){
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int enemiesLeft = 8;
}
