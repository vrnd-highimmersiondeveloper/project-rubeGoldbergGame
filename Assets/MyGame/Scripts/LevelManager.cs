/* concrete singelton
 * this inherits from the GenericSingleton (a singleton without copying code),   
 * the GenericSingleton fixes the persistency problem and allows lazy instantiation.  
 */
using UnityEngine;

public class LevelManager : GenericSingletonClass<LevelManager>
{
    private int numberCollectibesCollected = 0;
    private bool playMode = false;
    private int maxTutorialCollectibles = 3;
    private string currentScene = "none";

    public int NumberCollectiblesCollected
    {
        get
        {
            Debug.Log("get nbr collected collectibles " + numberCollectibesCollected);
            return numberCollectibesCollected;
        }

        set
        {
            Debug.Log("set nbr collected collectibles " + numberCollectibesCollected);
            numberCollectibesCollected = value;
        }
    }

    public bool PlayMode
    {
        get
        {
            return playMode;
        }

        set
        {
            playMode = value;
        }
    }

    public string CurrentScene
    {
        get
        {
            return currentScene;
        }

        set
        {
            currentScene = value;
        }
    }

    public void DeactivateEditBall(Ball ball)
    {
        ball.enabled = false;
    }

    public bool AreAllCollectiblesCollected (string sceneName)
    {
        bool collected = false;

        Debug.Log("name scene:  " + currentScene + " number colletibles in scene" + maxTutorialCollectibles + " I've collected " + numberCollectibesCollected);

        if (sceneName.ToLower () == MyConstManager.SceneTUTORIAL.ToLower())
        {
            collected = (numberCollectibesCollected == maxTutorialCollectibles);
        }

        return collected;
    }

    public Vector3 GetPlayerInitPosition()
    {
        return new Vector3(2.404843f,1.385122f,16.3957f);
    }
}