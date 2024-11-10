using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
public class BroombaHomePoint : MonoBehaviour
{

    public float slowdownRange = 4;
    public float maxRange = 5;

    private Material mat;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        BroombaManager manager = GameObject.Find("BroombaManager").GetComponent<BroombaManager>();
        if (manager == null || manager.GetActiveBroomba() == null || manager.GetActiveBroomba().GetComponent<PlayerController>().currentHomePoint != this) {
            mat.color = mat.color.WithAlpha(0);
            return;
        }
        PlayerController player = manager.GetActiveBroomba().GetComponent<PlayerController>();
        if (Utils.XZDist(transform.position, player.transform.position) > slowdownRange )
        {
            float str = Strength(Utils.XZDist(transform.position, player.transform.position));
            mat.color = mat.color.WithAlpha(str);
            
        }
    }

    public Vector3 GetInfluence(Vector3 position)
    {
        float dist = Utils.XZDist(transform.position, position);
        if (dist < slowdownRange)
        {
            return Vector3.zero;
        }

        float strength = (dist - slowdownRange) / (maxRange - slowdownRange);
        return (transform.position - position).normalized * strength;
    }

    public float Strength (float dist) => (dist - slowdownRange)/ (maxRange - slowdownRange);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, slowdownRange );

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRange);

        float dist = Utils.XZDist(transform.position, transform.position);

    }
}
