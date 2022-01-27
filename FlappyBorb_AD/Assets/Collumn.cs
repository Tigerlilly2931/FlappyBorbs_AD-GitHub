using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collumn : MonoBehaviour
{
    public Borb birdyy;
    // Start is called before the first frame update
    void Start()
    {
        birdyy = GameObject.Find("Dargon").GetComponent<Borb>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BorbScored()
    {
        if (birdyy.isDed)
        {
            return;
        }
        birdyy.score++;
        birdyy.ScoreText.text = "Score: " + birdyy.score;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Borb>() != null)
        {
            BorbScored();
        }
    }
}
