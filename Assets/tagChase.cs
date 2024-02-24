using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TagChase : MonoBehaviour
{
    public float followSpeed = 7f;
    private Transform target;
    public bool isFollowing = false;
    private Rigidbody rb;

    public GameObject Marker;

    public GameObject HintPanel;

    private SpriteRenderer sprite;

    private float chaseStartTime;
    private float chaseTime;

    void Start()
    {
        chaseTime = 0;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Marker.SetActive(false);
        HintPanel.SetActive(false);

        sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();

        // make self gameobject immovable
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isFollowing && other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger. Press 'E' to start following.");
            Marker.SetActive(true);
            Marker.GetComponent<SpriteRenderer>().color = Color.blue;
            //update hint panel
            HintPanel.SetActive(true);
            HintPanel.transform.GetChild(0).GetComponent<Text>().text = "Press 'E' to start being chased.";
        }
        if (isFollowing && other.CompareTag("Player"))
        {
            playerMovementIso.isalive = false;
            
            isFollowing = false;
            Marker.SetActive(false);
            Debug.Log("Player has been caught. Game over.");
            
            //update hint panel
            HintPanel.SetActive(true);
            HintPanel.transform.GetChild(0).GetComponent<Text>().text = "Player has been caught. Game over.";

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!isFollowing && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            playerMovementIso.issafe = false;
            Marker.SetActive(true);
            Marker.GetComponent<SpriteRenderer>().color = Color.red;
            
            //upadte hunt panel "RUN!"
            HintPanel.SetActive(true);
            HintPanel.transform.GetChild(0).GetComponent<Text>().text = "You are being Chased!\nRUN!!!";

            StartCoroutine(StartFollowing());
            StartCoroutine(Hint());
        }
    }

    void OnTriggerExit(Collider other)
    {   
        if (!isFollowing && other.CompareTag("Player"))
        {
            Debug.Log("Player left without selecting");
            
            Marker.GetComponent<SpriteRenderer>().color = Color.blue;
            Marker.SetActive(false);

            // disable hint panel
            HintPanel.SetActive(false);
        }
        // disable hint panel
        // HintPanel.SetActive(false);
    }

    IEnumerator StartFollowing()
    {
        Debug.Log("Started following the player.");
        isFollowing = true;

        // make self movable again
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        yield return new WaitForSeconds(1f);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovementIso.isFollowed = true;

        chaseStartTime = Time.time;
    }

    IEnumerator Hint()
    {
        Debug.Log("Hint displayed.");

        yield return new WaitForSeconds(3f);
        if (isFollowing)
        {
            //update hint panel
            HintPanel.SetActive(true);
            HintPanel.transform.GetChild(0).GetComponent<Text>().text = "Return to Gold Platform to Win the chase!";
        }
    }

    void Update()
    {
        if (isFollowing && target != null && !playerMovementIso.issafe) // && player !issafe // will chase till player reaches back home
        {
            Vector3 direction = (target.position - transform.position).normalized;
            if (direction.x > 0)
            {
                sprite.flipX = false; // Face right
            }
            else if (direction.x < 0)
            {
                sprite.flipX = true; // Face left
            }

            transform.position += direction * followSpeed * Time.deltaTime;

            chaseTime = Time.time - chaseStartTime;

            if (chaseTime > 1){
                if (Score.score >= 1)
                    Score.score -= 1;
                chaseStartTime = Time.time;
            }
            
        }
        if (isFollowing && playerMovementIso.issafe)
        {
            // open NPC lost panel
            HintPanel.SetActive(true);
            HintPanel.transform.GetChild(0).GetComponent<Text>().text = "You won the Chase!";

            Score.score += 15;
            Debug.Log("Player has reached home. NPC lost the chase.");

            StartCoroutine(lost());
        }
    }

    IEnumerator lost()
    {
        isFollowing = false;
        Marker.SetActive(false);
        TagGameController.NPCCount--;

        yield return new WaitForSeconds(1f);
        //close NPC lost panel and delete NPC
        HintPanel.SetActive(false);

        // destroy the parent
        GameObject.Destroy(this.transform.parent.gameObject);
    }
}
