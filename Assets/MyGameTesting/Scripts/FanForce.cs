using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanForce : MonoBehaviour
{
    public float force = 10f;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "BallTest")
        {
            Debug.Log("OnTRIGGER STAY FAN " + other.name);
            other.attachedRigidbody.AddForce(gameObject.transform.forward * force);
        }

    }
}
