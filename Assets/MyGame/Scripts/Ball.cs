using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
   
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
        if (other.gameObject.tag == MyConstManager.TagGOAL && gameObject.tag == MyConstManager.TagBALLTEST)
        {
            ResetAfterBallHitsGround ();
        }
        else if (other.gameObject.tag == MyConstManager.TagGOAL && gameObject.tag == MyConstManager.TagBALLPLAY)
        {
            SwitchScene();
        }
        else if (other.gameObject.tag == MyConstManager.TagCOLLECTIBLE)
        {
            SetCollectibleCollected (other.gameObject);
        }
        else if (other.gameObject.tag == MyConstManager.TagGRAVITYZONE)
        {
            rb.useGravity = false;
            rb.AddForce (Vector3.up * speed);
        }
        else if (other.gameObject.tag == MyConstManager.TagWINDAREA)
        {
            inFanZone = true;
            fanDirection = other.gameObject.transform.position;
        }
    }

    private static void SwitchScene()
    {
        SteamVR_LoadLevel.Begin("GameOver", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == MyConstManager.TagGRAVITYZONE)
        {
            rb.useGravity = true;
        }
        else if (other.gameObject.tag == MyConstManager.TagWINDAREA)
        {
            inFanZone = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == MyConstManager.TagGROUND)
        {
            ResetAfterBallHitsGround ();
        }

        else if (collision.gameObject.tag == MyConstManager.TagJUMPAREA)
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
        if (gameObject.tag == MyConstManager.TagBALLTEST)
        {
            LevelManager.Instance.PlayMode = false;
        }
        else if (gameObject.tag == MyConstManager.TagBALLPLAY)
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
        if(SceneManager.GetActiveScene().name != "GameOver")
        {
            foreach (GameObject item in starList)
            {
                item.SetActive(true);
            }
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
