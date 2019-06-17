//LaserPointer script is added onto LeftHand and Righthand for pointing in introScence
//When switching into the next scene, the laserpointer still remains because the player is in don't destroy on load
//On Destroy this script destroys the SteamVR_Laserpointer component as well as the cube object made by the script 
//for the pointer beam before switching the scene. 

using UnityEngine;
using Valve.VR.Extras;

public class LaserPointerManager : MonoBehaviour
{
    public GameObject leftHand = null;
    public GameObject rightHand = null;

    private SteamVR_LaserPointer laserPointerLeft;
    private SteamVR_LaserPointer laserPointerRight;
    GameObject leftLaser;
    GameObject rightLaser;

    private void Awake()
    {
        leftHand = GameObject.Find("LeftHand");
        rightHand = GameObject.Find("RightHand");
    }

    private void Start()
    {
        if (leftHand != null && rightHand != null)
        {
            laserPointerLeft = leftHand.GetComponent<SteamVR_LaserPointer>();
            laserPointerRight = rightHand.GetComponent<SteamVR_LaserPointer>();

            Debug.Log("Laser Pointer created");
            Debug.Log("LP " + laserPointerLeft == null);
            Debug.Log("LR " + laserPointerRight == null);
        }
        else
        {
            Debug.Log("Hands not found!");
        }

    }

    //Destroy all laserObjects made by laserPointer in the next scene
   /* public void DestroyLaserBeam(SteamVR_LaserPointer laserPointer)
    {
        //Debug.Log("in destroy beam, laser Pointer is: " + laserPointer.gameObject.name);

        Transform[] tmpObjects = laserPointer.gameObject.GetComponentsInChildren<Transform>();

        for (int i = 0; i < tmpObjects.Length; i++)
        {
            Debug.Log( i + "in for in destryo beam");
            if (tmpObjects[i].name.StartsWith("Beam"))
            {
                //Destroy(tmpObjects[i].gameObject);
                tmpObjects[i].gameObject.SetActive(false);
                break;
            }
        }
    }*/

    public void DestroyLaserBeam(GameObject laser)
    {
        Debug.Log("in destroy beam, laser Pointer is: ");

        Transform[] tmpObjects = laser.GetComponentsInChildren<Transform>();

        for (int i = 0; i < tmpObjects.Length; i++)
        {
            Debug.Log("in for in destryo beam");
            if (tmpObjects[i].name.StartsWith("Beam"))
            {
                //Destroy(tmpObjects[i].gameObject);
                tmpObjects[i].gameObject.SetActive(false);
                Debug.Log(tmpObjects[i].gameObject.name);
                break;
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log("in dESTROY");
        //Debug.Log("in destroy beam, laser Pointer is: " + laserPointerLeft.gameObject.name);
        DestroyLaserBeam(leftHand);
        DestroyLaserBeam(rightHand);

        //Destroy(laserPointerLeft);
        //Destroy(laserPointerRight);
    }
}
