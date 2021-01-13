using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FractalTree : MonoBehaviour
{
    public Material lineMat;

    float angle = Mathf.PI/ 2;

    public float angleDifference = Mathf.PI / 6;

    public float lengthLimit = 0.3f;

    public float lengthScalar = 0.7f;

    public Slider angleSlider;

    public Slider lengthLimitSlider;

    public Slider lengthScalarSlider;

    GameObject lineParent;

    Vector2 start = new Vector2(0, -7);

    private void Start()
    {
        lineParent = new GameObject("LineParent");

        angleSlider.minValue = 0;
        angleSlider.maxValue = Mathf.PI;
        angleSlider.value = Mathf.PI / 4;

        lengthLimitSlider.minValue = 0.2f;
        lengthLimitSlider.maxValue = 1;
        lengthLimitSlider.value = 0.3f;

        lengthScalarSlider.minValue = 0.1f;
        lengthScalarSlider.maxValue = 0.8f;
        lengthScalarSlider.value = 0.7f;

        Initialize();
    }

    public void Initialize()
    {
        angleDifference = angleSlider.value;

        lengthLimit = lengthLimitSlider.value;

        lengthScalar = lengthScalarSlider.value;

        foreach(Transform child in lineParent.transform)
        {
            Destroy(child.gameObject);
        }

        Branch(3, start, angle);
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        GameObject line = new GameObject("Line");
        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.material = lineMat;
        lr.numCapVertices = 0;
        lr.SetPositions(new Vector3[2] { start, end });

        line.transform.parent = GameObject.Find("LineParent").transform;
    }

    void Branch(float len, Vector2 start, float angle)
    {
        Vector2 angleVector;

        angleVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        Vector2 end = start + len * angleVector;
        DrawLine(start, end);

        if(len > lengthLimit)
        {
            Branch(len * lengthScalar, end, angle + angleDifference);
            Branch(len * lengthScalar, end, angle - angleDifference);
        }
    }
}
