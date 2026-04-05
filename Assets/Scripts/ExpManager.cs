using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{
    public static bool lvlUp = false;
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expMultiplier = 1.2f; //adds 20 percent
    public Slider expSlider;
    public TMP_Text lvlText;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainExperience(2);
        }

        if (level == 3)
        {
            SceneLoader.GoToScene(4);
        }
    }

    //listens to see if chicken is defeated
    private void OnEnable()
    {
        ChickenHealth.OnChickenDefeat += GainExperience;
    }
    //makes sure its running when its supposed to
    private void OnDisable()
    {
        ChickenHealth.OnChickenDefeat -= GainExperience;
    }

    public void GainExperience(int amount)
    {
        currentExp += amount;
        if (currentExp >= expToLevel)
        {
            LevelUp();

        }
        UpdateUI();
    }

    private void LevelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expMultiplier);
        lvlUp = true;
        ChickenCombat.damage += 3;
        ChickenHealth.maxHealth += 5;
        ChickenHealth.currentHealth = ChickenHealth.maxHealth;

    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        lvlText.text = "Level: " + level;

    }
}
