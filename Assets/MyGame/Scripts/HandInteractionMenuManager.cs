using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class HandInteractionMenuManager : MonoBehaviour
{
    public GameObject leftHand = null;
    public GameObject rightHand = null;

    private SteamVR_LaserPointer laserPointerLeft = null;
    private SteamVR_LaserPointer laserPointerRight = null;

    public GameObject laserBeamLeft = null;
    public GameObject laserBeamRight = null;

    private GameObject simpleCIMenu = null;

    private void Awake()
    {
        leftHand = LevelManager.Instance.LeftHand;
        rightHand = LevelManager.Instance.RightHand;

        laserBeamLeft = LevelManager.Instance.LeftBeam;
        laserBeamRight = LevelManager.Instance.RightBeam;

        laserPointerLeft = leftHand.GetComponent<SteamVR_LaserPointer>();
        laserPointerRight = rightHand.GetComponent<SteamVR_LaserPointer>();

        simpleCIMenu = LevelManager.Instance.SimpleCIMenu;
    }

    private void Start()
    {
        if (laserBeamLeft == null || laserBeamRight == null)
        {
            InitLaserBeam();
        }

        if (LevelManager.Instance.CurrentScene == MyConstManager.SceneFirst)
        {
            EnableLaserPointerComponent();
            DeactivateSimpleCIMenu();
            ActivateLaserBeam();
        }
        else if (LevelManager.Instance.CurrentScene == MyConstManager.SceneIDLE)
        {
            DeactivateSimpleCIMenu();
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

    private void InitLaserBeam()
    {
        LevelManager.Instance.LeftBeam = laserBeamLeft =  InitLaserBeam(leftHand);
        LevelManager.Instance.RightBeam = laserBeamRight = InitLaserBeam(rightHand);
        
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

    public void ActivateSimpleCIMenu()
    {
        simpleCIMenu.SetActive(true);
    }

    public void DeactivateSimpleCIMenu()
    {
        simpleCIMenu.SetActive(false);
    }

    public void DeactivateLaserBeam()
    {
        DeactivateLaserBeam(laserBeamLeft);
        DeactivateLaserBeam(laserBeamRight);
    }

    public void ActivateLaserBeam()
    {
        ActivateLaserBeam(laserBeamLeft);
        ActivateLaserBeam(laserBeamRight);
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

}
