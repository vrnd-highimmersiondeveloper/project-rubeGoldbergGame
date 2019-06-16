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
    private bool isBallPlayAttached = false;
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

        if (other.gameObject.tag.ToLower () == MyConstManager.TagCOLLECTIBLE.ToLower ())
        {
            SetCollectibleCollected (other.gameObject);
        }
        else if (other.gameObject.tag.ToLower () == MyConstManager.TagGRAVITYZONE.ToLower ())
        {
            rb.useGravity = false;
            rb.AddForce (Vector3.up * speed);
        }
        else if (other.gameObject.tag.ToLower () == MyConstManager.TagWINDAREA.ToLower  ())
        {
            inFanZone = true;
            fanDirection = other.gameObject.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.ToLower() == MyConstManager.TagGROUND.ToLower())
        {
            ResetLocalPositionAfterEditBallHitsGround();
        }
        else if (collision.gameObject.tag.ToLower() == MyConstManager.TagJUMPAREA.ToLower())
        {
            rb.AddForce(Vector3.up * jumpHight);
        }
        else if (collision.gameObject.tag.ToLower() == MyConstManager.TagGOAL.ToLower() && isThisObjectEditBall())
        {
            ResetLocalPositionAfterEditBallHitsGround();
        }
        else if (collision.gameObject.tag.ToLower() == MyConstManager.TagGOAL.ToLower() && isThisObjectPlayBall())
        {
            SwitchSceneAfterReachGoalWithPlayBall();
        }
        else if (collision.gameObject.tag.ToLower() == MyConstManager.TagPLAYGROUND.ToLower() && isThisObjectPlayBall())
        {
            SwitchScene(MyConstManager.SceneGAMEOVER);
        }
        else if (collision.gameObject.tag.ToLower() == MyConstManager.TagGROUND.ToLower() && isThisObjectPlayBall())
        {
            SwitchScene(MyConstManager.SceneGAMEOVER);
        }
    }

    private bool isThisObjectEditBall()
    {
        return gameObject.tag.ToLower() == MyConstManager.TagBALLEDIT.ToLower();
    }

    private bool isThisObjectPlayBall()
    {
        return gameObject.tag.ToLower() == MyConstManager.TagBALLPLAY.ToLower();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.ToLower() == MyConstManager.TagGRAVITYZONE.ToLower())
        {
            rb.useGravity = true;
        }
        else if (other.gameObject.tag.ToLower() == MyConstManager.TagWINDAREA.ToLower())
        {
            inFanZone = false;
        }
    }

    private void SwitchSceneAfterReachGoalWithPlayBall()
    {
        Destroy(gameObject);

        if (LevelManager.Instance.AreAllCollectiblesCollected(MyConstManager.SceneTUTORIAL))
        {
            SwitchScene(MyConstManager.SceneLEVEL1);
        }
        else
        {
            SwitchScene(MyConstManager.SceneGAMEOVER);
        }
    }

    private void SwitchScene (string nextScene)
    {
        SteamVR_LoadLevel.Begin (nextScene, 
            MyConstManager.showGrid, MyConstManager.fadeOutTime, 
            MyConstManager.rgbR, MyConstManager.rgbG, 
            MyConstManager.rgbB, MyConstManager.rgbA);
    }

    private void ResetLocalPositionAfterEditBallHitsGround ()
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

    //Interaction with Hands, called from inspector
    public void MarkBallPlayAttached ()
    {
        if (gameObject.tag.ToLower () == MyConstManager.TagBALLEDIT.ToLower ())
        {
            isBallPlayAttached = false;
        }
        else if (gameObject.tag.ToLower () == MyConstManager.TagBALLPLAY.ToLower ())
        {
            if (!isBallPlayAttached)
            {
                ResetCollectiblesCollectedNumber();
                SetAllCollectiblesActive();
                isBallPlayAttached = true;
            }
        }

        LevelManager.Instance.PlayMode = isBallPlayAttached;
    }

    public void SetBallPlayDetached ()
    {
        isBallPlayAttached = false;
    }

    //Collectibles
    private void SetAllCollectiblesActive ()
    {
        if(SceneManager.GetActiveScene().name.ToLower () != MyConstManager.SceneGAMEOVER.ToLower ())
        {
            foreach (GameObject item in starList)
            {
                item.SetActive (true);
            }
        }
    }

    private void SetCollectibleCollected (GameObject collectible)
    {
        collectible.SetActive (false);
        numberCollected++;
        collectedCollectibles.text = numberCollected.ToString ();
        LevelManager.Instance.NumberCollectiblesCollected = numberCollected;
    }

    private void ResetCollectiblesCollectedNumber ()
    {
        numberCollected = 0;
        collectedCollectibles.text = numberCollected.ToString ();
        LevelManager.Instance.NumberCollectiblesCollected = numberCollected;
    }
}
