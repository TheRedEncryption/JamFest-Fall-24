using UnityEngine;
using UnityEngine.UI;


public class SwitchCameraButton : MonoBehaviour
{
    public bool switchToRobot;
    public Camera cameraToSwitchTo;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => SetCamera(switchToRobot ? null : cameraToSwitchTo));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Takes in the name of the camera and enables only that camera
    public static void SetCamera(Camera newCam)
    {
        Camera oldCam = Camera.main;
        if (newCam == null)
        {
            newCam = BroombaManager.instance.GetActiveBroomba().GetComponentInChildren<Camera>();
        }
        oldCam.enabled = false;
        newCam.enabled = true;


    }
}
