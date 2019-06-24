using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IdleController : MonoBehaviour
{
    private GameObject player = null;
    public TextMeshProUGUI levelLockedText;

    void Start ()
    {
        LevelManager.Instance.CurrentScene = SceneManager.GetActiveScene().name;
        player = LevelManager.Instance.Player;
        player.GetComponent<Transform>().position = LevelManager.Instance.QuillPosition;
        player.GetComponent<Transform>().rotation = LevelManager.Instance.QuillRotation;

        UpdateLevel1Unlocked();
    }

    public void UpdateLevel1Unlocked()
    {
        if (LevelManager.Instance.CheckLevelUnlocked(1))
        {
            levelLockedText.text = "Unlocked";
        }
    }
	
}
