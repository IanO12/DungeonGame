using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    public Animator anim;
    private bool readyToAttack = true;
    public bool attacking = false;
    Stats stats;
    public LayerMask attackLayer;
    public Transform attackOrigin;
    void Start(){
        stats = GetComponent<Stats>();
    
    }
    void Update(){
        // Debug.Log(attacking);
    }
    public void Attack(){
        if(!readyToAttack || attacking){
            return;
        }
        readyToAttack = false;
        attacking = true;
        anim.SetTrigger("Attack");
        Invoke(nameof(ResetAttack), stats.attackSpeed);
        Invoke(nameof(attackRaycast), stats.attackCooldown);
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void attackRaycast()
    {
        Debug.Log("ATTACKING");
        Ray ray = new Ray(attackOrigin.position, attackOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, stats.range, attackLayer))
        {
            Debug.Log("HIT");
            Hit(hit.collider.gameObject);
        }
    }

    void Hit(GameObject go){
        Stats enemyStats = go.GetComponent<Stats>();
        enemyStats.health -= 1f;
        if(enemyStats.health <= 0){
            Destroy(go);
        }
        HitEffect[] hitEffects = go.GetComponentsInChildren<HitEffect>();
        if(hitEffects != null){
            for(int i = 0; i < hitEffects.Length; i++){
                hitEffects[i].hitEffect();
            }
        }
    }
}
