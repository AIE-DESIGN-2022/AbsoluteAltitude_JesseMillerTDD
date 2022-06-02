using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;
    public float currentHealth;

    public Slider shieldSlider;
    public float maxShield;
    public float currentShield;

    public float timeToStartRegen;
    public float timeToRegen;

    private float timeSinceDamage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = currentHealth;

        currentShield = maxShield;
        shieldSlider.maxValue = currentShield;

        UpdateHealthBar();
        UpdateShieldBar();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDamage += Time.deltaTime;

        if (timeSinceDamage >= timeToStartRegen && currentShield < maxShield)
        {
            StartCoroutine(ShieldRegen());
        }
    }

    private IEnumerator ShieldRegen()
    {
        float regenTime = 0f;
        float shieldValue = currentShield;

        while (regenTime < timeToRegen && timeSinceDamage > timeToStartRegen)

        {
            regenTime += Time.deltaTime;
            float lerpTime = regenTime / timeToRegen;
            shieldSlider.value = Mathf.Lerp(shieldValue, maxShield, lerpTime);
            currentShield = shieldSlider.value;
            UpdateShieldBar();

            yield return null;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        if (currentShield > 0)
        {
            currentShield -= damageToTake;
            if (currentShield < 0)
            {
                currentHealth += currentShield;
            }
        }

        else
        {

            currentHealth -= damageToTake;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        timeSinceDamage = 0;

        UpdateHealthBar();
        UpdateShieldBar();
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

    private void UpdateShieldBar()
    {
        shieldSlider.value = currentShield;
    }
}
