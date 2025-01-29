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
        rb.AddForce(transform.right * 20f, ForceMode2D.Impulse);
        
    }


}
