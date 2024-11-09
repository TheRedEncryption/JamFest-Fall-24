using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject playerObject;
    Transform playerTransform;
    Rigidbody rb;
    public float speed;
    public float degreesPerSecond;

    /* TODO: FIND OUT A WAY TO MAKE THE PLAYER COLLIDE WITH THE SURROUNDING BOXES WITHOUT AFFECTING THE BOXES
    (AS OF CURRENTLY, THE BOXES FALL DOWN) */

    void Start()
    {
        playerTransform = playerObject.GetComponent<Transform>();
        rb = playerObject.GetComponent<Rigidbody>();
    }

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
            playerTransform.Rotate(0, degreesPerSecond * -1 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
        }
    }
}
