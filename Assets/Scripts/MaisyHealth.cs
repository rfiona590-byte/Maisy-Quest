using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaisyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text healthText;
    public Animator healthAnim;
    private void Start()
    {
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;
    }

    public void ChangeHealth (int amount)
    {
        currentHealth += amount;
        healthAnim.Play("HealthUpdate");
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
