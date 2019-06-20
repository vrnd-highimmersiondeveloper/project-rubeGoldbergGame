/* concrete singelton
 * this inherits from the GenericSingleton (a singleton without copying code),   
 * the GenericSingleton fixes the persistency problem and allows lazy instantiation.  
 */
using UnityEngine;

public class LevelManager : GenericSingletonClass<LevelManager>
{
    public int numberCollectibesCollected = 0;
    public bool playMode = false;
    private int maxTutorialCollectibles = 3;
    private string currentScene = "none";
    private GameObject player;
    public GameObject leftHand;
    public GameObject rightHand;
    private GameObject rightBeam;
    private GameObject leftBeam;
    public GameObject simpleCIMenu;
    public Vector3 quillPosition;
    public Quaternion quillRotation;


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

    public GameObject LeftHand
    {
        get
        {
            Debug.Log("in left hand");
            return leftHand;
        }

        set
        {
            leftHand = value;
        }
    }

    public GameObject RightHand
    {
        get
        {
            return rightHand;
        }

        set
        {
            rightHand = value;
        }
    }

    public GameObject SimpleCIMenu
    {
        get
        {
            return simpleCIMenu;
        }

        set
        {
            simpleCIMenu = value;
        }
    }

    public Vector3 QuillPosition
    {
        get
        {
            return quillPosition;
        }

        set
        {
            Debug.Log("set quill pos");
            quillPosition = value;
        }
    }

    public GameObject Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    public GameObject RightBeam
    {
        get
        {
            return rightBeam;
        }

        set
        {
            rightBeam = value;
        }
    }

    public GameObject LeftBeam
    {
        get
        {
            return leftBeam;
        }

        set
        {
            leftBeam = value;
        }
    }


    public Quaternion QuillRotation
    {
        get
        {
            return quillRotation;
        }

        set
        {
            quillRotation = value;
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