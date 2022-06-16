using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject projectile;
    public Slider overHeatSlider;
    public Text overHeatedTxt;

    private float _spawnDelay = 0.2f;
    private float _spawnTimer;

    public float shootingNumb;
    public float overheat;
    public bool canOverheat = true;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnDelay)
        {
            if (canOverheat)
            {
                if (Input.GetButton("Fire1") && shootingNumb < overheat)
                {
                    shootingNumb += Time.deltaTime * 10f;
                    GameObject projectileClone = Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
                    _spawnTimer = 0;
                }
            }
            else
            {
                if (Input.GetButton("Fire1"))
                {
                    GameObject projectileClone = Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
                    _spawnTimer = 0;
                }
            }           
        }
        if (!Input.GetButton("Fire1"))
        {
            if (shootingNumb > 0)
            {
                shootingNumb -= Time.deltaTime / 5;
            }
            else
            {
                shootingNumb = 0;
            }
        }

        overHeatSlider.value = shootingNumb;

        if(shootingNumb >= overheat)
        {
            overHeatedTxt.text = "OverHeated!";
        }
        else
        {
            overHeatedTxt.text = "";
        }
    }
}
