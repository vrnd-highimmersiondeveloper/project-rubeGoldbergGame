using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public Ball editBall;
    public Timer editTimer;
    public GameObject initialPlayerPosition;
    public TextMeshProUGUI modeLabel;
    public TextMeshProUGUI timerLabel;
    public GameObject mySimpleConstructionItemManager;
    private bool modeToggled = false;
    private GameObject myPlayer;
    private GameObject rightHand;
    private GameObject leftHand;

    private void Start()
    {
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
        myPlayer = GameObject.Find("Player");
        myPlayer.GetComponent<Transform>().position = initialPlayerPosition.GetComponent<Transform>().position;
        myPlayer.GetComponent<Transform>().rotation = initialPlayerPosition.GetComponent<Transform>().rotation;

        rightHand = GameObject.Find("RightHand");
        leftHand = GameObject.Find("LeftHand");

        GameObject obj = (GameObject)Instantiate(mySimpleConstructionItemManager);
        obj.transform.parent = rightHand.transform;
        obj.transform.localPosition = new Vector3(0.0f, -0.6f, 0f);
        obj.transform.localRotation = Quaternion.Euler(-90.0f, 0.0f, 180.0f);
            
        obj.SetActive(true);
        //Transform[] objPreview = obj.GetComponentsInChildren<Transform>();
        //foreach (Transform child in objPreview)
        //{
        //    child.gameObject.SetActive(true);
        //}

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
