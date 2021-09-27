using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Byakuya : BasicTurret
{
    // petals
    public float petalSpawnTime = 5.0f;
    public int maxPetals = 20;
    public float petalSpeed = 180;
    public float petalDamage = 2;
    private float petalTimer = 0;
    private float numPetals = 0;

    // projectile prefabs
    public GameObject projectilePrefab;

    // instance variables
    protected CircleCollider2D orbitRadius;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();        
        orbitRadius = GetComponent<CircleCollider2D>();
        petalTimer = 0;
        numPetals = 0;
    }

    private void Update()
    {
        if (IsBuilt)
        {
            petalTimer -= Time.deltaTime;
            if (petalTimer <= 0 && numPetals < maxPetals)
            {
                SpawnPetal();
                petalTimer = petalSpawnTime;
            }
        }
    }

    private void SpawnPetal()
    {
        GameObject petal = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        petal.transform.SetParent(transform);
        SenbonzakuraPetal petalScript = petal.GetComponent<SenbonzakuraPetal>();
        petalScript.FocalPoint = transform.position;
        petalScript.Speed = petalSpeed + (Random.value - 0.5f) * (0.2f * petalSpeed);
        petalScript.Tilt = Random.value * 360;
        petalScript.SemiMajorAxis = orbitRadius.radius;
        petalScript.SemiMinorAxis = orbitRadius.radius* (2.0f/3.0f);
        petalScript.Alpha = Random.value * 360;
        petalScript.damage = petalDamage;
        numPetals++;
    }
}
