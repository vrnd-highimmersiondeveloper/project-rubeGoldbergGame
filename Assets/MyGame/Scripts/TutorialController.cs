using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialController : MonoBehaviour {

    public Ball editBall;
    public TextMeshProUGUI modeLabel;
    private bool modeToggled = false;

    private void Update()
    {
        //Debug.Log("PlayMode " + LevelManager.Instance.PlayMode);
        if (LevelManager.Instance.PlayMode)
        {
           
            if (!modeToggled)
            {
                Debug.Log("PlayMode " + LevelManager.Instance.PlayMode);


                editBall.gameObject.SetActive(false);
                modeLabel.text = "Play Mode";
                modeToggled = true;
                Debug.Log("edit acitve " + editBall.enabled);
            }
            
        }   
    }
}
