using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class HandInteractionMenuManager : MonoBehaviour
{
    private GameObject leftHand = null;
    private GameObject rightHand = null;

    private SteamVR_LaserPointer laserPointerLeft;
    private SteamVR_LaserPointer laserPointerRight;

    private GameObject laserBeamLeft;
    private GameObject laserBeamRight;

    private GameObject simpleCIMenu;

    private void Awake()
    {
        leftHand = LevelManager.Instance.LeftHand;
        rightHand = LevelManager.Instance.RightHand;

        laserPointerLeft = leftHand.GetComponent<SteamVR_LaserPointer>();
        laserPointerRight = rightHand.GetComponent<SteamVR_LaserPointer>();

        laserBeamLeft = InitLaserBeam(leftHand);
        laserBeamRight = InitLaserBeam(rightHand);

        simpleCIMenu = LevelManager.Instance.SimpleCIMenu;
    }

    private void Start()
    {
        if (LevelManager.Instance.CurrentScene == MyConstManager.SceneFirst)
        {
            EnableLaserPointerComponent();
            ActivateLaserBeam();
        }
        else if (LevelManager.Instance.CurrentScene == MyConstManager.SceneIDLE)
        {
            EnableLaserPointerComponent();
            ActivateLaserBeam();
        }
        else if (LevelManager.Instance.CurrentScene == MyConstManager.SceneLEVEL1)
        {
            DisableLaserPointerComponent();
            DeactivateLaserBeam();
            ActivateSimpleCIMenu();
        }
        else if (LevelManager.Instance.CurrentScene == MyConstManager.SceneTUTORIAL)
        {
            DisableLaserPointerComponent();
            DeactivateLaserBeam();
            ActivateSimpleCIMenu();
        }
    }

    public void ActivateSimpleCIMenu()
    {
        simpleCIMenu.SetActive(true);
    }
    public void DeactivateLaserBeam()
    {
        DeactivateLaserBeam(leftHand);
        DeactivateLaserBeam(rightHand);
    }

    public void ActivateLaserBeam()
    {
        ActivateLaserBeam(leftHand);
        ActivateLaserBeam(rightHand);
    }

    public void ActivateLaserBeam(GameObject laserBeamObject)
    {
        laserBeamObject.SetActive(true);
    }

    public void DeactivateLaserBeam(GameObject laserBeamObject)
    {
        laserBeamObject.SetActive(false);
    }

    public void EnableLaserPointerComponent()
    {
        leftHand.GetComponent<SteamVR_LaserPointer>().enabled = true;
        rightHand.GetComponent<SteamVR_LaserPointer>().enabled = true;
    }

    public void DisableLaserPointerComponent()
    {
        leftHand.GetComponent<SteamVR_LaserPointer>().enabled = false;
        rightHand.GetComponent<SteamVR_LaserPointer>().enabled = false;
    }

    public GameObject InitLaserBeam(GameObject laser)
    {
        GameObject beamObject = null;

        Debug.Log("find beam object");

        Transform[] tmpObjects = laser.GetComponentsInChildren<Transform>();

        for (int i = 0; i < tmpObjects.Length; i++)
        {
            Debug.Log("obj name " + tmpObjects[i].name);
            if (tmpObjects[i].name.StartsWith("Beam"))
            {
                beamObject = tmpObjects[i].gameObject;
                Debug.Log("Found Object" + beamObject.name);
                break;
            }
        }

        return beamObject;
    }

}
