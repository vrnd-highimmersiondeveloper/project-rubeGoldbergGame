using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ButtonManager : MonoBehaviour
{
    public SteamVR_Action_Boolean grapPinch;
    public SteamVR_Input_Sources inputSource;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "BtnTutorial")
        {
            SetColorToButton(Color.blue);
        }
        else if (gameObject.name == "BtnAnonymous")
        {
            SetColorToButton(Color.blue);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isRightLaserPointerUsed(other) && gameObject.name == "BtnTutorial")
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin("02Tutorial", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (isLeftLaserPointerUsed(other) &&  gameObject.name == "BtnTutorial")
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin("02Tutorial", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
        }

        else if (isRightLaserPointerUsed(other) && gameObject.name == "BtnAnonymous")
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin("Level1", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (isLeftLaserPointerUsed(other) && gameObject.name == "BtnAnonymous")
        {
            gameObject.SetActive(false);
            SteamVR_LoadLevel.Begin("Level1", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "BtnTutorial")
        {
            SetColorToButton(Color.white);
        }

        else if (gameObject.name == "BtnAnonymous")
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

        for (int i=0;i < tmp.Length; i++)
        {
            if (tmp[i].gameObject.name.Contains("Left"))
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
