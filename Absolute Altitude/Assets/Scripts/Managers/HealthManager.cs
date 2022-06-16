using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;
    public float currentHealth;

    public GameObject shieldObject;
    public float maxShield;
    public float currentShield;


    // Start is called before the first frame update
    void Start()
    {
        shieldObject.SetActive(false);

        currentHealth = maxHealth;
        healthSlider.maxValue = currentHealth;

        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageToTake)
    {
        if (currentShield > 0)
        {
            currentShield = 0;
            shieldObject.SetActive(false);
        }

        else
        {
            currentHealth -= damageToTake;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        UpdateHealthBar();
    }

    public void ReceiveHealth(float healthToReceive)
    {
        currentHealth += healthToReceive;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }

    public void TurnShieldOn()
    {
        currentShield = 1;
        shieldObject.SetActive(true);
    }
}
