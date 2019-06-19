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
        player = GameObject.Find(MyConstManager.TagPLAYER);
        simpleCIMenu = GameObject.Find("SimpleConstructionItemManager");

        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
        LevelManager.Instance.RightHand = rightHand;
        LevelManager.Instance.LeftHand = leftHand;
        LevelManager.Instance.SimpleCIMenu = simpleCIMenu;
    }

    private void Start()
    {
        player.GetComponent<Transform>().position = initialPlayerPosition.GetComponent<Transform>().position;
    }

}
