using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        transform.Translate(move.normalized * speed * Time.deltaTime);
    }
}

