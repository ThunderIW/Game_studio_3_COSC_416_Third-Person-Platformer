using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnJump = new UnityEvent();
    public UnityEvent OnDash = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
  

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

        // ✅ Fix: Use `GetKeyDown()` instead of `GetKeyUp()`
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
       

        if (Input.GetKeyDown(KeyCode.LeftShift)) { 
            OnDash?.Invoke();
        }
       

    }
}
