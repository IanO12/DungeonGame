using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackAnimation : MonoBehaviour
{
    public Animator anim;
    private bool readyToAttack = true;
    public bool attacking = false;
    Stats stats;
    public LayerMask attackLayer;
    public Transform attackOrigin;
    RangeEnemyController ranger;
    void Start(){
        stats = GetComponent<Stats>();
        ranger = GetComponent<RangeEnemyController>();
    }
    public void Attack(){
        if(!readyToAttack || attacking){
            return;
        }
        readyToAttack = false;
        attacking = true;
        anim.SetTrigger("Attack");
        Invoke(nameof(ResetAttack), stats.attackSpeed);
        if(ranger == null){
            Invoke(nameof(attackRaycast), stats.attackCooldown);
        }else{
            Debug.Log("SHOT");
            ranger.Shoot();
        }
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void attackRaycast()
    {
        Ray ray = new Ray(attackOrigin.position, attackOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, stats.range, attackLayer))
        {
            HandleHit.Hit(hit.collider.gameObject);
        }
    }
}
