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
        // stopSpawning = false;
        // randomTimer -= Time.deltaTime;
        // if (randomTimer <= 0 && !stopSpawning){
        //     Instantiate(YarnBall, transform.position, transform.rotation);
        //     stopSpawning = true;
        //     randomTimer += setTime;
        // 
        rb.AddForce(transform.right * 1f, ForceMode2D.Impulse);
    }


}
