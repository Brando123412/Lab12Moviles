using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithSwipe : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0, 0, -touch.deltaPosition.x * 0.1f);
            }
        }
    }
}
