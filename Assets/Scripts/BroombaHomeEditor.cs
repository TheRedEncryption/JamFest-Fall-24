using UnityEngine;

[ExecuteInEditMode]
public class BroombaHomeEditor : MonoBehaviour
{
    BroombaHomePoint m_Point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Point = GetComponent<BroombaHomePoint>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * 2 * m_Point.maxRange + Vector3.one*0.65f;

    }
}
