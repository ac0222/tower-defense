using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Byakuya : BasicTurret
{
    public float petalSpeed = 180;
    public int numberOfPetals = 5;
    // projectile prefabs
    public GameObject projectilePrefab;

    // instance variables
    protected CircleCollider2D orbitRadius;
    private bool petalsCreated;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        petalsCreated = false;
    }

    private void Update()
    {
        if (IsBuilt && !petalsCreated)
        {
            InitPetals();
            petalsCreated = true;
        }
    }

    private void InitPetals()
    {
        orbitRadius = GetComponent<CircleCollider2D>();
        for(int i = 0; i < numberOfPetals; i++)
        {
            GameObject petal = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            petal.transform.SetParent(transform);
            SenbonzakuraPetal petalScript = petal.GetComponent<SenbonzakuraPetal>();
            petalScript.FocalPoint = transform.position;
            petalScript.Speed = petalSpeed + (Random.value - 0.5f) * (0.2f * petalSpeed);
            petalScript.Tilt = i * (360/numberOfPetals);
            petalScript.SemiMajorAxis = orbitRadius.radius;
            petalScript.SemiMinorAxis = orbitRadius.radius* (2.0f/3.0f);
            petalScript.Alpha = i * (720/numberOfPetals);
            petalScript.damage = 1;
        }
    }
}
