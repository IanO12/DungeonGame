using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            Spawn();
        }
    }

    void Spawn(){
        Instantiate(enemy, transform.position, transform.rotation);   
    }
}
