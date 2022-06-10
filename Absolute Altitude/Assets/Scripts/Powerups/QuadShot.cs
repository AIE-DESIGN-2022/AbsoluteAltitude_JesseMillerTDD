using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadShot : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPosition;
    private float spawnTimer;
    private float spawnDelay = 0.2f;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Activate(false);
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

    public void Activate(bool isActive)
    {
        gameObject.SetActive(isActive);
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(LifeTime());
        }

    }
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Activate(false);
    }
}
