using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject shieldItem;
    public GameObject healthItem;
    public GameObject weaponItem;
    public GameObject player;

    public Transform spawnPosition;
    public Vector3 spawnForce;

    public int chanceToSpawnItem;
    public float interval;
    public float _xSpawnRange = 3f;
    public bool isPlaying;

    private float _counter = 0;
   

    private void Start()
    {
        isPlaying = false;
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        _xSpawnRange = topCorner.x - 1;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlaying)
        {
            _counter += Time.deltaTime;

            if (_counter >= interval && player != null)
            {
                int randomNum = Random.Range(0, 100);

                _counter = 0;
                if (randomNum <= chanceToSpawnItem)
                {
                    GameObject item = Instantiate(RandomItemPrefab(), new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), transform.position.y, transform.position.z), transform.rotation);
                    item.GetComponent<Rigidbody>().AddRelativeForce(spawnForce, ForceMode.Impulse);
                }
                else if (randomNum >= chanceToSpawnItem)
                {
                    GameObject enemy = Instantiate(RandomEnemyPrefab(), new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), transform.position.y, transform.position.z), transform.rotation);
                    enemy.GetComponentInChildren<Rigidbody>().AddRelativeForce(spawnForce, ForceMode.Impulse);
                }
            }
        }
    }
    private GameObject RandomEnemyPrefab()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[randomIndex];
    }
    private GameObject RandomItemPrefab()
    {
       int randomIndex = Random.Range(0, 100);
        if(randomIndex <= 30)
        {
            return shieldItem; 
        }
        else if (randomIndex > 30 && randomIndex <= 40)
        {
            return healthItem;
        }
        else
        {
            return weaponItem;
        }
    }
}