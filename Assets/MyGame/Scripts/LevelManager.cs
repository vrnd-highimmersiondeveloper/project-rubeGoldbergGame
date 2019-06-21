/* concrete singelton
 * this inherits from the GenericSingleton (a singleton without copying code),   
 * the GenericSingleton fixes the persistency problem and allows lazy instantiation.  
 */
using UnityEngine;

public class LevelManager : GenericSingletonClass<LevelManager>
{
    public bool playMode = false;
    public int numberCollectibesCollected = 0;
    private int maxTutorialCollectibles = 3;
    private int maxCollectibles = 0;
    private string currentScene = "none";
    private GameObject player;
    public GameObject leftHand;
    public GameObject rightHand;
    private GameObject rightBeam;
    private GameObject leftBeam;
    public GameObject simpleCIMenu;
    public Vector3 quillPosition;
    public Quaternion quillRotation;
    private bool level1Locked = true;
    private bool level2Locked = true;
    private bool level3Locked = true;
    private bool level4Locked = true;


    public int NumberCollectiblesCollected
    {
        get
        {
            return numberCollectibesCollected;
        }

        set
        {
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

    public int MaxCollectibles
    {
        get
        {
            return maxCollectibles;
        }

        set
        {
            maxCollectibles = value;
        }
    }

    public bool Level1Locked1
    {
        get
        {
            return level1Locked;
        }

        set
        {
            level1Locked = value;
        }
    }

    public void DeactivateEditBall(Ball ball)
    {
        ball.enabled = false;
    }

    public bool AreAllCollectiblesCollected (string sceneName)
    {
        bool collected = false;

        if (sceneName.ToLower () == MyConstManager.SceneTUTORIAL.ToLower())
        {
            collected = (numberCollectibesCollected == maxTutorialCollectibles);
        }
        else if (sceneName.ToLower() == MyConstManager.SceneLEVEL1.ToLower())
        {
            collected = (numberCollectibesCollected == maxCollectibles);
        }

        return collected;
    }

    public Vector3 GetPlayerInitPosition()
    {
        return new Vector3(2.404843f,1.385122f,16.3957f);
    }

    public Quaternion GetPlayerInitRotation()
    {
        return Quaternion.Euler(0.0f, 180.0f, 0.0f);
    }


}