using UnityEngine;

public class SeenCodeFunc : MonoBehaviour
{
    private void Start()
    {
        SeeCode();
    }
    public void SeeCode()
    {
        PersistentData.SeenCode = true;
    }
}
