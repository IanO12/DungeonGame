using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab;
    public float fireRange = 10f;
    public float fireInterval = 1f;
    private float lastFireTime;
    public Transform exitPoint;

    void Start(){
        GetComponent<NavMeshAgent>().stoppingDistance = 15f;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= fireRange)
        {
            if (Time.time - lastFireTime >= fireInterval)
            {
                GameObject projectile = Instantiate(projectilePrefab, exitPoint.position, exitPoint.rotation);
                lastFireTime = Time.time;
            }
        }
    }
}

