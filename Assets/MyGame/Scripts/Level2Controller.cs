using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Controller : MonoBehaviour
{
    private GameObject player = null;

    void Start ()
    {
        Debug.Log("IN LEVEL 2");
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene ().name;
        LevelManager.Instance.MaxCollectibles = 1;
        player = LevelManager.Instance.Player;
        player.GetComponent<Transform>().position = LevelManager.Instance.GetPlayerInitPosition();
        player.GetComponent<Transform>().rotation = LevelManager.Instance.GetPlayerInitRotation();
    }



}
