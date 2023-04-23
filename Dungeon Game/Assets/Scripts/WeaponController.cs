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

    Animator anim;
    public GameObject Sword;

    AttackAnimation attackAnimation;
    void Start(){
        // anim = Sword.GetComponent<Animator>();
        attackAnimation = GetComponentInParent<AttackAnimation>();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            attackAnimation.Attack();
        }
    }
}
