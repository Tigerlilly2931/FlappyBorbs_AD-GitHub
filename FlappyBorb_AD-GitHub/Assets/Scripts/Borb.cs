using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Borb : MonoBehaviour
{
    public bool isDed = false;

    public float jumpForce = 200f;

    public int score = 0;

    public Text ScoreText;

    public GameObject GameOverText;

    public int lives = 3;

    private bool invincibleShield = false;
    private float inviShieldTimer = 0;
    public int TimerMax = 2;

    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("Die", false);
        isDed = false;
        score = 0;
        ScoreText = GameObject.Find("ScoreTXT").GetComponent<Text>();
        GameOverText.SetActive(false);
        invincibleShield = false;
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        livesText.text = "Extra lives: " + lives;
        if (!isDed)
        {
            if (Input.GetButton("Flap"))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jumpForce));
                gameObject.GetComponent<Animator>().SetTrigger("Flap");
                //just testing that flap worked and score worked together :)
                //score++;
                //ScoreText.text = "Score: " + score;
            }
        }
        if (isDed)
        {
            if (Input.GetButton("Flap"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (invincibleShield && inviShieldTimer <= TimerMax)
        {
            inviShieldTimer += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //having issues where if I disable the collider and fall to ground floor, timer isn't fast enough to catch dragon. Will setting to isTrigger work?
            //gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        else if (invincibleShield && inviShieldTimer > TimerMax)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            invincibleShield = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        if(lives == 0 || collision.gameObject.tag == "Ground")
        {
            Died();
        }
        else
        {
            invincibleShield = true;
            inviShieldTimer = 0;
            lives--;
        }

    }
    //I'm being picky with this Trigger Enter - I didn't like that the dragon fell through the ground if it hit a collumn and then hit the ground, so I fixed it.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Died();
            inviShieldTimer = 3;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -2.648446f, gameObject.transform.position.z);
        }
    }

    private void Died()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isDed = true;
        gameObject.GetComponent<Animator>().SetBool("Die", true);
        GameOverText.SetActive(true);
    }
}
