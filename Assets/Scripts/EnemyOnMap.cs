using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnMap : MonoBehaviour
{
    public EnemyInfo EnemyInfo;


    private void Start()
    {
        gameObject.name = EnemyInfo.name;
        gameObject.GetComponent<SpriteRenderer>().sprite = EnemyInfo.sprite;
    }
}
