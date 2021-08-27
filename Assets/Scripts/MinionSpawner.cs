using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    float spawnTimer;
    public float spawnFrequency = 3.0f;
    public GameObject minionPrefab;
    public GameObject checkpoints;
    public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {

        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0) {
            GameObject minion = Instantiate(minionPrefab, this.transform.position, Quaternion.identity);
            MinionController mc = minion.GetComponent<MinionController>();
            mc.Path = MakePath();
            spawnTimer = spawnFrequency;
        }
    }

    Stack<Vector3> MakePath()
    {
        Stack<Vector3> path = new Stack<Vector3>();
        path.Push(destination.transform.position);
        List<Vector3> checkpointVectors = new List<Vector3>();
        foreach(Transform ct in checkpoints.transform)
        {
            checkpointVectors.Add(ct.position);
        }
        checkpointVectors.Reverse();
        foreach(Vector3 cv in checkpointVectors)
        {
            path.Push(cv);
        }
        return path;
    }
}
