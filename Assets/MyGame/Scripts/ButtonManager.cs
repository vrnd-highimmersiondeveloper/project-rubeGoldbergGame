using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ButtonManager : MonoBehaviour
{
    public SteamVR_Action_Boolean grapPinch;
    public SteamVR_Input_Sources inputSource;
    private bool showGrid = false;
    private float fadeOutTime = 2.0f;
    private float rgbR = 0.0f;
    private float rgbG = 0.0f;
    private float rgbB = 0.0f;
    private float rgbA = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == MyConstManager.TAGBTNTUTORIAL)
        {
            SetColorToButton(Color.blue);
        }
        else if (gameObject.name == MyConstManager.TAGBTNANONYMOUS)
        {
            SetColorToButton(Color.blue);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isRightLaserPointerUsed(other) && gameObject.name == MyConstManager.TAGBTNTUTORIAL)
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin(MyConstManager.SCENETUTORIAL, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
        else if (isLeftLaserPointerUsed(other) &&  gameObject.name == MyConstManager.TAGBTNTUTORIAL)
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin(MyConstManager.SCENETUTORIAL, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
        else if (isRightLaserPointerUsed(other) && gameObject.name == MyConstManager.TAGBTNANONYMOUS)
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin(MyConstManager.SCENELEVEL1, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
        else if (isLeftLaserPointerUsed(other) && gameObject.name == MyConstManager.TAGBTNANONYMOUS)
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin(MyConstManager.SCENELEVEL1, showGrid, fadeOutTime, rgbR, rgbG, rgbB, rgbA);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == MyConstManager.TAGBTNTUTORIAL)
        {
            SetColorToButton(Color.white);
        }
        else if (gameObject.name == MyConstManager.TAGBTNANONYMOUS)
        {
            SetColorToButton(Color.white);
        }
    }

    private void SetColorToButton(Color myColor)
    {
        gameObject.GetComponentInChildren<Text>().color = myColor;
        gameObject.GetComponentInChildren<Image>().color = myColor;
    }

    private bool isRightLaserPointerUsed(Collider other)
    {
        return isRightColliderInUse(other) && checkTriggerRightClicked();
    }

    private bool isLeftLaserPointerUsed(Collider other)
    {
        return isLeftColliderInUse(other) && checkTriggerLeftClicked();
    }

    private bool checkTriggerLeftClicked()
    {
        return grapPinch.GetStateDown(SteamVR_Input_Sources.LeftHand);
    }

    private bool checkTriggerRightClicked()
    {
        return grapPinch.GetStateDown(SteamVR_Input_Sources.RightHand);
    }

    private bool isLeftColliderInUse(Collider other)
    {
        bool isLeftHandCollider = false;
        Transform[] tmp = other.gameObject.GetComponentsInParent<Transform>();

        for (int i=0; i < tmp.Length; i++)
        {
            if (tmp[i].gameObject.name.Contains(MyConstManager.LEFT))
            {
                isLeftHandCollider = true;
                break;
            }
        }
        return isLeftHandCollider;
    }

    private bool isRightColliderInUse(Collider other)
    {
        return !isLeftColliderInUse(other);
    }
}
