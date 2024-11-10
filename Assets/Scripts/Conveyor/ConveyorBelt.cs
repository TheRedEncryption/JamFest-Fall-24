using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public float travelSpeed = 1.0f;
    private float dir = 1;
    private List<GameObject> onBelt;

    private bool IsVertical => Mathf.Abs(Vector3.Dot(transform.up.normalized, Vector3.forward)) < 0.5;

    private void OnDrawGizmos()
    {
        //forward
        Gizmos.color = IsVertical ? Color.yellow : Color.red;
        Gizmos.DrawLine(transform.position, transform.position+transform.forward);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onBelt = new List<GameObject>();
    }

    // Fixed update for physics
    void FixedUpdate()
    {


        if (IsVertical)
        {
            if (Input.GetKey(KeyCode.W))
            {
                dir = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir = -1;
            }
        } else
        {
            if (Input.GetKey(KeyCode.A))
            {
                dir = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir = -1;
            }
        }
                // For every item on the belt, add force to it in the direction given
        for (int i = 0; i <= onBelt.Count - 1; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().linearVelocity = transform.up * travelSpeed *dir;
        }
    }

    // When something collides with the belt
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        onBelt.Add(collision.gameObject);
    }

    // When something leaves the belt
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Uncollided");
        onBelt.Remove(collision.gameObject);
    }
}
