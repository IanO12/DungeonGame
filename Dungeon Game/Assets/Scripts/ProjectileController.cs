using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 10f;
    }

    void OnCollisionEnter(Collision collision){
        Destroy(gameObject);
        GameObject go = collision.collider.gameObject;
        if(go.tag == "Player"){
            HandleHit.Hit(go);
            Debug.Log("HIT");
        }
    }
}
