using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public string minionName;
    public static int minionsDestroyed = 0;
    public float moneyReward = 10;
    public float maxHealth = 10;
    float currentHealth;

    public float initialSpeed = 10f;
    public float speed;
    bool destroyedByTurret = false;
    public List<Vector3> Path {get; set;}

    public Vector3? FearPoint {get; set;} = null;
    public bool IsTargetable {get; set;} = true;

    // Start is called before the first frame update
    void Start()
    {
        speed = initialSpeed;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (FearPoint != null)
        {
            RotateAndMoveAwayFrom((Vector3)FearPoint);
        }
        else
        {
            FollowPath();
        }
    }

    void RotateAndMoveTo(Vector3 destinationVector)
    {
        Vector3 vectorTo = destinationVector - this.transform.position;
        Vector3 directionTo = vectorTo.normalized;
        Vector3 vectorMove = directionTo * speed * Time.deltaTime;

        // rotate towards destination
        float angle = Mathf.Atan2(directionTo.y , directionTo.x) * Mathf.Rad2Deg + 90;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);        

        // move towards destination
        if (!Mathf.Approximately(vectorTo.magnitude, 0)) 
        {
            if (vectorTo.magnitude <= vectorMove.magnitude) 
            {
                this.transform.position = destinationVector;
            }
            else
            {
                this.transform.position += vectorMove;
            }
        }
    }

    void RotateAndMoveAwayFrom(Vector3 location)
    {
        Vector3 vectorTo = this.transform.position - location;
        Vector3 directionTo = vectorTo.normalized;
        Vector3 vectorMove = directionTo * speed * Time.deltaTime;

        // rotate towards destination
        float angle = Mathf.Atan2(directionTo.y , directionTo.x) * Mathf.Rad2Deg + 90;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);        

        this.transform.position += vectorMove;
    }

    void FollowPath()
    {
        if (Path.Count == 0) {
            return;
        }

        // determine checkpoint
        Vector3 nextCheckpoint = Path[0];
        RotateAndMoveTo(nextCheckpoint);

        // pop if we arrived
        float distanceToCheckpoint = (nextCheckpoint - this.transform.position).magnitude;
        if (Mathf.Approximately(distanceToCheckpoint, 0))
        {
            Path.RemoveAt(0);
        }
    }

    public float DistanceToExit()
    {
        float distance = 0;
        Vector3 currentPosition = this.transform.position;
        foreach(Vector3 checkpoint in Path)
        {
            distance += (checkpoint - currentPosition).magnitude;
            currentPosition = checkpoint;
        }
        return distance;
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth < 0) 
        {                    
            destroyedByTurret = true;
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        if (destroyedByTurret)
        {
            PlayerController.Instance.ChangeMoney(moneyReward);
        }
        minionsDestroyed += 1;
    }
}
