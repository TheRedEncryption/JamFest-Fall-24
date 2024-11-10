using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject; // Player reference
    [SerializeField]
    private List<Camera> cameraList = new(); // List of all Cameras present in the game

    void Start()
    {
        // Takes all the Camera objects in the game and puts them in this list
        cameraList.AddRange(FindObjectsByType<Camera>(FindObjectsSortMode.None));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(playerObject.GetComponent<Transform>().position, Camera.main.GetComponent<Transform>().position);
    }

    // Takes in the name of the camera and enables only that camera
    public void SetCamera(string name)
    {
        foreach (Camera camera in cameraList)
        {
            Debug.Log(camera.name + "? " + camera.name.Equals(name));
            camera.enabled = camera.name.Equals(name);
            camera.tag = camera.name.Equals(name) ? "MainCamera" : "Untagged";
        }
    }

}
