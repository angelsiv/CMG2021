using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image fillingImage;
    private float lerpSpeed = 5;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) currentHealth--;
        if (Input.GetKeyDown(KeyCode.L)) currentHealth++;
        
        health = currentHealth / maxHealth;
        currentHealth = Mathf.Round(currentHealth);
        fillingImage.fillAmount = Mathf.Lerp(fillingImage.fillAmount, health, Time.deltaTime * lerpSpeed);
    }
}
