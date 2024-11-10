using System.Collections.Generic;
using UnityEngine;

public class BroombaManager : MonoBehaviour
{

    [SerializeField]
    private GameObject currentlyActiveBroomba;

    [SerializeField]
    List<GameObject> broombaList;

    [SerializeField]
    private float hackDistance = 1.5f;

    void Start()
    {
        if (currentlyActiveBroomba != null)
        {
            SetActiveBroomba(currentlyActiveBroomba.name);
        }
    }

    public void SetActiveBroomba(string name)
    {
        foreach (GameObject broomba in broombaList)
        {
            bool equivalent = broomba.name.Equals(name);

            Debug.Log(broomba.name + "? " + equivalent);
            broomba.tag = equivalent ? "Player" : "Untagged";

            if (equivalent)
            {
                currentlyActiveBroomba = broomba;
            }
        }
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
            SetActiveBroomba(newBroomba.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(currentlyActiveBroomba.transform.position, hackDistance);

    }

}
