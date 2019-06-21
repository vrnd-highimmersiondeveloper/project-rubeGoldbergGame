using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private const float speed = 10f;
    private const float jumpHight = 200f;
    private List<GameObject> starList;
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
        Debug.Log("collision enter " + collision.gameObject.name + "is play ball " + isThisObjectPlayBall());
        if (collision.gameObject.tag.ToLower() == MyConstManager.TagGROUND.ToLower() && isThisObjectEditBall())
        {
            ResetLocalPositionAfterEditBallHitsGround();
        }
        else if (collision.gameObject.tag.ToLower() == MyConstManager.TagGROUND.ToLower() && isThisObjectPlayBall())
        {
            if (LevelManager.Instance.CurrentScene == MyConstManager.SceneTUTORIAL)
            {
                SwitchScene(MyConstManager.SceneIDLE);
                Destroy(gameObject);
            }
            else
            {
                SwitchScene(MyConstManager.SceneIDLE);
                Destroy(gameObject);
            }
            
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
            if (LevelManager.Instance.CurrentScene == MyConstManager.SceneTUTORIAL)
            {
                SwitchScene(MyConstManager.SceneIDLE);
                Destroy(gameObject);
            }
            else
            {
                SwitchScene(MyConstManager.SceneIDLE);
                Destroy(gameObject);
            }
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

        if (LevelManager.Instance.CurrentScene == MyConstManager.SceneTUTORIAL)
        {
            SwitchScene(MyConstManager.SceneIDLE);
        }
        else if (LevelManager.Instance.CurrentScene == MyConstManager.SceneLEVEL1)
        {
            SwitchToLevel2();
        }

        Destroy(gameObject);
    }

    private void SwitchToLevel1()
    {
        if (LevelManager.Instance.AreAllCollectiblesCollected(MyConstManager.SceneTUTORIAL))
        {
            LevelManager.Instance.Level1Locked1 = true;
            SwitchScene(MyConstManager.SceneLEVEL1);
        }
        else
        {
            SwitchScene(MyConstManager.SceneIDLE);
        }
    }

    private void SwitchToLevel2()
    {
        if (LevelManager.Instance.AreAllCollectiblesCollected(MyConstManager.SceneLEVEL1))
        {
            SwitchScene(MyConstManager.SceneLEVEL2);
        }
        else
        {
            SwitchScene(MyConstManager.SceneIDLE);
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
        LevelManager.Instance.NumberCollectiblesCollected = numberCollected;
    }

    private void ResetCollectiblesCollectedNumber ()
    {
        numberCollected = 0;
        collectedCollectibles.text = numberCollected.ToString ();
        LevelManager.Instance.NumberCollectiblesCollected = numberCollected;
    }

    public void SetCollectibles(List<GameObject> collectibles)
    {
        starList = collectibles;
        SaveInLevelManagerMaxCollectibles(collectibles.Count);
    }

    private void SaveInLevelManagerMaxCollectibles(int numberCollectibles)
    {
        LevelManager.Instance.MaxCollectibles = numberCollectibles;
    }
}
