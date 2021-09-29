using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandShinobiSkills : MonoBehaviour
{
    public float barrierCooldownStart;
    public float barrierCooldown;
    public float barrierDuration;
    private float barrierDurationTimer;
    private float barrierCooldownTimer;
    private GameObject windBarrier;
    public GameObject windBarrierPrefab;

    void Start()
    {
        barrierCooldownTimer = barrierCooldownStart;
        barrierDurationTimer = barrierDuration;
    }

    void Update()
    {
        if (windBarrier == null)
        {
            barrierCooldownTimer -= Time.deltaTime;
        }
        if (windBarrier != null)
        {
            barrierDurationTimer -= Time.deltaTime;
        }

        if (barrierCooldownTimer <= 0)
        {
            CreateWindBarrier();
            barrierCooldownTimer = barrierCooldown;
            barrierDurationTimer = barrierDuration;
        }
        if (barrierDurationTimer <= 0)
        {
            Destroy(windBarrier);
        }
    }

    void CreateWindBarrier()
    {
        GameObject wb = Instantiate(windBarrierPrefab, transform.position, Quaternion.identity);
        windBarrier = wb;
        windBarrier.transform.SetParent(transform);
    }
}
