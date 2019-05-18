using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ButtonManager : MonoBehaviour {

	public void SwitchToWelcomeScene()
    {
        SteamVR_LoadLevel.Begin("01WelcomeOverview", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
    }

    public void SwitchToTutorialScene()
    {
        SteamVR_LoadLevel.Begin("02Tutorial", false, 2.0f, 0.0f, 0.0f, 0.0f, 1.0f);
    }
}
