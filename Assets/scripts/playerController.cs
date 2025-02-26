using UnityEngine;
using Unity.Cinemachine; // ✅ Correct Cinemachine import

public class playerController : MonoBehaviour
{
    [SerializeField] private Rigidbody PlayerRB;
    [SerializeField] private float playerMovementSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private CinemachineCamera freeLookCamera; // ✅ Fixed Cinemachine type
    [SerializeField] private Transform aimingIndicator; // 🎯 Aiming system

    private int jumpCount = 0;
    private int maxJumps = 2;
    private Vector2 inputDirection = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }



    public void escapeFromCursorLock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }


    public void MovePlayer(Vector2 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.y);
        PlayerRB.AddForce((aimingIndicator.forward * input.y + aimingIndicator.right * input.x) * playerMovementSpeed, ForceMode.Acceleration);

    }





    public void JumpPlayer()
    {
        if (jumpCount < maxJumps)
        {
            PlayerRB.linearVelocity = new Vector3(PlayerRB.linearVelocity.x, 0, PlayerRB.linearVelocity.z);
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
