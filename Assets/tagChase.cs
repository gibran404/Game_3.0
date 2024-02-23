using System.Collections;
using UnityEngine;

public class TagChase : MonoBehaviour
{
    public float followSpeed = 7f;
    private Transform target;
    private bool isFollowing = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isFollowing && other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger. Press 'E' to start following.");
            //update hint panel
        }
        if (isFollowing && other.CompareTag("Player"))
        {
            isFollowing = false;
            Debug.Log("Player has been caught. Game over.");
            //update hint panel
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!isFollowing && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(StartFollowing());
            //upadte hunt panel "RUN!"
        }
    }

    void OnTriggerExit(Collider other)
    {   
        //disable hint panel

    }

    IEnumerator StartFollowing()
    {
        Debug.Log("Started following the player.");
        yield return new WaitForSeconds(1f);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isFollowing = true;
    }

    void Update()
    {
        if (isFollowing && target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }
}
