using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float range = 1f;
    public float attackCooldown = 10f;
    public float attackSpeed = 10f;
    public float damage = 1f;
    public LayerMask attackLayer;

    public bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    Ray[] rays = new Ray[10];

    public Animator anim;
    public GameObject Sword;

    AttackAnimation attackAnimation;
    BoxCollider shieldCollider;
    AudioSource audio;
    public AudioClip swordSwing;
    void Start(){
        attackAnimation = GetComponentInParent<AttackAnimation>();
        audio = GetComponent<AudioSource>();
        shieldCollider = GameObject.FindWithTag("Shield").GetComponent<BoxCollider>();
    }

    void Update(){
        if(Input.GetMouseButtonDown(1)){
            if(!attackAnimation.attacking){
                audio.PlayOneShot(swordSwing);
            }
            if(!anim.GetBool("isBlocking")){
                attackAnimation.Attack();
            }
        }
        if(Input.GetMouseButtonDown(0)){
            shieldCollider.enabled = true;
            anim.SetBool("isBlocking", true);
        }
        else if(Input.GetMouseButtonUp(0)){
            shieldCollider.enabled = false;
            anim.SetBool("isBlocking", false);
        } 
        
    }
}
