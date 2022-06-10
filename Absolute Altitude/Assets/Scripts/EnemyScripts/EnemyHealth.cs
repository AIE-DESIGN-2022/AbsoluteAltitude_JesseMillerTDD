using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        parent = healthBar.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //parent.transform.LookAt(new Vector3(Camera.main.transform.position.x, parent.transform.position.y, Camera.main.transform.position.z));
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
}
