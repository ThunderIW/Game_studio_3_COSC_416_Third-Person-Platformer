using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody PlayerRB;
    [SerializeField] private float playerMovementSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    private int jumpCount = 0;
    private int maxJumps = 2;

    public void movePlayer(Vector2 input)
    {
        Vector3 inputxyz = new(input.x, 0, input.y);
        PlayerRB.AddForce(inputxyz * playerMovementSpeed);
    }

    public void jumpPlayer()
    {
        if (jumpCount < maxJumps)
        {
            PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
        }
    }
}
