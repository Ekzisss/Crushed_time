using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NaughtyAttributes;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject content;

    [SerializeField] private bool Inventory;

    [HideIf("Inventory")]
    [Header("Equipment")]
    [SerializeField] private ItemType ItemType;
    [SerializeField, HideIf("Inventory")] private ArmorType ArmorType;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag);
        if (!Inventory && eventData.pointerDrag.GetComponent<Item>().ItemType == ItemType)
        {
            if (eventData.pointerDrag.GetComponent<Item>().ItemType == ItemType.Armor &&
                eventData.pointerDrag.GetComponent<Item>().ArmorType != ArmorType)
            {
                return;
            }
            checkItem();
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.localPosition = new Vector3(0, 0, 0);
            eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;
        }
    }

    private void checkItem()
    {
        if (transform.childCount != 0)
        {
            Destroy(transform.GetChild(0));
        }
    }
}