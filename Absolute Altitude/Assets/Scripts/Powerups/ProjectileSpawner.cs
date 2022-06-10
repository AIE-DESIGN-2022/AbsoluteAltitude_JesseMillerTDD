using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject projectile;

    private float spawnDelay = 0.2f;
    private float spawnTimer;

   // public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        //particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject projectileClone = Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
                spawnTimer = 0;
                //particles.Play();
            }
        }
    }
}
