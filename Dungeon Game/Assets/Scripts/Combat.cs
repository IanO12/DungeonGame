using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    EnemyStats stats;

    float attackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
