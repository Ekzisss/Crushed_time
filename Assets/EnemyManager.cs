using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyMapObj EnemyInfo;

    private Transform player;

    void Start()
    {
        gameObject.name = EnemyInfo.name;
        GetComponent<SpriteRenderer>().sprite = EnemyInfo.sprite;
        player = GameObject.FindWithTag("Hero").transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * Time.fixedDeltaTime);
    }
}
