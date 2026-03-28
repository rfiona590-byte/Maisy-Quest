using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ChickenMovement : MonoBehaviour
{
    //public var
    public float speed;
    public float attackRange = 2;
    public float cooldown = 5;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    //private var
    private float cooldownTimer;
    private int facingDir = -1;
    private Rigidbody2D rb;
    private Transform maisy;
    private Animator anim;
    private EnemyState enemyState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState != EnemyState.Knockback)
        {
            CheckForPlayer();
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    //sees if maisy is in range, chases the player
    void Chase()
    {
        if ((maisy.position.x > transform.position.x && facingDir == -1) ||
            (maisy.position.x < transform.position.x && facingDir == 1))
        {
            Flip();
        }
        Vector2 direction = ((maisy.position - transform.position).normalized);
        rb.linearVelocity = direction * speed;

    }

    void Flip()
    {
        facingDir *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        if (hits.Length > 0)
        {
            Debug.Log("maisy confirm");
            maisy = hits[0].transform;
            //checks if in range and cooldown is ready
            if (Vector2.Distance(transform.position, maisy.position) <= (attackRange+1))
            {
                Debug.Log("test");
                ChangeState(EnemyState.Attacking);
                cooldownTimer = cooldown;

            }
            else if (Vector2.Distance(transform.position, maisy.position) > attackRange)
            {
                ChangeState(EnemyState.Chasing);
            }

        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }

    public void ChangeState(EnemyState newState)
    {
        //exits current animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);

        //updates current state
        enemyState = newState;

        //updates new animation
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", true);

    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockback
}
