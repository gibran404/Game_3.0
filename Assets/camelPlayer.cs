using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camelPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float moveSpeed = 2f;

    private float lastSpacePressTime;
    [SerializeField] private float moveSpeedMultiplier = 2f;
    [SerializeField] private float accelerationRate = 0.5f; // Increase this value for faster acceleration
    [SerializeField] private float timeSinceLastPress;
    [SerializeField] private float timeSinceNotPressed;

    public GameObject speedText;


    void Start()
    {
        raceStart.raceStarted = false; 
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        lastSpacePressTime = Time.time;
        timeSinceLastPress = 100f;
    }

    void Update()
    {
        
        if (raceStart.raceStarted == false)
        {
            return;
        }
        
        timeSinceNotPressed = Time.time - lastSpacePressTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeSinceLastPress = Time.time - lastSpacePressTime;
            if ((timeSinceLastPress < 0.5f) && (moveSpeedMultiplier < 5.8)) // Adjust this value for the time window to consider as fast presses
            {
                moveSpeedMultiplier += accelerationRate;
            }
            else
            {
                moveSpeedMultiplier -= 0.5f;
                if (moveSpeedMultiplier < 2f)
                {
                    moveSpeedMultiplier = 2f;
                }
            }
            lastSpacePressTime = Time.time;
        }
        else if ((timeSinceNotPressed > 0.5f) && (moveSpeedMultiplier > 2f))
        {
            moveSpeedMultiplier -= 0.2f;
        }

        rb.velocity = new Vector2(moveSpeed * moveSpeedMultiplier, rb.velocity.y);
        speedText.GetComponent<Text>().text = "Speed: " + (moveSpeed*moveSpeedMultiplier).ToString("0");
    }
}
