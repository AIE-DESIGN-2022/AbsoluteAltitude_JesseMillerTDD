using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer Renderer;
    private Vector2 savedOffset;

    void Start()
    {
        Renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(0, x);
        Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}
