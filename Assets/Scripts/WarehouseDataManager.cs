using System.Collections.Generic;
using UnityEngine;

public class WarehouseDataManager : MonoBehaviour
{
    public GameObject[] broombas;
    public GameObject cameraSelector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PersistentData.SeenCode)
        {
            cameraSelector.SetActive(false);
        }

        if (PersistentData.broombaLocations.Count > 0)
        {
            for (int i = 0; i < broombas.Length; i++)
            {
                broombas[i].transform.position = PersistentData.broombaLocations[i];
            }
        }
    }

    public void OnExit()
    {
        PersistentData.broombaLocations = new List<Vector3>();
        foreach (GameObject go in broombas)
        {
            PersistentData.broombaLocations.Add(go.transform.position);
        }
    }
}
