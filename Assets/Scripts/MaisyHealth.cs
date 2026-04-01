using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaisyHealth : MonoBehaviour
{

    public TMP_Text healthText;
    public Animator healthAnim;
    private void Start()
    {
        healthText.text = "Health: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;
    }

    public void ChangeHealth (int amount)
    {
        StatsManager.Instance.currentHealth += amount;
        healthAnim.Play("HealthUpdate");
        healthText.text = "Health: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            Die();
        }
    }
    protected void Die ()
    {
        
        Destroy(gameObject);
    }
}
