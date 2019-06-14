using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time = 0.0f;

	void Update ()
    {
        time = time + Time.deltaTime;
	}

    public void ResetTimer()
    {
        time = 0.0f;
    }

    public string GetTime()
    {
        return time.ToString("00:00:00");
    }
}
