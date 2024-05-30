using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseMove : MonoBehaviour
{

    public GameObject player;
    Rigidbody2D rb;
    Animator anim;
    float moveForce = 2;
    private bool isGrounded;
    private bool onLadder;
    public float jumpTimeCounter;
    public float jumpTime;
    public float airTime;
    private bool isJumping;

    static public int totalLives = 3;
    public int lives;   

     void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
            Debug.Log("on ground");
        }   

        if (col.gameObject.tag == ("Ladder")){
            onLadder = true;
            Debug.Log("on ladder");
        }

        if(col.gameObject.tag == "YarnBall"){ //replace with invisible object
            ScoreScript.scoreValue += 100;
            Debug.Log("score: " + ScoreScript.scoreValue);
        }

        if (col.gameObject.tag == "YarnBall"){
            lives = totalLives--;
            if (lives == 0){
                Debug.Log("Game over");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

            }
            Debug.Log("Lives minus one");
        }
      
    }
    void OnCollisionExit2D(Collision2D col){
          if (col.gameObject.tag == ("Ground")){
            isGrounded = false;
            Debug.Log("off ground");
          }

          if (col.gameObject.tag == ("Ladder")){
            onLadder = false;
            Debug.Log("off ladder");
          }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Scene currentScene = SceneManager.GetActiveScene(); //active scene
        lives = totalLives;
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 position = transform.position;

      if (Input.GetKey(KeyCode.RightArrow)){
      rb.AddForce(transform.right * (-moveForce), ForceMode2D.Force); 
      anim.SetBool("isMovingRight", true);
      anim.SetBool("isMoving", false);
      anim.SetBool("isIdleRight", false);
      }
      else{
        anim.SetBool("isMovingRight", false);
      }
      
      if (Input.GetKey(KeyCode.LeftArrow)) {
      rb.AddForce(-transform.right * (-moveForce), ForceMode2D.Force); 
      anim.SetBool("isMoving", true);
      anim.SetBool("isMovingRight", false);
      anim.SetBool("isIdle", false);
      }
      else {
        anim.SetBool("isMoving", false);
      }

      if (anim.GetBool("isIdleRight")){
        Debug.Log("right");
      }
      else {
        Debug.Log("no right");
      }

      if (anim.GetBool("isIdleRight") || anim.GetBool("isMovingRight")){
          if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
          isJumping = true;
          anim.SetBool("isJumpingRight", true);
          jumpTimeCounter = jumpTime;
          rb.velocity = Vector2.up * 5;

      }

      if (Input.GetKey(KeyCode.Space) && isJumping == true) {
          if (jumpTimeCounter > 0){
          rb.velocity = Vector2.up * 5;
          anim.SetBool("isJumpingRight", true);
          //rb.AddForce(transform.up * moveForce, ForceMode2D.Impulse); 
          jumpTimeCounter -= Time.deltaTime;
          }
          else {
            isJumping = false;
          }
      }
      
      if (Input.GetKeyUp(KeyCode.Space)){
        isJumping = false;
        anim.SetBool("isJumpingRight", false);
      }
      }


      if (anim.GetBool("isIdle") || anim.GetBool("isMoving")){
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
          isJumping = true;
          anim.SetBool("isJumping", true);
          jumpTimeCounter = jumpTime;
          rb.velocity = Vector2.up * 5;

      }

      if (Input.GetKey(KeyCode.Space) && isJumping == true){
          if (jumpTimeCounter > 0){
          rb.velocity = Vector2.up * 5;
          anim.SetBool("isJumping", true);
          //rb.AddForce(transform.up * moveForce, ForceMode2D.Impulse); 
          jumpTimeCounter -= Time.deltaTime; 
          } 
          else {
            isJumping = false;
          }
      }
      
      if (Input.GetKeyUp(KeyCode.Space)){
        isJumping = false;
        anim.SetBool("isJumping", false);
      }
      }

      if (onLadder && Input.GetKey(KeyCode.UpArrow)){
            anim.SetBool("isClimbing", true);
            rb.AddForce(transform.up * (moveForce), ForceMode2D.Force);
        }
      
      else if (!onLadder){
        anim.SetBool("isClimbing", false);
      }

      
      
      if (position.x >= 7){
          Debug.Log("out of bounds");
          position.x = 7;
          transform.position = position;
      }

      if (position.x <= -7){
          Debug.Log("out of bounds");
          position.x = -7;
          transform.position = position;
      }
    }
}

