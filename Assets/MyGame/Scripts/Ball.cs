using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private const string TagGOAL = "Goal";
    private const string TagBALLTEST = "BallTest";
    private const string TagBALLPLAY = "BallPlay";
    private const string TagCOLLECTIBLE = "Collectible";
    private const string TagGRAVITYZONE = "GravityZone";
    private const string TagWINDAREA = "WindArea";
    private const string TagGROUND = "Ground";
    private const string TagJUMPAREA = "JumpArea";
    private const float speed = 10f;
    private const float jumpHight = 200f;
    public List<GameObject> starList;
    public TextMeshProUGUI collectedCollectibles;

    private Rigidbody rb;

    private float ballDefaultPosX = 0.0f;
    private float ballDefaultPosY = 0.0f;
    private float ballDefaultPosZ = 0.0f;

    private int numberCollected = 0;
    private bool isBallAttached = false;
    private bool isTeleportAreaHit = false;
    private bool inFanZone = false;
    private Vector3 fanDirection;

    private void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody> ();
        SetBallsDefaultPosition ();
    }

    private void SetBallsDefaultPosition ()
    {
        ballDefaultPosX = transform.position.x;
        ballDefaultPosY = transform.position.y;
        ballDefaultPosZ = transform.position.z;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == TagGOAL && gameObject.tag == TagBALLTEST)
        {
            ResetAfterBallHitsGround ();
        }
        else if (other.gameObject.tag == TagCOLLECTIBLE)
        {
            SetCollectibleCollected (other.gameObject);
        }
        else if (other.gameObject.tag == TagGRAVITYZONE)
        {
            rb.useGravity = false;
            rb.AddForce (Vector3.up * speed);
        }
        else if (other.gameObject.tag == TagWINDAREA)
        {
            inFanZone = true;
            fanDirection = other.gameObject.transform.position;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == TagGRAVITYZONE)
        {
            rb.useGravity = true;
        }
        else if (other.gameObject.tag == TagWINDAREA)
        {
            inFanZone = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == TagGROUND)
        {
            ResetAfterBallHitsGround ();
        }

        else if (collision.gameObject.tag == TagJUMPAREA)
        {
            rb.AddForce (Vector3.up * jumpHight);
        }
    }

    private void ResetAfterBallHitsGround ()
    {
        gameObject.SetActive (false);
        ResetBallPosition ();
        ResetCollectiblesCollectedNumber ();
        SetAllCollectiblesActive ();
        gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
        gameObject.SetActive (true);
    }

    private void ResetBallPosition ()
    {
        gameObject.transform.position = new Vector3 (ballDefaultPosX, 
                                                     ballDefaultPosY, 
                                                     ballDefaultPosZ);
    }

    //Interaction with Hands
    public void SetBallAttached ()
    {
        isBallAttached = true;
        if (gameObject.tag == TagBALLTEST)
        {
            LevelManager.Instance.PlayMode = false;
        }
        else if (gameObject.tag == TagBALLPLAY)
        {
            LevelManager.Instance.PlayMode = true; 
        }
    }

    public void SetBallDetached ()
    {
        isBallAttached = false;
    }

    //Collectibles
    private void SetAllCollectiblesActive ()
    {
        foreach (GameObject item in starList)
        {
            item.SetActive (true);
        }
    }

    private void SetCollectibleCollected (GameObject collectible)
    {
        collectible.SetActive (false);
        numberCollected++;
        collectedCollectibles.text = numberCollected.ToString ();
    }

    private void ResetCollectiblesCollectedNumber ()
    {
        numberCollected = 0;
        collectedCollectibles.text = numberCollected.ToString ();
    }
}
