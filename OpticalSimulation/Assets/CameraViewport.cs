using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraViewport : MonoBehaviour
{
    [Header("Menu Width (pixels)")]
    public float menuWidth = 300f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        UpdateViewport();
    }

    void Update()
    {
        UpdateViewport();
    }

    void UpdateViewport()
    {
        float x = menuWidth / Screen.width;

        cam.rect = new Rect(
            x,        // start after the menu
            0f,       // bottom
            1f - x,   // remaining width
            1f        // full height
        );
    }
}