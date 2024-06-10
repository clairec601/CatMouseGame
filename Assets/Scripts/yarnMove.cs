using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarnMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject YarnBall;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        // stopSpawning = false;
        // randomTimer -= Time.deltaTime;
        // if (randomTimer <= 0 && !stopSpawning){
        //     Instantiate(YarnBall, transform.position, transform.rotation);
        //     stopSpawning = true;
        //     randomTimer += setTime;
        // 
        rb.AddForce(transform.right * 1.2f, ForceMode2D.Impulse);

        if (position.x >= 405){
          //Debug.Log("out of bounds");
          // position.x = 440;
          // transform.position = position;
        rb.velocity = Vector3.zero;
        rb.AddForce(-transform.right * 1.2f, ForceMode2D.Impulse);
        }

        if (position.x <= -405){
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.right * 1.2f, ForceMode2D.Impulse);
        }

        
    }


}
