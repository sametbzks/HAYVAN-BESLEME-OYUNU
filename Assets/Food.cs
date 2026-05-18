using UnityEngine;

public class Food : MonoBehaviour
{
    public string foodName;
    public float pickUpDistance = 3f;

    void OnMouseDown()
    {
        PlayerCarry player = Object.FindFirstObjectByType<PlayerCarry>();

        if (player == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= pickUpDistance)
        {
            player.PickUp(gameObject);
        }
        else
        {
            Debug.Log("Çok uzaksın!");
        }
    }

    public string GetFoodName()
    {
        if (!string.IsNullOrWhiteSpace(foodName))
        {
            return foodName.Trim().ToLower();
        }

        return gameObject.name.Replace("(Clone)", "").Trim().ToLower();
    }
}

