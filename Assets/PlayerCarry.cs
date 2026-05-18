using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    public Transform handPoint;
    public ItemUI itemUI;

    private GameObject carriedItem;

    void Awake()
    {
        if (itemUI == null)
        {
            itemUI = Object.FindFirstObjectByType<ItemUI>();
        }
    }

    public void PickUp(GameObject item)
    {

        if (carriedItem != null || item == null || handPoint == null) return;

        carriedItem = item;

        // Ele bağla
        item.transform.SetParent(handPoint);

        // Pozisyon sıfırla
        item.transform.localPosition = Vector3.zero;

        // Dönüşü düzelt
        item.transform.localRotation = Quaternion.identity;

        // Fizik kapat
        Rigidbody rb = item.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;

            // Dönmeyi tamamen kilitle
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        // Çarpışma kapat
        Collider col = item.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }

        if (itemUI != null)
        {
            itemUI.ShowItem(GetItemName());
        }
    }

    public void Drop()
    {
        if (carriedItem == null) return;

        carriedItem.transform.SetParent(null);

        Rigidbody rb = carriedItem.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            // Kilitleri kaldır
            rb.constraints = RigidbodyConstraints.None;
        }

        Collider col = carriedItem.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = true;
        }

        carriedItem = null;

        if (itemUI != null)
        {
            itemUI.HideItem();
        }
    }

    public string GetItemName()
    {
        if (carriedItem == null) return "";

        Food food = carriedItem.GetComponent<Food>();
        if (food != null)
        {
            return food.GetFoodName();
        }

        return carriedItem.name.Replace("(Clone)", "").Trim().ToLower();
    }

    public bool HasItem()
    {
        return carriedItem != null;
    }
}
