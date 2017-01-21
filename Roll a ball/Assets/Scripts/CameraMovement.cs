using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public GameObject player;
    public Transform player_transform;
    private Vector3 offset;
    private float r_speed = 200.0f;
    private float distance;


    private float pitch = 0.0f;
    private float yaw = 0.0f;

    private float width;
    private float height;

    void Start()
    {
        //offset = transform.position - player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        width = Screen.width;
        height = Screen.height;
    }
    void LateUpdate()
    {
        if (Input.touches.Length <= 0)
        {
            //Vector3 dir = new Vector3(0, 0, -5);
            //pitch = pitch +  Input.GetAxis("Horizontal")*2;
            //yaw = yaw + Input.GetAxis("Vertical")*1;

            //Quaternion rota = Quaternion.Euler(pitch, yaw, 0);
            ///transform.RotateAround(player.transform.position, new Vector3(pitch, yaw, 0), Time.deltaTime * r_speed);
            //transform.position = player_transform.position + rota*dir;
            transform.LookAt(player.transform);
            transform.position = (transform.position - player.transform.position).normalized * distance + player.transform.position;
        }
        else
        {
            //transform.LookAt(player.transform);
            for(int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Moved && Input.GetTouch(i).position.x < (width / 10)*7)
                {
                    Vector3 dir = new Vector3(0, 0, -5);
                    pitch = pitch + Input.GetTouch(i).deltaPosition.y*1;
                    yaw = yaw + Input.GetTouch(i).deltaPosition.x*1;
                    //pitch = Input.GetAxis("Horizontal");
                    //yaw = Input.GetAxis("Vertical");

                    Quaternion rota = Quaternion.Euler(pitch, yaw, 0);
                    ///transform.RotateAround(player.transform.position, new Vector3(pitch, yaw, 0), Time.deltaTime * r_speed);
                    transform.position = player_transform.position + rota*dir;
                    break;
                }
            }
            transform.LookAt(player.transform);
            transform.position = (transform.position - player.transform.position).normalized * distance + player.transform.position;
        }
        
        ///transform.position = player.transform.position + offset;
    }
}
