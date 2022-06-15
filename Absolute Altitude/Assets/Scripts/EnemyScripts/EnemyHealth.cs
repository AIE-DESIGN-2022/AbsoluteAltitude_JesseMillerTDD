using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public float damage;

    public GameObject enemyShield;
    public bool _hasShield;

    private Transform _parent;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        _parent = healthBar.transform.parent;

        RandomEnemyShield();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }

    private void RandomEnemyShield()
    {
        int randomShieldNumber = Random.Range(0, 2);

        if (randomShieldNumber == 0)
        {
            _hasShield = true;
            enemyShield.SetActive(true);
        }
        else if(randomShieldNumber == 1)
        {
            _hasShield = false;
            enemyShield.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameOverManager>().gameOver = true;

        }
    }
    public void DestroyShield()
    {
        if (_hasShield)
        {
            _hasShield = false;
            enemyShield.SetActive(false);
        }
    }
}

