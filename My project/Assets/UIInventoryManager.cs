using UnityEngine;

public class UIInventoryManager : MonoBehaviour
{
    public Transform inventoryContent;   // Le panel de droite
    public GameObject lensItemPrefab;    // Le prefab LensItem

    public void AddLens(string lensName)
    {
        Debug.Log("Ajout lentille : " + lensName);

        GameObject newLens = Instantiate(lensItemPrefab, inventoryContent);

        TMPro.TextMeshProUGUI text = newLens.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (text != null)
        {
            text.text = lensName;
        }
    }
}