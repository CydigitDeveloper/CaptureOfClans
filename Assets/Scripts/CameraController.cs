using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera sceneCamera;
    public float panBorderThickness = 10f;
    public float panSpeed = 10f;
    public float scrollSpeed = 10f;
    public float minY, maxY;

    private void Start()
    {
        sceneCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        //if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        //{
        //    transform.Translate(transform.forward * panSpeed * Time.deltaTime, Space.World);
        //}
        //else if (Input.mousePosition.y <= panBorderThickness)
        //{
        //    transform.Translate(-transform.forward * panSpeed * Time.deltaTime, Space.World);
        //}
        //else if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        //{
        //    transform.Translate(transform.right * panSpeed * Time.deltaTime, Space.World);
        //}
        //else if (Input.mousePosition.x <= panBorderThickness)
        //{
        //    transform.Translate(-transform.right * panSpeed * Time.deltaTime, Space.World);
        //}

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        sceneCamera.orthographicSize -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        sceneCamera.orthographicSize = Mathf.Clamp(sceneCamera.orthographicSize, minY, maxY);
    }
}
