using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public Ball editBall;
    public Timer editTimer;
    public TextMeshProUGUI modeLabel;
    public TextMeshProUGUI timerLabel;
    private bool modeToggled = false;

    private void Start()
    {
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
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
