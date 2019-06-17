using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public GameObject player = null;
    public GameObject initialPlayerPosition;

    private void Awake()
    {
        player = GameObject.Find("Player");
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        player.GetComponent<Transform>().position = initialPlayerPosition.GetComponent<Transform>().position;
    }

}
