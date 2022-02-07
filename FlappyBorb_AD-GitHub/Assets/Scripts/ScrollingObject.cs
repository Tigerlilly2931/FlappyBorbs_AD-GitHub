using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed = -1.5f;
    public Borb birdy;

    public GameObject sky;
    private Rigidbody2D skyrb;
    private float skyScrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        birdy = GameObject.Find("Dargon").GetComponent<Borb>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(scrollSpeed, 0);
        if(gameObject.tag == "Obstacle")
        {
            return;
        }
        skyScrollSpeed = scrollSpeed / 5;
        skyrb = sky.GetComponent<Rigidbody2D>();
        skyrb.velocity = new Vector2(skyScrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (birdy.isDed)
        {
            rb2d.velocity = Vector2.zero;
            if(gameObject.tag == "Obstacle")
            {
                return;
            }
            skyrb.velocity = Vector2.zero;
        }
    }
}
