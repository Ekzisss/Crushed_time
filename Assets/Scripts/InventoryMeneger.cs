using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMeneger : MonoBehaviour
{
    [SerializeField] private List<Transform> slots;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            slots.Add(transform.GetChild(i).transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void placeItem(GameObject item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                item.transform.SetParent(slots[i].transform);
                item.transform.localPosition = new Vector3(0, 0, 0);
                break;
            }
            if (i == slots.Count - 1)
            {
                Debug.Log(slots[slots.Count - 1].transform.GetChild(0));
                Transform b = slots[slots.Count - 1].transform.GetChild(0);
                b.SetParent(null);
                Destroy(b.gameObject);
                for (int j = slots.Count - 2; j >= 0; j--)
                {
                    Debug.Log(j);
                    slots[j].transform.GetChild(0).SetParent(slots[j + 1].transform);
                    slots[j + 1].transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                }
                Debug.Log(slots.Count);
                Transform a = slots[slots.Count - 1].transform.GetChild(0);
                a.localPosition.Set(0, 0, 0);
                item.transform.SetParent(slots[0].transform);
                item.transform.localPosition = new Vector3(0, 0, 0);
                slots[11].transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                break;
            }
        }
    }
}
