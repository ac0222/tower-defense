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
        if (Path.Count == 0) {
            return;
        }

        // determine checkpoint
        Vector3 nextCheckpoint = Path.Peek();
        MoveTo(nextCheckpoint);

        // pop if we arrived
        float distanceToCheckpoint = (nextCheckpoint - this.transform.position).magnitude;
        if (Mathf.Approximately(distanceToCheckpoint, 0))
        {
            Path.Pop();
        }
    }
}
