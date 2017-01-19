using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    private float r_speed = 200.0f;
    private float distance;

    private float pitch = 0.0f;
    private float yaw = 0.0f;

    void Start()
    {
        //offset = transform.position - player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
    }
    void LateUpdate()
    {
        if (Input.touches.Length <= 0)
        {
            transform.LookAt(player.transform);
            transform.position = (transform.position - player.transform.position).normalized * distance + player.transform.position;
        }
        else
        {

            transform.LookAt(player.transform);
            pitch = Input.GetTouch(0).deltaPosition.y;
            yaw = Input.GetTouch(0).deltaPosition.x;
            //offset = transform.position - player.transform.position;
            transform.RotateAround(player.transform.position, new Vector3(pitch, yaw, 0), Time.deltaTime * r_speed);
            transform.position = (transform.position - player.transform.position).normalized * distance + player.transform.position;
            //transform.position = player.transform.position + offset;
        }
        
        ///transform.position = player.transform.position + offset;
    }
}
