using System.Collections.Generic;
using UnityEngine;

public class BroombaManager : MonoBehaviour
{
    public static BroombaManager instance;
    [SerializeField]
    private GameObject currentlyActiveBroomba;

    [SerializeField]
    List<GameObject> broombaList;

    [SerializeField]
    private float hackDistance = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (currentlyActiveBroomba != null)
        {
            SetActiveBroomba(currentlyActiveBroomba);
        }
    }

    public void SetActiveBroomba(GameObject broomba)
    {
        if(currentlyActiveBroomba != null)
        {
            currentlyActiveBroomba.tag = "Untagged";
        }
        broomba.tag = "Player";
        currentlyActiveBroomba = broomba;
         SwitchCameraButton.SetCamera(currentlyActiveBroomba.GetComponentInChildren<Camera>());
       
        
    }

    public GameObject GetActiveBroomba()
    {
        return currentlyActiveBroomba;
    }

    public void HackNearestEligibleBroomba()
    {
        GameObject newBroomba = currentlyActiveBroomba;
        float minDistance = float.MaxValue;

        foreach (GameObject broomba in broombaList)
        {
            if (currentlyActiveBroomba.name.Equals(broomba.name)) continue;

            float currentDistance = (currentlyActiveBroomba.transform.position - broomba.transform.position).magnitude;

            if (currentDistance < minDistance)
            {
                newBroomba = broomba;
                minDistance = currentDistance;
            }

        }

        if (minDistance <= hackDistance)
        {
            SetActiveBroomba(newBroomba);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(currentlyActiveBroomba.transform.position, hackDistance);

    }

}
