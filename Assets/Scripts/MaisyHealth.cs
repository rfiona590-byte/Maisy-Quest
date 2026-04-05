using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaisyHealth : MonoBehaviour
{

    public TMP_Text healthText;
    public Animator healthAnim;
    public static bool appleTrue = false;
    
    private void Start()
    {
        healthText.text = "Health: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;

    }

    private void Update()
    {
        if (appleTrue == true)
        {
            StatsManager.Instance.currentHealth += 5;
            Debug.Log("test");
            if (StatsManager.Instance.currentHealth >= StatsManager.Instance.maxHealth)
            {
                StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth;
            }
            MaisyHealth.appleTrue = false;
        }
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
        SceneLoader.GoToScene(3);
    }
}
