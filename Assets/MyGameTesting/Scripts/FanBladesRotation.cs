using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBladesRotation : MonoBehaviour
{
    public float spinSpeed = 5.0f;


       void Update ()
    {
        transform.Rotate(0.0f, 0.0f, spinSpeed + Time.deltaTime);	
	}
}
