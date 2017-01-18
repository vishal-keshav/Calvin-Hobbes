using UnityEngine;
using System.Collections;

public class touch_testing : multi_touch
{

    public float rotateSpeed = 20.0f;
    private float pitch = 0.0f;
    private float yaw = 0.0f;

    void Update()
    {
        Check_touches();
    }

    public override void OnTouchMovedAnywhere()
    {
        pitch += Input.GetTouch(0).deltaPosition.y * rotateSpeed * Time.deltaTime;
        yaw += Input.GetTouch(0).deltaPosition.x * rotateSpeed * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -60, 60);
        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
