using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EquipmentManager : MonoBehaviour
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

    // // The mesh goes red when the mouse is over it...
    // void OnMouseEnter()
    // {
    //     foreach (var item in slots)
    //     {
    //         item.GetComponent<Image>().tintColor = Color.red;
    //     }
    // }

    // // ...the red fades out to cyan as the mouse is held over...
    // void OnMouseOver()
    // {
    //     foreach (var item in slots)
    //     {
    //         item.GetComponent<Image>().tintColor = Color.green;
    //     }
    // }

    // // ...and the mesh finally turns white when the mouse moves away.
    // void OnMouseExit()
    // {
    //     foreach (var item in slots)
    //     {
    //         GetComponent<Image>().tintColor = Color.cyan;
    //     }
    // }
}
