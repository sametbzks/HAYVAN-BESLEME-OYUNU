using UnityEngine;
using System.Collections;

public class PopupUI : MonoBehaviour
{
    public GameObject correctText;
    public GameObject wrongText;


    public void ShowCorrect()
    {
        if (correctText == null) return;

        StartCoroutine(ShowPopup(correctText));

    }

    public void ShowWrong()
    {
        if (wrongText == null) return;

        StartCoroutine(ShowPopup(wrongText));
    }

    IEnumerator ShowPopup(GameObject popup)
    {
        popup.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        popup.SetActive(false);
    }
}

