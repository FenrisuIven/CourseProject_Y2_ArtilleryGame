using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

public class SS_T_Generator : MonoBehaviour
{
    public SpriteShapeController shape;
    private int amountOfPoints = 10;
    
    private void Start()
    {
        shape.spline.SetPosition(2, shape.spline.GetPosition(2) + new Vector3Int((int)(4f * Camera.main.orthographicSize), 0));
        shape.spline.SetPosition(3, shape.spline.GetPosition(3) + new Vector3Int((int)(4f * Camera.main.orthographicSize), 0));
        
        int ss_Width = Mathf.Abs(Mathf.FloorToInt(shape.spline.GetPosition(1).x - shape.spline.GetPosition(2).x));

        for (int i = 0; i < amountOfPoints; i++)
        {
            float xPos = shape.spline.GetPosition(i + 1).x + (float)(ss_Width / amountOfPoints);
            float yPos = Mathf.Abs(Mathf.PerlinNoise(xPos + Random.Range(0f, 1f), 0)) * 5;
            
            if (Math.Abs(yPos - shape.spline.GetPosition(shape.spline.GetPointCount() - 3).y) > 1)
            {
                yPos /= 2f;
            }
            
            shape.spline.InsertPointAt(i + 2, new Vector3(xPos, yPos, 0 ));
        }
        for (int i = 2; i < shape.spline.GetPointCount() - 2; i++)
        {
            shape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            shape.spline.SetLeftTangent(i, new Vector3(-0.5f, 0));
            shape.spline.SetRightTangent(i, new Vector3(0.5f, 0));
        }

    }
}
