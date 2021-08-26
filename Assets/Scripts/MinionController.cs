using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public float speed = 10f;
    public Stack<Vector3> Path {get; set;}
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        FollowPath();
    }

    void MoveTo(Vector3 destinationVector)
    {
        Vector3 vectorTo = destinationVector - this.transform.position;
        Vector3 vectorMove = vectorTo.normalized * speed * Time.deltaTime;

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

    void FollowPath()
    {
        // determine checkpoint
        Vector3 nextCheckpoint = Path.Peek();
        float distanceToCheckpoint = (nextCheckpoint - this.transform.position).magnitude;
        while (Mathf.Approximately(distanceToCheckpoint, 0))
        {
            Path.Pop();
            nextCheckpoint = Path.Peek();
            distanceToCheckpoint = (nextCheckpoint - this.transform.position).magnitude;
        }
        // move towards checkpoint
        MoveTo(nextCheckpoint);
    }
}
