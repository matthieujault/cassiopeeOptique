using UnityEngine;
using UnityEngine.EventSystems;

public class TrashZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableLens draggedLens = eventData.pointerDrag.GetComponent<DraggableLens>();

        if (draggedLens != null)
        {
            Debug.Log("Lentille supprimée");
            Destroy(draggedLens.gameObject);
        }
    }
}