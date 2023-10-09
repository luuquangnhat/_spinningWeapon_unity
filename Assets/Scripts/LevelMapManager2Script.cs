using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapManager2Script : MonoBehaviour
{
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 20;

    public GameObject StartPoint;
    public GameObject EndPoint;

    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;

    }

    void Update()
    {
        LineRenderer lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        //lineRenderer.widthMultiplier = 0.2f;
        //lineRenderer.positionCount = lengthOfLineRenderer;
        lineRenderer.SetPosition(0, StartPoint.transform.position);
        lineRenderer.SetPosition(1, EndPoint.transform.position);
    }
}
