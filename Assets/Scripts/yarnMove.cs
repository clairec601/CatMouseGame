using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarnMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject YarnBall;
    Rigidbody2D rb;
    public float randomTimer;
    public float setTime;
    private bool stopSpawning;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("spawnYarnBall", 5f, 5f);
    }

    public void spawnYarnBall(){
        Vector3 spawnPosition = new Vector3(2, 129, -5); 
        Instantiate(YarnBall, spawnPosition, transform.rotation);
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
