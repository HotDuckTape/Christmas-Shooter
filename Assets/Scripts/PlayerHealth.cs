using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead;

    [SerializeField] private Slider slider;
    [SerializeField] private Image heart1, heart2;
    [SerializeField] private float currentHealth, maxHealth, respawnCooldown;

    private float timer;


    private void Start()
    {
        currentHealth = maxHealth;
        if (currentHealth == 2)
        {
            heart1.enabled = true;
            heart2.enabled = true;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            heart1.enabled = false;
            heart2.enabled = false;
            isDead = true;
        }
        if (currentHealth == 1)
        {
            heart2.enabled = false;
        }
    }

    private void Update()
    {
        if (currentHealth == 2)
        {
            heart1.enabled = true;
            heart2.enabled = true;
        }

        if (isDead)
        {
            slider.enabled = true;
            slider.value = timer;
            slider.maxValue = respawnCooldown;
            timer += Time.deltaTime;
            //Restrict player movement
            //Call for die animation
        }

        if (timer >= respawnCooldown)
        {
            isDead = false;
            currentHealth = 2;
            slider.value = 0;
            timer = 0;
        }
    }
}
