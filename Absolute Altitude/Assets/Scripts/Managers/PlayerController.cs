using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    [Range(1, 20)]  //this just creates a slider in the inspector
    public int distanceFromCamera;
    private float _playerPositionZ;
    public float minX, maxX, minY, maxY;
    public QuadShot[] quadShots;

    void Start()
    {
        //calling Camera.main is a shortcut for 
        //FindGameObjectsWithTag("MainCamera")
        //so you should avoid calling it every frame
        cam = Camera.main;
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1f, camDistance));
        _playerPositionZ = transform.position.z + camDistance;

        minX = bottomCorner.x + 0.5f;
        maxX = topCorner.x - 0.5f;
        minY = bottomCorner.y;
        maxY = topCorner.y - 3;
    }

    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //This will work for both perspective and orthographic cameras
        if (mousePosition.x > minX &&
            mousePosition.x < maxX &&
            mousePosition.y > minY &&
            mousePosition.y < maxY)
        {
            transform.position = mousePosition + new Vector3(0, 0.5f, _playerPositionZ);
        }

    }

    public void ActivateQuad()
    {      
        foreach (QuadShot quadShot in quadShots)
        {
            quadShot.Activate(true);
        }
    }
}