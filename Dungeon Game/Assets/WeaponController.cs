using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            SwordAttack();
        }
    }
    public void SwordAttack(){
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
    }
}
