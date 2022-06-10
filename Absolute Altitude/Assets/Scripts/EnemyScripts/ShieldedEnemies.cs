/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldedEnemies : MonoBehaviour
{
    public float enemyHealth;
    public float maxEnemyHealth;
    public Image enemyHealthBar;

    private Transform parentObj;

    public GameObject shield;
    public float maxShield;
    public float currentShield;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(true);
        enemyHealth = maxEnemyHealth;
        parentObj = enemyHealthBar.transform.parent;
    }

    public void DealsDamage(float damageToTake)
    {
        if (currentShield > 0)
        {
            currentShield = 0;
            shield.SetActive(false);
        }

        else
        {

            enemyHealth -= damageToTake;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        enemyHealth -= damageToTake;
        enemyHealthBar.fillAmount = enemyHealth / maxEnemyHealth;

        if (enemyHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
*/