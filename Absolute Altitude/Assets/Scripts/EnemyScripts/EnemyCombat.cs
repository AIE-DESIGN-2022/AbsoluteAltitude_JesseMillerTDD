using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject projectile;

    public float spawnDelay;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnDelay)
        {
            GameObject projectileClone = Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
            spawnTimer = 0;
        } 
    }
}
