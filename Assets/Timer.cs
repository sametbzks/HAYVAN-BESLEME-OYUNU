using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public Text timerText;

    void Update()
    {
        if (timeLeft <= 0) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(timeLeft, 0);

        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(timeLeft).ToString();
        }

        if (timeLeft <= 0)
        {
            Debug.Log("Süre bitti!");
        }
    }
}

