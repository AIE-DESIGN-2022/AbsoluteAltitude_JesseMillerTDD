using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    [Range(1, 20)]  //this just creates a slider in the inspector

    public int distanceFromCamera;
    private float _playerPositionZ;
    public float minX, maxX, minY, maxY;

    public Vector2 screenBounds;
    public Vector2 mousePos;
    private float objectWidth;
    private float objectHeight;

    public QuadShot[] quadShots;

    void Start()
    {
        //calling Camera.main is a shortcut for 
        //FindGameObjectsWithTag("MainCamera")
        //so you should avoid calling it every frame
        cam = Camera.main;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));

    }

    void LateUpdate()
    {

        Vector3 viewPos = cam.ScreenToWorldPoint(Input.mousePosition);
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1) + 0.5f, screenBounds.x - 0.5f);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y - 3.5f);
        transform.position = new Vector3(viewPos.x + 0.25f, viewPos.y + 0.5f, transform.position.z);
    }

    public void ActivateQuad()
    {      
        foreach (QuadShot quadShot in quadShots)
        {
            quadShot.Activate(true);
        }
    }
}