using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int expReward = 5;
    //broadcastes message that chicken has been defeated
    public delegate void ChickenDefeated(int exp);
    //what otther scripts listen for
    public static event ChickenDefeated OnChickenDefeat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if ( currentHealth <= 0)
        {
            OnChickenDefeat(expReward);
            Destroy(gameObject);
        }
    }
}
