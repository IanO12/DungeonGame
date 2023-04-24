using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float health = 5.0f;
    GameObject player;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    AttackAnimation attack;
    bool isAttacking = false;
    bool isKnockedBack = false;
    Vector3 knockBackDir;
    Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attack = GetComponent<AttackAnimation>();
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<Stats>();
        RangeEnemyController ranger = GetComponent<RangeEnemyController>();
        if(ranger != null){
            lookRadius = 20f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = attack.attacking;

        float distance = Vector3.Distance(target.position, transform.position);    
        FaceTarget();
        if(distance <= stats.attackDistance){
            anim.SetBool("isMoving", false);
            attack.Attack();
        }   
        else{
            agent.SetDestination(target.position);
            anim.SetBool("isMoving", true);
        }
    }
    void FixedUpdate(){
        if(isKnockedBack){
            transform.position += knockBackDir * 0.1f;
        }
    }

    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void knockBack(GameObject go){
        if(!isKnockedBack){
            isKnockedBack = true;
            knockBackDir = -go.transform.forward;
            Invoke(nameof(resetKnockBack), 0.3f);
        }
    }

    void resetKnockBack(){
        isKnockedBack = false;
    }
}
