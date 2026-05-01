using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCombat : MonoBehaviour
{
    public static int damage = 1;
    public Transform attackPoint;
    public float stunTime;
    public float range;
    public float knockbackForce;
    public LayerMask playerLayer;

    //used for testing
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<MaisyHealth>().ChangeHealth(-damage);
        }
    }
    public void ChickenAttack ()
    {
        //does same as with maisey, makes a range and only attacks/does damage of player is in range
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, range, playerLayer);
        Debug.Log(hits[0]);
        if (hits.Length > 0)
        {
           
            hits[0].GetComponent<MaisyHealth>().ChangeHealth(-damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
        }
    }

    //used for testing in unity, highlights the collider that is made
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
