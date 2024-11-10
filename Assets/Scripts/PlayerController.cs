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

    public CameraController cameraController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!CompareTag("Player")) return;

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

        // All of the following are debug, the actual camera switching will probably be done in some other scipt

        if (Input.GetKey(KeyCode.E))
        {
            cameraController.SetCamera("Cam1");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cameraController.SetCamera("Broomba Camera");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            cameraController.SetCamera("Cam2");
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
