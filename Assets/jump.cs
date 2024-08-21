using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MonoBehaviour
{
    private Rigidbody rb;
    private bool shouldJump = false;

    private int score = 0;
    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if(score == 5)
        {
            SceneManager.LoadScene(sceneIndex + 1);
        }

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldJump)
        {
            Jump();
            shouldJump = false;
        }
    }



    void Jump()
    {
        Vector3 launchDir = new Vector3(10f, 10f, 10f);
        rb.AddForce(launchDir.normalized * 10f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible")) { other.gameObject.SetActive(false); score++; }
    }

}
