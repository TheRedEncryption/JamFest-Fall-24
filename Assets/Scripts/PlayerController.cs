using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    public float degreesPerSecond;

    public BroombaHomePoint currentHomePoint;

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

        //// All of the following are debug, the actual camera switching will probably be done in some other scipt

        //if (Input.GetKey(KeyCode.E))
        //{
        //    cameraController.SetCamera("Cam1");
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    cameraController.SetCamera("Broomba Camera");
        //}
        //if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    cameraController.SetCamera("Cam2");
        //}
    }

    private void Move()
    {
        Vector3 finalMovement = transform.forward * speed;

        if (currentHomePoint != null)
        {

            finalMovement += currentHomePoint.GetInfluence(transform.position) * speed;
            
        }
        rb.MovePosition(finalMovement * Time.deltaTime + transform.position);
    }

    //private void OnDrawGizmos()
    //{

    //    float dist = Utils.XZDist(transform.position, currentHomePoint.position);

    //    float strength = ((dist - slowdownRange) / (maxRange - slowdownRange));
    //    Vector3 distanceInfluence = (transform.position - currentHomePoint.position).XZVec().normalized * speed * strength;
    //    Gizmos.DrawLine(transform.position, transform.position + distanceInfluence);

    //}



}
