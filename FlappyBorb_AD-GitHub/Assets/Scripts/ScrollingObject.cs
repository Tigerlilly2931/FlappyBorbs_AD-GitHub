using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed = -1.5f;
    public Borb birdy;
    // Start is called before the first frame update
    void Start()
    {
        birdy = GameObject.Find("Dargon").GetComponent<Borb>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (birdy.isDed)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
