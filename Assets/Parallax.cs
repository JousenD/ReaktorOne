using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float backgroundSize = 19.2f;
    [SerializeField] float parallaxSpeed = 10f;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone;
    private int leftIndex = 0;
    private int rightIndex = 2;


    private float lastCameraX;



    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = transform.position.x;

        foreach (Transform childTransform in transform)
        {
            layers = new Transform[childTransform.childCount];

            for (int i = 0; i < childTransform.childCount; i++)
                layers[i] = childTransform.GetChild(i);


            leftIndex = 0;
            rightIndex = layers.Length - 1;
        }
        


    }

    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;

        foreach (Transform childtransform in transform)
        {
            float backgroundDepth = 1 / childtransform.position.z;
            childtransform.position = new Vector3(childtransform.position.x - (deltaX * parallaxSpeed * backgroundDepth), 0, childtransform.position.z);
        }
        
        lastCameraX = cameraTransform.position.x;

        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            ScrollLeft();

        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            ScrollRight();

    }


    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        //layers[rightIndex].localPosition += Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        layers[rightIndex].position = new Vector3(layers[leftIndex].position.x - backgroundSize, 0, transform.position.z);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;

    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        //layers[leftIndex].localPosition += Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        layers[leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize, 0, transform.position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
