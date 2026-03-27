using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCombat : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float stunTime;
    public float range;
    public float knockbackForce;
    public LayerMask playerLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MaisyHealth>().ChangeHealth(-damage);
        }
    }
    public void ChickenAttack ()
    {
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, range, playerLayer);
        Debug.Log(hits[0]);
        if (hits.Length > 0)
        {
            Debug.Log("Maisy");
            hits[0].GetComponent<MaisyHealth>().ChangeHealth(-damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
