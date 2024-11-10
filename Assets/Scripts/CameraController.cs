using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    /* =============== REFRENCES AND THE SUCH =============== */

    [SerializeField]
    private BroombaManager broombaManager; // Broomba Manager reference

    [SerializeField]
    private GameObject CamContainer;

    private List<Camera> cameraList = new(); // List of all security cameras present in the game

    /* =============== STATE VARIABLES =============== */

    public bool ViewingBroombaCam { get; private set; }

    private int currentCameraIndex = 0;

    void Start()
    {
        // Takes all the Camera objects in the game and puts them in this list
        cameraList.AddRange(CamContainer.GetComponentsInChildren<Camera>());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(broombaManager.GetActiveBroomba().GetComponent<Transform>().position, Camera.main.GetComponent<Transform>().position);
    }

    // Takes in the name of the camera and enables only that camera
    public void SetCamera(string name)
    {
        foreach (Camera camera in cameraList)
        {
            bool camEquivalent = camera.name.Equals(name);
            camera.enabled = camEquivalent;
            camera.tag = camEquivalent ? "MainCamera" : "Untagged";
            camera.gameObject.GetComponent<AudioListener>().enabled = camEquivalent;
        }
    }

    // Takes a camera and enables only that camera
    public void SetCamera(Camera otherCamera)
    {
        foreach (Camera camera in cameraList)
        {
            camera.enabled = false;
            camera.tag = "Untagged";
        }

        otherCamera.enabled = true;
        otherCamera.tag = "MainCamera";
    }

    public Camera GetActiveBroombaCamera()
    {
        return broombaManager.GetActiveBroomba().GetComponentInChildren<Camera>();
    }

    public void BroombaView()
    {
        SetCamera(GetActiveBroombaCamera());
        ViewingBroombaCam = true;
    }

    public void CameraView()
    {
        SetCamera(cameraList[currentCameraIndex]);
        ViewingBroombaCam = false;
    }

    public void CycleCameraForwards()
    {
        if (currentCameraIndex == cameraList.Count - 1)
        {
            currentCameraIndex = 0;
        }
        else
        {
            currentCameraIndex++;
        }

        SetCamera(cameraList[currentCameraIndex]);
    }

    public void CycleCameraBackwards()
    {
        if (currentCameraIndex == 0)
        {
            currentCameraIndex = cameraList.Count - 1;
        }
        else
        {
            currentCameraIndex--;
        }

        SetCamera(cameraList[currentCameraIndex]);
    }

    /*
    
    the entire idea is that there are two modes, broomba view and camera view. if you hack a broomba while in broomba view (check using ViewingBroombaCam)
    then the camera changes otherwise if you are watching through a security camera, then stay the same. when in broomba view then the arrows to switch cameras
    should not appear, otherwise when in security camera view then the arrows will appear
    
    */

}
