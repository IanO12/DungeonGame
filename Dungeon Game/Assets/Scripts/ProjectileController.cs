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
    }
}
