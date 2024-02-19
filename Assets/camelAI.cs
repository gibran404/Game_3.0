using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camelAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float moveSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (raceStart.raceStarted == false)
        {
            return;
        }
        
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
