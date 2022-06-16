using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadShot : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPosition;
    private ProjectileSpawner[] _otherSpawners;

    public float lifeTime;
    private float _spawnTimer;
    private float _spawnDelay = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Activate(false);
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnDelay)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject projectileClone = Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
                _spawnTimer = 0;               
            }
        }
    }

    public void Activate(bool isActive)
    {
        gameObject.SetActive(isActive);
        if (gameObject.activeInHierarchy)
        {
            _otherSpawners = FindObjectsOfType<ProjectileSpawner>();
            foreach (ProjectileSpawner spawner in _otherSpawners)
            {
                spawner.canOverheat = false;
            }
            StartCoroutine(LifeTime());
        }
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        foreach (ProjectileSpawner spawner in _otherSpawners)
        {
            spawner.canOverheat = true;
        }
        Activate(false);
    }
}
