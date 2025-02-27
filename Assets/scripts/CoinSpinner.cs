using UnityEngine;

public class CoinSpinner : MonoBehaviour
{
    [SerializeField] private int rotationSpeedValue = 100; // Editable in Inspector
    private Vector3 rotationSpeed;

    void Start()
    {
        rotationSpeed = new Vector3(0, rotationSpeedValue, 0);
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
