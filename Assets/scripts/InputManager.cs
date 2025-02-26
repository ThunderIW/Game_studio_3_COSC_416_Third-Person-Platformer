using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnJump = new UnityEvent();
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) inputVector += Vector2.up;
        if (Input.GetKey(KeyCode.S)) inputVector += Vector2.down;
        if (Input.GetKey(KeyCode.A)) inputVector += Vector2.left;
        if (Input.GetKey(KeyCode.D)) inputVector += Vector2.right;

        if (inputVector != Vector2.zero)
        {
            OnMove?.Invoke(inputVector);

        }

        // 🔴 This line was missing! It invokes the event to notify the playerController.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnJump?.Invoke();

        }


    }
}
