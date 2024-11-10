using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    /* =============== REFRENCES AND THE SUCH =============== */

    public static CameraController instance;
    public GameObject cameraContainer;

    private List<SwitchCameraButton> buttonList = new();

    /* =============== STATE VARIABLES =============== */


    private int currentCameraIndex = 0;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    void Start()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(BroombaManager.instance.GetActiveBroomba().GetComponent<Transform>().position, Camera.main.GetComponent<Transform>().position);
    }

    // Takes in the name of the camera and enables only that camera
    public void SetCamera(Camera newCam)
    {
        Camera oldCam = Camera.main;
        oldCam.enabled = false;
        newCam.enabled = true;

        
    }
}
