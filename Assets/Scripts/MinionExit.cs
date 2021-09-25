using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("Minion"))
        {
            Destroy(col.gameObject);
            if (PlayerController.Instance.Lives > 0)
            {
                PlayerController.Instance.ChangeLives(-1);
            }
        }
    }
}
