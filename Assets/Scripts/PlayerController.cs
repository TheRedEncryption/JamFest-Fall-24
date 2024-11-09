using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    public float degreesPerSecond;

    public Transform currentHomePoint;
    public float slowdownRange = 4;
    public float maxRange = 5;
    /* TODO: FIND OUT A WAY TO MAKE THE PLAYER COLLIDE WITH THE SURROUNDING BOXES WITHOUT AFFECTING THE BOXES
    (AS OF CURRENTLY, THE BOXES FALL DOWN) */

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, degreesPerSecond * -1 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
        }
    }

    private void Move()
    {
        Vector3 finalMovement = transform.forward * speed;

        if (currentHomePoint != null)
        {
            float dist = XZDist(transform.position, currentHomePoint.position);
            if (dist > slowdownRange)
            {
                float strength = ((dist - slowdownRange) / (maxRange - slowdownRange));
                Vector3 distanceInfluence = XZVec(currentHomePoint.position - transform.position).normalized * speed * strength;

                finalMovement += distanceInfluence;
            }
        }
        rb.MovePosition(finalMovement * Time.deltaTime + transform.position);
    }

    private void OnDrawGizmos()
    {
        if (currentHomePoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(currentHomePoint.position, slowdownRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(currentHomePoint.position, maxRange);

        float dist = XZDist(transform.position, currentHomePoint.position);

        float strength = ((dist - slowdownRange) / (maxRange - slowdownRange));
        Vector3 distanceInfluence = XZVec(transform.position - currentHomePoint.position).normalized * speed * strength;
        Gizmos.DrawLine(transform.position, transform.position + distanceInfluence);
    }

    public static Vector3 XZVec(Vector3 v)
    {
        return new Vector3(v.x, 0, v.z);
    }

    public static float XZDist(Vector3 v1, Vector3 v2)
    {
        return Vector3.Distance(XZVec(v1), XZVec(v2));
    }

}
