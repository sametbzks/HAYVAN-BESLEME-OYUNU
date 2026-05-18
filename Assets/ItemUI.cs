using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image itemIcon;

    public Sprite carrotSprite;
    public Sprite fishSprite;

    void Start()
    {
        HideItem();
    }

    public void ShowItem(string itemName)
    {
        if (itemIcon == null) return;

        Sprite selectedSprite = null;
        if (itemName.ToLower().Contains("carrot"))
        {
            selectedSprite = carrotSprite;
        }
        else if (itemName.ToLower().Contains("fish"))
        {
            selectedSprite = fishSprite;
        }

        if (selectedSprite == null)
        {
            HideItem();
            return;
        }

        itemIcon.sprite = selectedSprite;
        itemIcon.enabled = true;
        itemIcon.preserveAspect = true;
        itemIcon.color = Color.white;
        itemIcon.gameObject.SetActive(true);
    }

    public void HideItem()
    {
        if (itemIcon == null) return;

        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemIcon.color = new Color(1f, 1f, 1f, 0f);
    }
}
