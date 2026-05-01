using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
   
    public int facing = -1;
    public Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    public Animator anim;
    public MaisyCombat maisyCombat;

    private bool isKnockedBack;

    private void Update()
    {
        //if player clicks = attack
        if (Input.GetButtonDown("Attack"))
        {
            maisyCombat.MaisyAttack();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = rb.GetComponent<SpriteRenderer>();
    }

    // this player movement. gets input, and flips, moves, and controlls animation
    void FixedUpdate()
    {
        if (isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if ((horizontal < 0 && transform.localScale.x > 0)
                || (horizontal > 0 && transform.localScale.x < 0))
            {
                Flip();
            }

            //sets up animation to play
            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
    }

    void Flip ()
    {
        facing *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    //how long the player gets knocked back for, and how far
    public void Knockback(Transform chicken, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - (chicken.position)).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    //the player gets stunned, and this stunns the player
    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }

   
}

