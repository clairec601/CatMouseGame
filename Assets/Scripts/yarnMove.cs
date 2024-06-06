using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarnMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject YarnBall;
    Rigidbody2D rb;
    private float randomTimer;
    private float setTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject newYarnBall;
        randomTimer = Random.Range(4f, 10f);
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0){
            newYarnBall = Instantiate(YarnBall, transform.position, transform.rotation);
            randomTimer = setTime;
        }
    }
}
