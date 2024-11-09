using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject playerObject;
    Transform playerTransform;
    Rigidbody rb;
    public float speed;
    public float degreesPerSecond;

    void Start()
    {
        playerTransform = playerObject.GetComponent<Transform>();
        rb = playerObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 tempVect = playerTransform.forward;
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // TODO: replace with rb.MoveRotation
            playerTransform.Rotate(0, degreesPerSecond * -1 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // TODO: replace with rb.MoveRotation
            playerTransform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
        }
    }
}
