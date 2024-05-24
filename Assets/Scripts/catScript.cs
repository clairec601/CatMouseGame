using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript : MonoBehaviour
{
    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D col){
         if(col.gameObject.name =="yarn ball"){
            ScoreScript.scoreValue += 100;
         }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
