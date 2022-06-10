using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Vector3 firingForce;
    public float damage;
    public float lifeTime;
    public float bulletSpread;

    private Rigidbody _bulletRB;

    // Start is called before the first frame update
    void Start()
    {
        _bulletRB = GetComponent<Rigidbody>();

        //randomise X and Y values of FiringForce
        firingForce.x += Random.Range(-bulletSpread, bulletSpread);
        firingForce.y += Random.Range(-bulletSpread, bulletSpread);

        _bulletRB.AddRelativeForce(firingForce, ForceMode.Impulse);

        StartCoroutine("BulletTimer");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BulletTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Bullet")
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }      
}
