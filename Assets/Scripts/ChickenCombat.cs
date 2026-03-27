using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCombat : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float range;
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
        if (hits.Length > 0)
        {
            hits[0].GetComponent<MaisyHealth>().ChangeHealth(-damage);
        }
    }
}
