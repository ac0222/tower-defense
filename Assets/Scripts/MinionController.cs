using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject destination;
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
        MoveTo(destination.transform);
    }

    void MoveTo(Transform location)
    {
        Vector3 vectorTo = location.position - this.transform.position;
        if (!Mathf.Approximately(vectorTo.magnitude, 0)) 
        {
            this.transform.position += vectorTo.normalized * Time.deltaTime;
        }
        Debug.Log(vectorTo);
    }
}
