using System.Collections.Generic;
using UnityEngine;

public class BroombaManager : MonoBehaviour
{

    [SerializeField]
    List<GameObject> broombaList;

    public void SetActiveBroomba(string name)
    {
        foreach (GameObject broomba in broombaList)
        {
            Debug.Log(broomba.name + "? " + broomba.name.Equals(name));
            broomba.tag = broomba.name.Equals(name) ? "Player" : "Untagged";
        }
    }
}
