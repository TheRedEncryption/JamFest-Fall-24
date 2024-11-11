using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarehouseDataManager : MonoBehaviour
{
    public GameObject[] broombas;
    public GameObject cameraSelector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PersistentData.SeenCode)
        {
            cameraSelector.SetActive(false);
        }
        else
        {
            BroombaManager.instance.SetActiveBroomba(GameObject.Find(PersistentData.lastbroomba));

        if (PersistentData.broombaLocations != null)
        {
            for (int i = 0; i < broombas.Length; i++)
            {
                broombas[i].transform.position = PersistentData.broombaLocations[i];
            }
        }
        }

       
        print("seen " + PersistentData.SeenCode);
        print("broombas " + PersistentData.broombaLocations?.Length);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            SceneManager.LoadScene("ConveyorBelts");
        }
    }
    public void OnExit()
    {

        PersistentData.broombaLocations = new Vector3[broombas.Length];
        PersistentData.lastbroomba = BroombaManager.instance.GetActiveBroomba().name;
        BroombaManager.instance.GetActiveBroomba().transform.position += new Vector3(2, 0, 0);
        for(int i = 0;i < broombas.Length;i++)
        {
            PersistentData.broombaLocations[i] = broombas[i].transform.position;
        }
    }
}
