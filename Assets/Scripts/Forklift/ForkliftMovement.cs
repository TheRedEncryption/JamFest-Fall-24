using UnityEngine;

public class ForkliftMovement : MonoBehaviour
{
    public float speed = 10f;
    public float turningSpeed = 20f;
    public float forkSpeed = 1f;
    public float forkHeight = 3f;


    private Rigidbody rb;
    private Transform fork;
    private float forkMinHeight;



    private Vector3 forward => Vector3.up; //remap due to mesh rotation


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fork = transform.Find("Body").Find("Fork").transform;
        forkMinHeight = fork.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 linearMovement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            linearMovement = transform.forward;
        } else if (Input.GetKey(KeyCode.S))
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
            if (fork.position.y < forkMinHeight + forkHeight)
            {
                forkMovement = 1;
            }

        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (fork.position.y > forkMinHeight)
            {
                forkMovement = -1;

            }
        }
            fork.Translate(transform.up * forkMovement * forkSpeed * Time.deltaTime, transform);
        rb.MovePosition(transform.position + linearMovement *speed *Time.deltaTime);
        Quaternion totationAsQuat = Quaternion.Euler(0, rotation * turningSpeed * Time.deltaTime, 0);
        rb.MoveRotation(transform.rotation * totationAsQuat);
    }
}
