using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnObject;
    void Start()
    {
        InvokeRepeating("spawnYarnBall", 5.0f, 5.0f); //calls method 
    }

    public void spawnYarnBall(){
        Vector3 spawnPosition = new Vector3(2, 129, -5); 
        if (SpawnObject.name == "Yarn"){
            GameObject cloneYarnBall = Instantiate(SpawnObject, spawnPosition, transform.rotation);
            cloneYarnBall.name = "cloneYarnBall";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (position.x >= 240){
          Debug.Log("out of bounds");
          position.x = 240;
          transform.position = position;
      }

    
    }
}

