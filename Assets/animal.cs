using UnityEngine;


public class animal : MonoBehaviour
{
    public string correctFood;
    public string displayName;
    public Vector3 labelOffset = new Vector3(0f, 1.4f, 0f);

    public FeedUI feedUI;
    public PopupUI popupUI;

    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    private bool playerNear = false;
    private PlayerCarry player;
    private GUIStyle labelStyle;

    void OnTriggerEnter(Collider other)
    {
        PlayerCarry p = other.GetComponent<PlayerCarry>();

        if (p != null)
        {
            playerNear = true;
            player = p;

            if (feedUI != null && p.HasItem())
            {
                feedUI.ShowText();
            }

            Debug.Log("Hayvana yaklaştın");
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerCarry p = other.GetComponent<PlayerCarry>();

        if (p != null)
        {
            playerNear = false;
            player = null;

            if (feedUI != null)
            {
                feedUI.HideText();
            }
        }
    }

    void Update()
    {
        if (playerNear && player != null)
        {
            if (player.HasItem())
            {
                if (feedUI != null)
                {
                    feedUI.ShowText();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    string food = player.GetItemName();

                    Feed(food);

                    player.Drop();

                    if (feedUI != null)
                    {
                        feedUI.HideText();
                    }
                }
            }
            else
            {
                if (feedUI != null)
                {
                    feedUI.HideText();
                }
            }
        }
    }

    void OnGUI()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null) return;

        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position + labelOffset);
        if (screenPosition.z <= 0) return;

        if (labelStyle == null)
        {
            labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.alignment = TextAnchor.MiddleCenter;
            labelStyle.fontSize = 28;
            labelStyle.fontStyle = FontStyle.Bold;
        }

        string label = string.IsNullOrWhiteSpace(displayName) ? gameObject.name : displayName;
        float width = 140f;
        float height = 34f;
        Rect rect = new Rect(screenPosition.x - width / 2f, Screen.height - screenPosition.y - height / 2f, width, height);

        labelStyle.normal.textColor = Color.black;
        GUI.Label(new Rect(rect.x + 2f, rect.y + 2f, rect.width, rect.height), label, labelStyle);

        labelStyle.normal.textColor = Color.white;
        GUI.Label(rect, label, labelStyle);
    }

    public void Feed(string foodName)
    {
        string selectedFood = foodName.Trim().ToLower();
        string neededFood = correctFood.Trim().ToLower();

        if (selectedFood == neededFood)
        {
            Debug.Log("DOĞRU!");

            if (popupUI != null)
            {
                popupUI.ShowCorrect();
            }

            if (audioSource != null && correctSound != null)
            {
                audioSource.PlayOneShot(correctSound);
            }

            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(10);
            }
        }
        else
        {
            Debug.Log("YANLIŞ!");

            if (popupUI != null)
            {
                popupUI.ShowWrong();
            }

            if (audioSource != null && wrongSound != null)
            {
                audioSource.PlayOneShot(wrongSound);
            }

            if (GameManager.instance != null)
            {
                GameManager.instance.AddWrong();
            }
        }
    }
}

