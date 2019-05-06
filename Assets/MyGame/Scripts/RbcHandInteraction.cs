using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RbcHandInteraction : MonoBehaviour
{
    public HandMenuObjectManager objectmenuManager;
    public SteamVR_Action_Vector2 selectMenuItemAction;
    public SteamVR_Action_Boolean confirmMenuItemAction;
    public SteamVR_Action_Boolean showObjectMenu;
    
    private float leftBoundaryValueX = -0.8f;
    private float rightBoundaryValueX = 0.8f;

    //Swipe
    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedLeft = false;
    public bool hasSwipedRight = false;
    private bool confirmTiggerSet = false;

    // Use this for initialization
    void Start ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
    }

    private void SwipeRight ()
    {
        objectmenuManager.MenuRight();
        hasSwipedRight = true;
    }

    private void SwipeLeft ()
    {
        objectmenuManager.MenuLeft();
        hasSwipedLeft = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var menuVisible = showObjectMenu.GetState(SteamVR_Input_Sources.RightHand);
        if (menuVisible)
        {
            objectmenuManager.gameObject.SetActive(true);
            var joystickAxisRH = selectMenuItemAction.GetAxis(SteamVR_Input_Sources.RightHand);

            //Debug.Log(rightHoriz.x);
            if (joystickAxisRH.x < leftBoundaryValueX && !hasSwipedLeft)
            {
                SwipeLeft();
            }
            else if (joystickAxisRH.x > rightBoundaryValueX && !hasSwipedRight)
            {
                SwipeRight();
            }
            else if (joystickAxisRH.x == 0.0f)
            {
                hasSwipedLeft = false;
                hasSwipedRight = false;
                confirmTiggerSet = false;
            }

            var confirmItem = confirmMenuItemAction.GetState(SteamVR_Input_Sources.RightHand);

            if (confirmItem && !confirmTiggerSet)
            {
                SpawnObject();
                confirmTiggerSet = true;
            }
        }
        else
        {
            objectmenuManager.gameObject.SetActive(false);
        }
        
    }

    public void SpawnObject()
    {
        objectmenuManager.SpawnCurrentObject();
    }
}
