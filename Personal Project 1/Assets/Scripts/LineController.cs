using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] Transform[] linePoints;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        lineRenderer.SetPosition(0, linePoints[0].position);
        lineRenderer.SetPosition(1, linePoints[1].position);
    }
}
