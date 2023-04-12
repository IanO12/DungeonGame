using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float range = 1f;
    public float attackCooldown = 0.4f;
    public float attackSpeed = 1f;
    public float damage = 1f;
    public LayerMask attackLayer;

    public bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    Animator anim;
    public GameObject Sword;

    void Start(){
        anim = Sword.GetComponent<Animator>();
    }

    public void Attack(){
        if(!readyToAttack || attacking){
            return;
        }
        readyToAttack = false;
        attacking = true;
        anim.SetTrigger("Attack");
        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(attackRaycast), attackCooldown);
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void attackRaycast()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hit,range, attackLayer))
        {
            Debug.Log("HIT");
            Hit(hit.collider.gameObject);
        }
    }

    void Hit(GameObject go){
        go.GetComponent<EnemyController>().takeDamage(damage);
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }
    }

    

    // public GameObject Sword;
    // public bool attacking;
    // public AnimatorStateInfo stateInfo;
    // Animator anim;
    // void Start(){
    //     anim = Sword.GetComponent<Animator>();
    // }

    // void Update(){
    //     stateInfo = anim.GetCurrentAnimatorStateInfo(0);
    //     BoxCollider swordCollider = Sword.GetComponent<BoxCollider>();

    //     if(Input.GetMouseButtonDown(0)){
    //         SwordAttack();
    //     }
    //     if(attacking){
    //         swordCollider.enabled = true;
    //     }
    //     else{
    //         swordCollider.enabled = false;
    //     }
    // }

    // public void SwordAttack(){
    //     anim.SetTrigger("Attack");
    //     attacking = true;
    //     StartCoroutine(ResetAttack());
    // }

    // IEnumerator ResetAttack(){
    //     yield return new WaitForSeconds(1.0f);
    //     attacking = false;
    // }
}
