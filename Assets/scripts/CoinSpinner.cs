using UnityEngine;

public class CoinSpinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Rotate the coin around the Y-axis forever
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
