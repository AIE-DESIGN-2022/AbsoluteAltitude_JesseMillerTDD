using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPosition;

    public Vector3 spawnForce;

    private float counter = 0;
    public float interval = 100;
    

    private void Start()
    {
      
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        counter += Time.deltaTime;

        if (counter >= interval)
        {
            counter = 0;
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            enemy.GetComponent<Rigidbody>().AddRelativeForce(spawnForce, ForceMode.Impulse);
        }
    }
}