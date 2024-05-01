using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject platformPrefab;
    private bool reachedEnd = false;
    private bool clonedObj = false;
    private GameObject currentPlatform;
    // Start is called before the first frame update
    void Start()
    {
        //currentPlatform = platformPrefab.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedEnd)
        {
            // Handle movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            if (clonedObj)
            {
                reachedEnd = true;
                Debug.Log("Ball landed on platform");
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;

            }
            

        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {

            if (clonedObj)
            {
                Destroy(currentPlatform);
                clonedObj = false;
                Debug.Log("Ball leaving platform collider");
            }

            GenerateNewPlatform();

        }

    }

    void GenerateNewPlatform()
    {
        Vector3 newPlatformPosition = transform.position + new Vector3(0f, -1.0f, 0f); // Adjust as needed
        currentPlatform = Instantiate(platformPrefab, newPlatformPosition, Quaternion.identity);
        clonedObj = true;
        reachedEnd = false;

    }

}

