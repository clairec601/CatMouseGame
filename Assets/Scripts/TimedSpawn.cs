using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnObject;
    void Start()
    {
        InvokeRepeating("spawnYarnBall", 5.0f, 10.0f); //calls method 
    }

    public void spawnYarnBall(){
        Vector3 spawnPosition = new Vector3(-414, 126, -5); 
        if (SpawnObject.name == "Yarn"){
            GameObject cloneYarnBall = Instantiate(SpawnObject, spawnPosition, transform.rotation);
            cloneYarnBall.name = "cloneYarnBall";
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    
    }
}

