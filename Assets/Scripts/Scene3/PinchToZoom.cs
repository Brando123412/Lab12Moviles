using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    private Camera cam;
    private float minZoom = 5f;
    private float maxZoom = 15f;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            float prevMagnitude = (touch1PrevPos - touch2PrevPos).magnitude;
            float currentMagnitude = (touch1.position - touch2.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
    }

    void Zoom(float increment)
    {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, minZoom, maxZoom);
    }
}
