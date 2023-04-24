using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform exitPoint;
    public AudioSource audio;
    public AudioClip clip;
    public void Shoot(){
        GameObject projectile = Instantiate(projectilePrefab, exitPoint.position, exitPoint.rotation);
        audio.PlayOneShot(clip);
    }
}

