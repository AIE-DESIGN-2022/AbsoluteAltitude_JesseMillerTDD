using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    [Range(1, 20)]  //this just creates a slider in the inspector
    public int distanceFromCamera;
    private float playerPositionZ;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        //calling Camera.main is a shortcut for 
        //FindGameObjectsWithTag("MainCamera")
        //so you should avoid calling it every frame
        cam = Camera.main;
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        playerPositionZ = transform.position.z + camDistance;

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }

    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //This will work for both perspective and orthographic cameras
        if (mousePosition.x > minX &&
            mousePosition.x < maxX &&
            mousePosition.y > minY &&
            mousePosition.x < maxY)
        {
            transform.position = mousePosition + new Vector3(0, 0.5f, playerPositionZ);
        }

    }
}