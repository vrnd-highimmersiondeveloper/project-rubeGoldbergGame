using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public GameObject player = null; 
    public GameObject leftHand = null;
    public GameObject rightHand = null;
    public GameObject simpleCIMenu = null;

    public GameObject initialPlayerPosition;

    private void Awake()
    {
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
        LevelManager.Instance.Player = player;
        LevelManager.Instance.RightHand = rightHand;
        LevelManager.Instance.LeftHand = leftHand;
        LevelManager.Instance.SimpleCIMenu = simpleCIMenu;
        Debug.Log("initioal position .......................");
        LevelManager.Instance.QuillPosition = initialPlayerPosition.GetComponent<Transform>().position;
       // LevelManager.Instance.QuillRotation = initialPlayerPosition.GetComponent<Transform>().rotation;
    }

    private void Start()
    {
        player.GetComponent<Transform>().position = initialPlayerPosition.GetComponent<Transform>().position;
    }

}
