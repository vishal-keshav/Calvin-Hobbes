using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float playerspeed;
    private Rigidbody rb;
    private int points;
    public Text information;

    public Vir_jystick joystick;

    private Transform camera_rot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerspeed = 10.0f;
        points = 0;
        information.text = "Not Passed";
    }
    private void FixedUpdate()
    {
        ///float moveHorizontal = Input.GetAxis("Horizontal");
        ///float moveVertical = Input.GetAxis("Vertical");
        ///Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        ///Vector3 movement = Vector3.zero;
        ///movement.x = Input.acceleration.x;
        ///movement.z = Input.acceleration.y;

        Vector3 movement = Vector3.zero;
        movement.x = joystick.JHorizontal();
        movement.z = joystick.JVertical();

        ///movement = Rotatewithview(movement);

        if (movement.sqrMagnitude > 1)
            movement.Normalize();
        rb.AddForce(movement*playerspeed);
        information.text = "Passed" + Input.touchCount;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            points =points + 1;
        }
        if(points == 10)
        {
            information.text = "Passed";
        }
    }

    ///Camera rotation fintion
    private Vector3 Rotatewithview(Vector3 move_vector)
    {
        if (camera_rot != null)
        {
            Vector3 dir = camera_rot.TransformDirection(move_vector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * move_vector.magnitude;
        }
        else
        {
            camera_rot = Camera.main.transform;
            return move_vector;
        }
    }
}
