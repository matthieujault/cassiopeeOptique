using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FixedMenuWidth : MonoBehaviour
{
    public float menuWidth = 300f;

    RectTransform rt;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, menuWidth);
    }
}