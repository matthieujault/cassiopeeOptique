/*using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float scrollSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Debug.Log("Camera script running");
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) input.y++;
        if (Keyboard.current.sKey.isPressed) input.y--;
        if (Keyboard.current.dKey.isPressed) input.x++;
        if (Keyboard.current.aKey.isPressed) input.x--;

        float scroll = Mouse.current.scroll.ReadValue().y;


 
        Vector3 movement = new Vector3(input.x, 0, input.y).normalized;
        Vector3 movementVert = new Vector3(0, scroll, 0).normalized;

        //Debug.Log(movement);

        rb.MovePosition(
            rb.position + movement * moveSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(
            rb.position + movementVert * scrollSpeed * Time.fixedDeltaTime
        );

    }
}
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float zoomSpeed = 5f;

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) input.y++;
        if (Keyboard.current.sKey.isPressed) input.y--;
        if (Keyboard.current.aKey.isPressed) input.x--;
        if (Keyboard.current.dKey.isPressed) input.x++;

        Vector3 movement = new Vector3(input.x, 0f, input.y).normalized;

        // WASD movement
        transform.position += movement * moveSpeed * Time.deltaTime;

        // Mouse wheel zoom (up/down on Y axis)
        float scroll = Mouse.current.scroll.ReadValue().y;

        if (scroll != 0)
        {
            transform.position += Vector3.up * scroll * zoomSpeed * Time.deltaTime;
        }
    }
}