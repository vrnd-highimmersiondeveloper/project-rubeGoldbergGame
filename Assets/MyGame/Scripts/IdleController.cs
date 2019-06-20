using UnityEngine;

public class IdleController : MonoBehaviour
{
    private GameObject player = null;

    void Start ()
    {
        player = LevelManager.Instance.Player;
        player.GetComponent<Transform>().position = LevelManager.Instance.QuillPosition;
    }
	
}
