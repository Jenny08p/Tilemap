using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed;
    public float jumpForce; 

    public Text countText;
    public Text winText;

    public Text loseText;

    public Text livesText; 

    private Rigidbody rb;
    private int count;

    private int lives; 
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;

        SetCountText ();
        SetLivesText ();

        winText.text = "";
        loseText.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count +1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag ( "Pick Bad"))
        {
            other.gameObject.SetActive (false);
            lives = lives -1;
            SetLivesText ();
        }
    }
     void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 4)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
         }
    }
    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString ();
        if (lives == 0)
        {
            loseText.text = "You Lost!";
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 0);
        }
    }
}
