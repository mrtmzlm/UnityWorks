using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject obstaclePrefabs;
     private Vector3 spawmPos = new Vector3(25, 0, 0);
     private float startDelay = 2f;
     private float repeatDelay = 1f;
     private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs, spawmPos, obstaclePrefabs.transform.rotation);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
