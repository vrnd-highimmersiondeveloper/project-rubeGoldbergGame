using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ButtonManager : MonoBehaviour
{
    public SteamVR_Action_Boolean grapPinch;
    public SteamVR_Input_Sources inputSource;

    private GameObject laserPointerManager = null;
    private bool showGrid = false;
    private float fadeOutTime = 2.0f;
    private float rgbR = 0.0f;
    private float rgbG = 0.0f;
    private float rgbB = 0.0f;
    private float rgbA = 1.0f;


    private void Awake()
    {
        laserPointerManager = GameObject.Find("LaserPointerManager");
    }


    private void OnTriggerEnter (Collider other)
    {
        if (gameObject.name == MyConstManager.TagBTNTUTORIAL)
        {
            SetColorToButton (Color.blue);
        }
        else if (gameObject.name == MyConstManager.TagBTNANONYMOUS)
        {
            SetColorToButton (Color.blue);
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (isRightLaserPointerUsed (other) && gameObject.name == MyConstManager.TagBTNTUTORIAL)
        {
            gameObject.SetActive (false);
            //laserPointerManager.GetComponent<LaserPointerManager>().DestroyLaserBeam(other.transform.parent.gameObject);
            SteamVR_LoadLevel.Begin(MyConstManager.SceneTUTORIAL, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
        else if (isLeftLaserPointerUsed (other) &&  gameObject.name == MyConstManager.TagBTNTUTORIAL)
        {
            gameObject.SetActive (false);
            SteamVR_LoadLevel.Begin (MyConstManager.SceneTUTORIAL, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
        else if (isRightLaserPointerUsed (other) && gameObject.name == MyConstManager.TagBTNANONYMOUS)
        {
            gameObject.SetActive (false);
            SteamVR_LoadLevel.Begin (MyConstManager.SceneLEVEL1, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
        else if (isLeftLaserPointerUsed (other) && gameObject.name == MyConstManager.TagBTNANONYMOUS)
        {
            gameObject.SetActive (false);
            SteamVR_LoadLevel.Begin (MyConstManager.SceneLEVEL1, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (gameObject.name == MyConstManager.TagBTNTUTORIAL)
        {
            SetColorToButton (Color.white);
        }
        else if (gameObject.name == MyConstManager.TagBTNANONYMOUS)
        {
            SetColorToButton (Color.white);
        }
    }

    private void SetColorToButton (Color myColor)
    {
        gameObject.GetComponentInChildren<Text> ().color = myColor;
        gameObject.GetComponentInChildren<Image> ().color = myColor;
    }

    private bool isRightLaserPointerUsed (Collider other)
    {
        return isRightColliderInUse (other) && checkTriggerRightClicked ();
    }

    private bool isLeftLaserPointerUsed(Collider other)
    {
        return isLeftColliderInUse (other) && checkTriggerLeftClicked ();
    }

    private bool checkTriggerLeftClicked ()
    {
        return grapPinch.GetStateDown (SteamVR_Input_Sources.LeftHand);
    }

    private bool checkTriggerRightClicked ()
    {
        return grapPinch.GetStateDown (SteamVR_Input_Sources.RightHand);
    }

    private bool isLeftColliderInUse (Collider other)
    {
        bool isLeftHandCollider = false;
        Transform[] tmp = other.gameObject.GetComponentsInParent<Transform> ();

        for (int i=0; i < tmp.Length; i++)
        {
            if (tmp[i].gameObject.name.Contains (MyConstManager.LEFT))
            {
                isLeftHandCollider = true;
                break;
            }
        }
        return isLeftHandCollider;
    }

    private bool isRightColliderInUse (Collider other)
    {
        return !isLeftColliderInUse (other);
    }
}
