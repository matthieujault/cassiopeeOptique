using UnityEngine;
using UnityEngine.UI;

public class LensItemUI : MonoBehaviour
{
    public string lensName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Debug.Log("CLICK");

        UIInventoryManager manager = FindFirstObjectByType<UIInventoryManager>();
        manager.AddLens(lensName);
    }
}