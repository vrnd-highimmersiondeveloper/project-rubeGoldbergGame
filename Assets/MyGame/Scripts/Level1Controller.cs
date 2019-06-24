using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class Level1Controller : MonoBehaviour
{
    private GameObject player = null;
  
    public GameObject playBall;
    public GameObject editBall;
    public List<GameObject> starList;
    public Timer editTimer;
    public TextMeshProUGUI collectedCollectibles;
    public TextMeshProUGUI maxCollectiblesLabel;
    public TextMeshProUGUI modeLabel;
    public TextMeshProUGUI timerLabel;
    private bool modeToggled = false;

    //only for testing
    public bool singleTesting;
    public GameObject defaultPlayerPos;
    public GameObject singlePlayer;

    void Start ()
    {
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
        maxCollectiblesLabel.text = starList.Count.ToString();  
        InitializePlayer ();
        InitializeBallProperties ();
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

    private void InitializeBallProperties()
    {
        LevelManager.Instance.MaxCollectibles = starList.Count;

        playBall.GetComponent<Ball>().SetCollectibles(starList);
        editBall.GetComponent<Ball>().SetCollectibles(starList);

        playBall.GetComponent<Ball>().collectedCollectibles = this.collectedCollectibles;
        editBall.GetComponent<Ball>().collectedCollectibles = this.collectedCollectibles;
    }

    private void InitializePlayer()
    {
        if (singleTesting)
        {
            player = singlePlayer;
            player.GetComponent<Transform>().position = defaultPlayerPos.GetComponent<Transform>().position;
            player.GetComponent<Transform>().rotation = defaultPlayerPos.GetComponent<Transform>().rotation;
        }
        else
        {
            singlePlayer.SetActive(false);
            player = LevelManager.Instance.Player;
            player.GetComponent<Transform>().position = LevelManager.Instance.GetPlayerInitPosition();
            player.GetComponent<Transform>().rotation = LevelManager.Instance.GetPlayerInitRotation();
        }
    }
}
