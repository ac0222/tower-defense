using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistShinobiSkills : MonoBehaviour
{
    public float invisCooldown;
    public float invisDuration;
    private float invisDurationTimer;
    private float invisCooldownTimer;
    public bool IsInvis {get; set;}

    void Start()
    {
        invisCooldownTimer = invisCooldown;
        invisDurationTimer = invisDuration;
    }

    void Update()
    {
        if (!IsInvis)
        {
            invisCooldownTimer -= Time.deltaTime;
        }
        if (IsInvis)
        {
            invisDurationTimer -= Time.deltaTime;
        }

        if (invisCooldownTimer <= 0)
        {
            GoInvis();
            invisCooldownTimer = invisCooldown;
            invisDurationTimer = invisDuration;
        }
        if (invisDurationTimer <= 0)
        {
            ExitInvis();
        }
    }

    void GoInvis()
    {
        Color currentColour = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(currentColour.r, currentColour.g, currentColour.b, 0.5f);
        IsInvis = true;
        gameObject.GetComponent<MinionController>().IsTargetable = false;
    }

    void ExitInvis()
    {   
        Color currentColour = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(currentColour.r, currentColour.g, currentColour.b, 1);
        IsInvis = false;
        gameObject.GetComponent<MinionController>().IsTargetable = true;
    }
}
