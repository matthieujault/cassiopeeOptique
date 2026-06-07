using UnityEngine;

public class MenuWidth : MonoBehaviour
{
    public float menuWidth = 300f;

    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, menuWidth);
    }
}