using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth, maxHealth;
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Slider slider;
    [SerializeField] private float respawnCooldown;
    public bool isDead;
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
            Debug.Log("IsRespawning");
            Debug.Log(timer);
            //Restrict player movement
            //Call for die animation
        }

        if (timer >= respawnCooldown)
        {
            isDead = false;
            currentHealth = 2;
            Debug.Log("HasRespawned");
            slider.value = 0;
            timer = 0;
        }
    }
}
