using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TutorialController : MonoBehaviour
{
    public Ball editBall;
    public Ball playBall;
    public Timer editTimer;
    public GameObject initialPlayerPosition;
    public TextMeshProUGUI modeLabel;
    public TextMeshProUGUI timerLabel;
    public GameObject mySimpleConstructionItemManager;

    public List<GameObject> starList;

    private bool modeToggled = false;

    private GameObject myPlayer;
    private GameObject rightHand;
    private GameObject leftHand;


    private void Start()
    {
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
        LevelManager.Instance.PlayMode = false;
        myPlayer = GameObject.Find(MyConstManager.TagPLAYER);
        myPlayer.GetComponent<Transform>().position = initialPlayerPosition.GetComponent<Transform>().position;
        myPlayer.GetComponent<Transform>().rotation = initialPlayerPosition.GetComponent<Transform>().rotation;

        playBall.SetCollectibles(starList);
        editBall.SetCollectibles(starList);

    }

    private void Update()
    {
        if (LevelManager.Instance.PlayMode)
        {
            if (!modeToggled)
            {
                modeToggled = true;
                Debug.Log("PlayMode " + LevelManager.Instance.PlayMode);
                editBall.gameObject.SetActive(false);
                modeLabel.text = MyConstManager.TextPlayMode;
                editTimer.ResetTimer();
                timerLabel.text = editTimer.GetTime();
            }
        }
        else
        {
            timerLabel.text = editTimer.GetTime();
        }
    }
}
