using UnityEngine;

public class DroneController : MonoBehaviour
{
    Rigidbody rb;
    public float maxSpeed = 5;
    public float accel = 0.1f;
    public float maxTilt = 15f;
    private float speed = 0;
    Transform propellers;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        propellers = transform.Find("Drone Propellers");
        
    }

    private void Update()
    {
        propellers.Rotate(new Vector3(0, 0, speed));
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            speed = Mathf.Clamp(speed + accel*Time.fixedDeltaTime, 0, maxSpeed);
        } else if (Input.GetKey(KeyCode.E))
        {
            speed = Mathf.Clamp(speed - accel * Time.fixedDeltaTime, 0, maxSpeed);
        }

        Vector3 tilt = Vector3.zero;
        tilt.y = transform.rotation.y;

        //tilt
        if (Input.GetKey(KeyCode.W))
        {
            tilt.x += maxTilt;
        }
        if (Input.GetKey(KeyCode.S))
        {
            tilt.x -= maxTilt;
        }
        if (Input.GetKey(KeyCode.A))
        {
            tilt.z -= maxTilt;
        }
        if (Input.GetKey(KeyCode.D))
        {
            tilt.z += maxTilt;
        }

        rb.MoveRotation(Quaternion.Euler(tilt));

        //move up(local)
        Vector3 tiltedUp = rb.transform.up;
        rb.AddForce(tiltedUp*speed);
    }
}
