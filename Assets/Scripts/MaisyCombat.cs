using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisyCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    public void MaisyAttack()
    {
        anim.SetBool("isAttacking", true);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.weaponRange, enemyLayer);
        if (enemies.Length > 0 )
        {
            enemies[0].GetComponent<ChickenHealth>().ChangeHealth(-StatsManager.Instance.damage);
            enemies[0].GetComponent<ChickenKnockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.stunTime);
        }

    }

    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
