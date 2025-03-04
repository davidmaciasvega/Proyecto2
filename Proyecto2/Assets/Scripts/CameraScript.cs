using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public GameObject Profesor;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Profesor.transform.position.x;
        transform.position = position;
    }
}