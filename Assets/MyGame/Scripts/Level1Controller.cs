using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level1Controller : MonoBehaviour
{
    private GameObject player = null;
    public GameObject playBall;
    public GameObject editBall;
    public List<GameObject> starList;

    void Start ()
    {
        Debug.Log("IN LEVEL 1");
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene ().name;
        LevelManager.Instance.MaxCollectibles = 1;
        player = LevelManager.Instance.Player;
        player.GetComponent<Transform>().position = LevelManager.Instance.GetPlayerInitPosition();
        player.GetComponent<Transform>().rotation = LevelManager.Instance.GetPlayerInitRotation();

        Debug.Log("playball " + (playBall == null));
        if (playBall == null || editBall == null)
        {
            Debug.Log("playball  or edit ball == null" + (playBall == null));
        }
        playBall.GetComponent<Ball>().SetCollectibles(starList);
        editBall.GetComponent<Ball>().SetCollectibles(starList);
    }



}
