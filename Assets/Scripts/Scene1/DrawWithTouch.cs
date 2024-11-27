using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithTouch : MonoBehaviour
{
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector3> points = new List<Vector3>();

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            if (touch.phase == TouchPhase.Began)
            {
                CreateLine(touchPos);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                AddPoint(touchPos);
            }
        }
    }

    void CreateLine(Vector3 position)
    {
        currentLine = Instantiate(linePrefab, transform);
        points.Clear();
        points.Add(position);
        currentLine.positionCount = points.Count;
        currentLine.SetPositions(points.ToArray());
    }

    void AddPoint(Vector3 position)
    {
        if (Vector3.Distance(points[points.Count - 1], position) > 0.1f)
        {
            points.Add(position);
            currentLine.positionCount = points.Count;
            currentLine.SetPositions(points.ToArray());
        }
    }
}
