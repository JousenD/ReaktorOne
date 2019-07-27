using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Camera camera;
    Animator myAnimator;


    [SerializeField] float movementSpeed = 10f;

    // Use this for initialization
    void Start () {
        camera = FindObjectOfType<Camera>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 cameraPosition = camera.transform.position;
        Vector3 newCameraPosition = new Vector3(transform.position.x, cameraPosition.y, cameraPosition.z);
        camera.transform.position = newCameraPosition;

        ProcessPlayerMovementAndAnimation();
    }

    private void ProcessPlayerMovementAndAnimation()
    {
        if (Input.GetKey("d"))
        {
            MoveToRight();
        }
        else if (Input.GetKey("a"))
        {
            MoveToLeft();
        }
        else
        {
            myAnimator.SetBool("Walking", false);
        }
    }

    private void MoveToLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        myAnimator.SetBool("Walking", true);
        transform.position = transform.position - Vector3.right * Time.deltaTime * movementSpeed;
        ProcessRunning();
    }

    private void ProcessRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetBool("Running", true);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
    }

    private void MoveToRight()
    {
            transform.localScale = new Vector3(1, 1, 1);
            myAnimator.SetBool("Walking", true);
            transform.position = transform.position + Vector3.right * Time.deltaTime * movementSpeed;
            ProcessRunning();
    }
}
