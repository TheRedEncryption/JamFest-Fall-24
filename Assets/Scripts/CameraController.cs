using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject; // Player reference

    [SerializeField]
    private BroombaManager broombaManager; // Broomba Manager reference

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
            bool camEquivalent = camera.name.Equals(name);
            Debug.Log(camera.name + "? " + camEquivalent);
            camera.enabled = camEquivalent;
            camera.tag = camEquivalent ? "MainCamera" : "Untagged";
            camera.gameObject.GetComponent<AudioListener>().enabled = camEquivalent;
        }
    }

    // Takes a camera and enables only that camera (marked for deletion)
    // public void SetCamera(Camera otherCamera)
    // {
    //     foreach (Camera camera in cameraList)
    //     {
    //         Debug.Log(camera.name + "? " + camera.Equals(otherCamera));
    //         camera.enabled = camera.Equals(otherCamera);
    //         camera.tag = camera.Equals(otherCamera) ? "MainCamera" : "Untagged";
    //         GetEligibleCameras();
    //     }
    // }

    // note that if a camera becomes ineligible due to whatever reason, and it is still active,
    // then display static until player chooses an eligible camera
    // i anticipate that this function might be on the costlier side, so
    // run it only when player clicks to change view
    List<Camera> GetEligibleCameras()
    {
        // TODO: get a list of eligible cameras (current broomba + cameras in range(?) of current broomba)
        return null;
    }

}
