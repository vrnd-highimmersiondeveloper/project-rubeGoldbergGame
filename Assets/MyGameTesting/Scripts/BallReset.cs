using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BallReset : MonoBehaviour
{
    public float ballInitPosX = 0.0f;
    public float ballInitPosY = 0.0f;
    public float ballInitPosZ = 0.0f;

    public List<GameObject> starList;
    int numberCollected = 0;
   
    private bool resetBallPosition = false;
	
    // Use this for initialization
	void Start ()
    {
        Debug.Log("added Ball REset script");
        
        ballInitPosX = transform.position.x;
        ballInitPosY = transform.position.y;
        ballInitPosZ = transform.position.z;

        SetAllCollectiblesActive ();
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tiggerevent" + other.gameObject.name);
        if (other.gameObject.tag == "Collectible")
        {
            SetCollectibleCollected(other.gameObject);
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && collision.gameObject.name == "Cube")
        {
            Debug.Log ("Hit Ground");
            ResetAfterBallHitsGround();
        }

        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");
            SteamVR_LoadLevel.Begin("TestScene01");
      
        }
    }

    private void ResetAfterBallHitsGround ()
    {
        Debug.Log("Reset " + gameObject.transform.position);
        gameObject.SetActive (false);
        ResetBallPosition ();
        ResetCollectiblesCollectedNumber ();
        SetAllCollectiblesActive();
        gameObject.SetActive(true);
    }



    private void SetAllCollectiblesActive ()
    {
        foreach (GameObject item in starList)
        {
            item.SetActive (true);
        }
    }

    private bool AreAllCollectiblesCollected()
    {
        return starList.Count == numberCollected;
    }

    private void ResetBallPosition()
    {
        gameObject.transform.position = new Vector3(ballInitPosX, ballInitPosY, ballInitPosZ);
    }

    private void ResetCollectiblesCollectedNumber()
    {
        numberCollected = 0;
    }

    private void SetCollectibleCollected (GameObject collectible)
    {
        collectible.SetActive(false);
        numberCollected++;
    }
}
