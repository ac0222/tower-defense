using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoints : MonoBehaviour
{
    public static MapPoints instance = null;
    public static MapPoints Instance {get {return instance; }}
    public GameObject checkpoints;
    public GameObject destination;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public List<Vector3> MakePath()
    {
        List<Vector3> path = new List<Vector3>();
        foreach(Transform ct in checkpoints.transform)
        {
            path.Add(ct.position);
        }
        path.Add(destination.transform.position);
        return path;
    }
}
