using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisyCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public int damage = 1;
    public float knockbackForce = 50;
    public float stunTime = 1;

    public void MaisyAttack()
    {
        anim.SetBool("isAttacking", true);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);
        if (enemies.Length > 0 )
        {
            enemies[0].GetComponent<ChickenHealth>().ChangeHealth(-damage);
            enemies[0].GetComponent<ChickenKnockback>().Knockback(transform, knockbackForce, stunTime);
        }

    }

    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
