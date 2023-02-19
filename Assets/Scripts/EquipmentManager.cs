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
}
