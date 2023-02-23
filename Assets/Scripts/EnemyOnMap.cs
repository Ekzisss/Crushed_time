using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnMap : MonoBehaviour
{
    public EnemyMapObj EnemyMapObj;


    private void Start()
    {
        gameObject.name = EnemyMapObj.name;
        gameObject.GetComponent<SpriteRenderer>().sprite = EnemyMapObj.sprite;
    }
}
