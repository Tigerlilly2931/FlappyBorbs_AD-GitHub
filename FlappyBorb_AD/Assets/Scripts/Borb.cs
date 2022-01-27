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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("Die", false);
        isDed = false;
        score = 0;
        ScoreText = GameObject.Find("ScoreTXT").GetComponent<Text>();
        GameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDed)
        {
            if (Input.GetMouseButtonDown(0))
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
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isDed = true;
        gameObject.GetComponent<Animator>().SetBool("Die", true);
        GameOverText.SetActive(true);

    }
}
