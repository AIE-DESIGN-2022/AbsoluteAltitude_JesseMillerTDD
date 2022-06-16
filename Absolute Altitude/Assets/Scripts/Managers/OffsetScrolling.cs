using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer _renderer;
    private Vector2 _savedOffset;
   
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(0, x);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    public void ChangeBG(Material materialToChangeTo) 
    {
        _renderer.material = materialToChangeTo;
    }
}
