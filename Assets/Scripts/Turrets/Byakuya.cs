using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Byakuya : MonoBehaviour
{
    public float petalSpeed = 180;
    public int numberOfPetals = 5;
    // projectile prefabs
    public GameObject projectilePrefab;

    // instance variables
    protected CircleCollider2D orbitRadius;

    // Start is called before the first frame update
    void Start()
    {
        orbitRadius = GetComponent<CircleCollider2D>();
        for(int i = 0; i < numberOfPetals; i++)
        {
            GameObject petal = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            petal.transform.SetParent(transform);
            SenbonzakuraPetal petalScript = petal.GetComponent<SenbonzakuraPetal>();
            petalScript.FocalPoint = transform.position;
            petalScript.Speed = petalSpeed;
            petalScript.Tilt = i * (360/numberOfPetals);
            petalScript.SemiMajorAxis = orbitRadius.radius;
            petalScript.SemiMinorAxis = orbitRadius.radius* (2.0f/3.0f);
            petalScript.Alpha = i * (720/numberOfPetals);
            petalScript.damage = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
    }
}
