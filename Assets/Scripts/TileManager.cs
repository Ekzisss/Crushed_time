using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile tile;

    void Start()
    {
        gameObject.name = tile.name;

        // GetComponent<SpriteRenderer>().sprite = tile.sprite;

        if (tile.tileType == tileType.Spawner)
        {
            StartCoroutine(startSpawn());
        }
    }

    // void Spowner()
    // {
    //     StartCoroutine(startSpawn());
    // }

    private IEnumerator startSpawn()
    {
        Debug.Log("started");
        while (true)
        {
            yield return new WaitForSeconds(tile.spawnerCooldown);

            Instantiate(Resources.Load("EnemyBase") as GameObject, transform.position, Quaternion.identity);

            Debug.Log("spwned");
        }
    }
}
