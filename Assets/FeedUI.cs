using UnityEngine;

public class FeedUI : MonoBehaviour
{
    public GameObject feedText;

    public void ShowText()
    {
        if (feedText == null) return;

        feedText.SetActive(true);
    }

    public void HideText()
    {
        if (feedText == null) return;

        feedText.SetActive(false);
    }
}

