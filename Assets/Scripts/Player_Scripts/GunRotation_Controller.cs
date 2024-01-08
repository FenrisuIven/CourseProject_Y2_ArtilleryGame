using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GunRotation_Controller : MonoBehaviour
{
    public string gunObjName;
    public Vector3 origin;
    
    GameObject gun;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = origin - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject.Find(gunObjName).transform.right = direction;    
        }
    }
}
