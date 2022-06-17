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

        //finding the screen bounds to determine size of spawner
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

                //picking a random number between 0-100, if number is less than the item spawn chance an item will be spawned
                if (randomNum <= chanceToSpawnItem)
                {
                    GameObject item = Instantiate(RandomItemPrefab(), new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), transform.position.y, transform.position.z), transform.rotation);
                    item.GetComponent<Rigidbody>().AddRelativeForce(spawnForce, ForceMode.Impulse);
                }

                //else if the number is greater thasn item spawn chance an enemy will be spawned
                else if (randomNum >= chanceToSpawnItem)
                {
                    GameObject enemy = Instantiate(RandomEnemyPrefab(), new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), transform.position.y, transform.position.z), transform.rotation);
                    enemy.GetComponentInChildren<Rigidbody>().AddRelativeForce(spawnForce, ForceMode.Impulse);
                }
            }
        }
    }

    //this function picks randomly from an array of enenmy prefabs before spawning 
    private GameObject RandomEnemyPrefab()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[randomIndex];
    }

    //sets independant percentages for each item drop chance
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