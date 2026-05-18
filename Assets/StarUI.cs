using UnityEngine;
using UnityEngine.UI;

public class StarUI : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;

    void Update()
    {
        if (GameManager.instance == null) return;

        int score = GameManager.instance.score;

        if (star1 != null) star1.gameObject.SetActive(score >= 10);
        if (star2 != null) star2.gameObject.SetActive(score >= 20);
        if (star3 != null) star3.gameObject.SetActive(score >= 30);
    }
}

