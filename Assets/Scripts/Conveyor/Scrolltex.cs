using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour {

    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    Renderer rendererMan;

    void Start ()
    {
        rendererMan = GetComponent<Renderer>();
    }
    void Update() {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        rendererMan.material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
        Debug.Log(rendererMan.material.GetTextureOffset("_MainTex"));
        

    }
}