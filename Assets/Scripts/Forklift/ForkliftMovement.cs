using UnityEngine;

public class ForkliftMovement : MonoBehaviour
{
    public float speed = 10f;
    public float turningSpeed = 20f;
    public float forkSpeed = 1f;
    public float forkHeight = 3f;


    private Rigidbody rb;
    private Transform fork;
    private float currentHeight;


    private Vector3 forward => Vector3.up; //remap due to mesh rotation


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fork = transform.Find("Body").Find("Fork").transform;
        currentHeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tag != "Player") return;
        HandleMove();
    }

    void HandleMove()
    {
        Vector3 linearMovement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            linearMovement = transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            linearMovement = -transform.forward;
        }

        float rotation = 0;
        if (Input.GetKey(KeyCode.D))
        {
            rotation = turningSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotation = -turningSpeed;
        }

        float forkMovement = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            if (currentHeight < forkHeight)
            {
                forkMovement = 1;
                if(currentHeight <= 0.1)
                {
                    if (Physics.Raycast(fork.position, Vector3.up, out var collision, 1))
                    {
                        collision.rigidbody.transform.SetParent(fork.transform, false);
                    }
                }

            }

        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (currentHeight > 0)
            {
                forkMovement = -1;

            }
        }
        fork.Translate(transform.up * forkMovement * forkSpeed * Time.deltaTime, transform);
        currentHeight += forkMovement * forkSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + linearMovement * speed * Time.deltaTime);
        Quaternion totationAsQuat = Quaternion.Euler(0, rotation * turningSpeed * Time.deltaTime, 0);
        rb.MoveRotation(transform.rotation * totationAsQuat);
    }
}
