﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour {

    public List<GameObject> starList;
    public TextMeshProUGUI collectedCollectibles;

    private float ballDefaultPosX = 0.0f;
    private float ballDefaultPosY = 0.0f;
    private float ballDefaultPosZ = 0.0f;

    private int numberCollected = 0;
    private bool isBallAttached = false;
    private bool isTeleportAreaHit = false;

    private void Start ()
    {
        SetBallsDefaultPosition();
    }

    private void SetBallsDefaultPosition()
    {
        ballDefaultPosX = transform.position.x;
        ballDefaultPosY = transform.position.y;
        ballDefaultPosZ = transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tiggerevent" + other.gameObject.name);
        if (other.gameObject.tag == "Goal" && gameObject.tag == "BallTest")
        {
            Debug.Log("Goal reached");
            ResetAfterBallHitsGround();
        }
        else if (other.gameObject.tag == "Collectible")
        {
            SetCollectibleCollected (other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisionevent" + collision.gameObject.name);
        if(collision.gameObject.tag == "Ground")
        {
            ResetAfterBallHitsGround();
        }
    }

    private void ResetAfterBallHitsGround()
    {
        Debug.Log("Reset " + gameObject.transform.position);
        gameObject.SetActive(false);
        ResetBallPosition("BallTest");
        ResetCollectiblesCollectedNumber();
        SetAllCollectiblesActive();
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.SetActive(true);
    }

    private void ResetBallPosition(string tag)
    {
        gameObject.transform.position = new Vector3(ballDefaultPosX, 
                                                    ballDefaultPosY, 
                                                    ballDefaultPosZ);
    }

    //Interaction with Hands
    public void SetBallAttached()
    {
        isBallAttached = true;
    }

    public void SetBallDetached()
    {
        isBallAttached = false;
    }

    //Collectibles
    private void SetAllCollectiblesActive()
    {
        foreach (GameObject item in starList)
        {
            item.SetActive(true);
        }
    }

    private void SetCollectibleCollected(GameObject collectible)
    {
        collectible.SetActive(false);
        numberCollected++;
        //LevelManager.Instance.NumberCollectiblesCollected = numberCollected;
        collectedCollectibles.text = numberCollected.ToString();
    }

    private void ResetCollectiblesCollectedNumber()
    {
        numberCollected = 0;
        //LevelManager.Instance.NumberCollectiblesCollected = numberCollected;
        collectedCollectibles.text = numberCollected.ToString ();
    }

}