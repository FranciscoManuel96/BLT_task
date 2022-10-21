using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float Height = 10f;
    public float radius = 10f;
    public float angle = 0f;
    public float rotationalSpeed = 36f;

    void Update()
    {

        float cameraX = target.position.x + (radius * Mathf.Cos(Mathf.Deg2Rad*angle));
        float cameraY = target.position.y + Height;
        float cameraZ = target.position.z + (radius * Mathf.Sin(Mathf.Deg2Rad * angle));

        transform.position = new Vector3(cameraX, cameraY, cameraZ);

        if (Input.GetKey(KeyCode.A))
        {
            angle = angle + rotationalSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            angle = angle - rotationalSpeed * Time.deltaTime;
        }

        transform.LookAt(target.position);
    }
}
