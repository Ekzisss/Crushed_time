using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyMapObj EnemyInfo;

    void Start()
    {
        gameObject.name = EnemyInfo.name;
        GetComponent<SpriteRenderer>().sprite = EnemyInfo.sprite;
    }
}
