using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject Destination { get; set; }
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
        MoveTo(Destination.transform);
    }

    void MoveTo(Transform location)
    {
        Vector3 vectorTo = location.position - this.transform.position;
        Vector3 vectorMove = vectorTo.normalized * speed * Time.deltaTime;

        if (!Mathf.Approximately(vectorTo.magnitude, 0)) 
        {
            if (vectorTo.magnitude <= vectorMove.magnitude) 
            {
                this.transform.position = location.position;
            }
            else
            {
                this.transform.position += vectorMove;
            }
        }
    }
}
