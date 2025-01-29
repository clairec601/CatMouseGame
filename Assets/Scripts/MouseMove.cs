using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseMove : MonoBehaviour {

    public GameObject player;
    Rigidbody2D rb;
    float moveForce = 40;
    private bool isGrounded;
    private bool onLadder;
    private bool isFacingLeft;
    private bool isFacingRight;
    private bool isClimbing;
    private Vector2 facingLeft;
    private Vector2 facingRight;
    public float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public static int lives = 3;  
    private static bool thirdWasDestroyed;
    private static bool secondWasDestroyed;
    private static bool firstWasDestroyed;
    private float vertical;
    private float horizontal;

     void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
            Debug.Log("on ground");
        }   

        if (col.gameObject.tag == "YarnBall"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            decreaseLives();
        }

        if (col.gameObject.tag == "GirlMouse"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            ScoreScript.scoreValue += 100;
            resetLives();
        }

      
    }
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == ("Ground")){
          isGrounded = false;
          Debug.Log("on ground");
        }

    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == ("Ladder")){
            onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == ("Ladder")){
            onLadder = false;
        }

    }

    public static void resetLives() {
        thirdWasDestroyed = false;
        secondWasDestroyed = false;
        firstWasDestroyed = false;

    }
    public static void decreaseLives() {
      lives--;

      if (lives == 2) {
          thirdWasDestroyed = true;
      }

      if (lives == 1) {
          thirdWasDestroyed = true;
          secondWasDestroyed = true;
      }

      if (lives == 0){
          thirdWasDestroyed = true;
          secondWasDestroyed = true;
          firstWasDestroyed = true;
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
    }

    void Awake() {
      var heart3 = GameObject.FindWithTag("ThirdHeart");
      var heart2 = GameObject.FindWithTag("SecondHeart");
      var heart1 = GameObject.FindWithTag("FirstHeart");

      if (thirdWasDestroyed){
        Destroy(heart3);
      }

      if (secondWasDestroyed){
        Destroy(heart2);
      }

      if (firstWasDestroyed){
        Destroy(heart1);
      }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        facingRight = new Vector2(transform.localScale.x, transform.localScale.y);

        Scene currentScene = SceneManager.GetActiveScene(); //active scene

    }

    // Update is called once per frame
    void Update()
    {
      if (player.transform.position.y <= -370){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
      }
      Vector3 position = transform.position;

       if (Input.GetKey(KeyCode.RightArrow)){
           isFacingRight = true;
           isFacingLeft = false;
       }
       else if (Input.GetKey(KeyCode.LeftArrow)) {
           isFacingRight = false;
           isFacingLeft = true;
       }

      horizontal = Input.GetAxis("Horizontal");

      if (Mathf.Abs(horizontal) > 0f){
        rb.velocity = new Vector2(horizontal * moveForce * 5f, rb.velocity.y);
      }
      else if (Mathf.Abs(horizontal) < 0f){
        rb.velocity = new Vector2(horizontal * moveForce * 5f, rb.velocity.y);
        transform.localScale = facingLeft;
      }

      if (isFacingLeft){
        transform.localScale = facingLeft;
      }

      if (isFacingRight){
        transform.localScale = facingRight;
      }

      if (isGrounded == true && Input.GetKey(KeyCode.Space)){
          isJumping = true;
          jumpTimeCounter = jumpTime;
          rb.velocity = Vector2.up * 150f;
      }

      if (Input.GetKey(KeyCode.Space) && isJumping == true) {
          if (jumpTimeCounter > 0){
            rb.velocity = Vector2.up * 150f;
            jumpTimeCounter -= Time.deltaTime;
          }
          else {
            isJumping = false;
          }
      }
      
      if (Input.GetKeyUp(KeyCode.Space)){
          isJumping = false;
      }
      
      vertical = Input.GetAxis("Vertical");

      if (onLadder && Mathf.Abs(vertical) >= 0f){
        isClimbing = true;
      }
      else if (!onLadder){
        isClimbing = false;
      }
    }

    private void FixedUpdate(){
      if (isClimbing){
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rb.velocity.x, vertical * moveForce * 5f);
      }
      else {
        rb.gravityScale = 50f; 
      }
    }
}


