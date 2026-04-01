using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private ChickenMovement chickenMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        chickenMovement = GetComponent<ChickenMovement>();
    }

    public void Knockback (Transform playerTransform, float knockForce, float stunTime)
    {
        chickenMovement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockForce;
    }

    IEnumerator StunTimer (float stunTime)
    {
        yield return new WaitForSeconds (stunTime);
        rb.linearVelocity = Vector2.zero;
        chickenMovement.ChangeState(EnemyState.Idle);
    }
}
