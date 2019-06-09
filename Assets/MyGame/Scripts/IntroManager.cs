using UnityEngine;
using Valve.VR;

public class IntroManager : MonoBehaviour
{
    public LaserPointerManager buttonManager;

    public SteamVR_Action_Boolean grapPinch;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided object other " + other.name);
        Debug.Log(grapPinch.state);

        if (gameObject.name == "BtnTutorial" && grapPinch.stateDown)
        {
            gameObject.SetActive(false);
            
            SteamVR_LoadLevel.Begin("02Tutorial", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
            Debug.Log("Switch Scene");
        }
    }

}
