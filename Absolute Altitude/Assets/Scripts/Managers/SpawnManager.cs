using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] itemPrefabs;
    public Transform spawnPosition;
    public Vector3 spawnForce;
    public int chanceToSpawnItem;
    private float _counter = 0;
    public float interval = 100;
    public float _xSpawnRange = 3f;
    public GameObject player;
    

    private void Start()
    {
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        _xSpawnRange = topCorner.x - 1;
        
    }


    // Update is called once per frame
    void FixedUpdate()
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
            else 
            {
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), transform.position.y, transform.position.z), transform.rotation);
                enemy.GetComponent<Rigidbody>().AddRelativeForce(spawnForce, ForceMode.Impulse);
            } 
        }
    }

    private GameObject RandomItemPrefab()
    {
       int randomIndex = Random.Range(0, itemPrefabs.Length);
        return itemPrefabs[randomIndex];
    }
}