using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleController : MonoBehaviour
{
    private GameObject player = null;

    void Start ()
    {
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
        player = LevelManager.Instance.Player;
        player.GetComponent<Transform>().position = LevelManager.Instance.QuillPosition;
        player.GetComponent<Transform>().rotation = LevelManager.Instance.QuillRotation;
    }
	
}
