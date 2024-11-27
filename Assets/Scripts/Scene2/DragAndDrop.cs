using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject selectedObject;
    private Vector3 offset;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic o toque inicial
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject;
                offset = selectedObject.transform.position - (Vector3)mousePosition;
            }
        }

        if (Input.GetMouseButton(0) && selectedObject != null) // Arrastra el objeto
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            selectedObject.transform.position = (Vector3)mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0)) // Suelta el objeto
        {
            selectedObject = null;
        }
    }
}
