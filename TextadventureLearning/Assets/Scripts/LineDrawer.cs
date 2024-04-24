using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 previousPosition;

    [SerializeField] private float minDistance = 0.1f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            currentPosition.z = 1;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
                previousPosition = currentPosition;
            }
        }
    }
}
