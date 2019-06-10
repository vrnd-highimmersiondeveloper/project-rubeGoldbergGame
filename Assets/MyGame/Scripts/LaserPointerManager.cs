//LaserPointer script is added onto LeftHand and Righthand for pointing in introScence
//When switching into the next scene, the laserpointer still remains because the player is in don't destroy on load
//On Destroy this script destroys the SteamVR_Laserpointer component as well as the cube object made by the script 
//for the pointer beam before switching the scene. 

using UnityEngine;
using Valve.VR.Extras;

public class LaserPointerManager : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    private SteamVR_LaserPointer laserPointerLeft;
    private SteamVR_LaserPointer laserPointerRight;

    private void Start()
    {
        laserPointerLeft = leftHand.GetComponent<SteamVR_LaserPointer>();
        laserPointerRight = rightHand.GetComponent<SteamVR_LaserPointer>();
    }

    //Destroy all laserObjects made by laserPointer in the next scene
    private void DestroyLaserBeam(SteamVR_LaserPointer laserPointer)
    {
        Transform[] tmpObjects = laserPointer.GetComponentsInChildren<Transform>();

        for (int i = 0; i < tmpObjects.Length; i++)
        {
            if (tmpObjects[i].name.StartsWith("Beam"))
            {
                Destroy(tmpObjects[i].gameObject);
                break;
            }
        }
    }

    private void OnDestroy()
    {
        DestroyLaserBeam(laserPointerLeft);
        DestroyLaserBeam(laserPointerRight);

        Destroy(laserPointerLeft);
        Destroy(laserPointerRight);
    }
}
