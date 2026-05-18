using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (scoreText == null || GameManager.instance == null) return;

        scoreText.text = "Skor: " + GameManager.instance.score + "  Yanlis: " + GameManager.instance.wrongCount;
    }
}

