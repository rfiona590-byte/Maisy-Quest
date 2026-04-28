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
        //updates the UI for EXP and leveling up
        UpdateUI();
    }

    private void Update()
    {
        //this is used for testing lmao
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainExperience(2);
        }
        //if player reaches this level, you will be teleported to boss fight!
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

    //what happenes when player levels up
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
