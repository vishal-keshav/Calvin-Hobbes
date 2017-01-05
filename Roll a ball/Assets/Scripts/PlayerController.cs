using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float playerspeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerspeed = 10.0f;
    }
    private void FixedUpdate()
    {
        ///float moveHorizontal = Input.GetAxis("Horizontal");
        ///float moveVertical = Input.GetAxis("Vertical");
        ///Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
        Vector3 movement = Vector3.zero;
		movement.x = Input.acceleration.x;
		movement.z = Input.acceleration.y;
		if (movement.sqrMagnitude > 1)
            movement.Normalize();
        rb.AddForce(movement*playerspeed);
    }
}
