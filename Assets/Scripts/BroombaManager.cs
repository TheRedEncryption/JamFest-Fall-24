using System.Collections.Generic;
using UnityEngine;

public class BroombaManager : MonoBehaviour
{

    public GameObject currentlyActiveBroomba;

    [SerializeField]
    List<GameObject> broombaList;

    void Start()
    {
        if (currentlyActiveBroomba != null)
        {
            SetActiveBroomba(currentlyActiveBroomba.name);
        }
    }

    // TODO: make debug GUI to Set Active Broomba
    public void SetActiveBroomba(string name)
    {
        foreach (GameObject broomba in broombaList)
        {
            Debug.Log(broomba.name + "? " + broomba.name.Equals(name));
            broomba.tag = broomba.name.Equals(name) ? "Player" : "Untagged";
            currentlyActiveBroomba = broomba;
        }
    }

}
