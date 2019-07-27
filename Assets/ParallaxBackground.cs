using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour{

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
        layers = new Transform[transform.childCount];

        for (int i=0; i<transform.childCount; i++)
            layers[i] = transform.GetChild(i);
        

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        float backgroundDepth = 1/transform.position.z;
        transform.position = new Vector3(transform.position.x - (deltaX * parallaxSpeed* backgroundDepth),0,transform.position.z) ;
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
        layers[rightIndex].position = new Vector3 (layers[leftIndex].position.x - backgroundSize,0, transform.position.z);
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




    // Update is called once per frame

}
