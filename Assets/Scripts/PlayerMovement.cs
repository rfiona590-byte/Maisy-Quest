using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

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

    // Update is called once per frame
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

    public void Knockback(Transform chicken, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - (chicken.position)).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }
    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}

