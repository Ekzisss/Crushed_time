using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile tile;
    public bool _isProjection = false;
    public bool _isCorner = false;

    private GameObject[,] _tiles;

    private GameObject upper;
    private GameObject bottom;
    private GameObject left;
    private GameObject right;

    private List<GameObject> NearSpawnerPlaces = new List<GameObject>();

    void Start()
    {
        _tiles = GameObject.FindWithTag("Main").GetComponent<MainParameters>()._tiles;
        gameObject.name = tile.name;
        if (!_isCorner)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tile.sprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tile.sprite2;
        }

        if (_isProjection)
        {
            // gameObject.GetComponent<SpriteRenderer>().color = new Color32(31, 94, 48, 255);
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
            GetComponent<TileManager>().enabled = false;
        }
        else
        {
            if (tile.tileType == tileType.Spawner)
            {
                switch (tile.spawnerType)
                {
                    case spawnerType.OnRoad:
                        StartCoroutine(startSpawnOnRoad());
                        break;
                    case spawnerType.NearRoad:
                        StartCoroutine(startSpawnNearRoad());
                        break;
                    case spawnerType.AwayRoad:
                        StartCoroutine(startSpawnAwayRoad());
                        break;
                }
            }
        }
    }

    private IEnumerator startSpawnOnRoad()
    {
        // Debug.Log("started");
        while (true)
        {
            yield return new WaitForSeconds(tile.spawnerCooldown);

            GameObject enemy = Instantiate(Resources.Load("EnemyBase") as GameObject, transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyOnMap>().EnemyMapObj = tile.EnemyMapObj;

            // Debug.Log("spwned");
        }
    }

    private IEnumerator startSpawnNearRoad()
    {
        for (int i = 0; i < _tiles.GetLength(0); i++)
        {
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                if (_tiles[i, j].Equals(transform.parent.gameObject))
                {
                    if (_tiles[i + 1, j].transform.childCount == 2 ||
                        (_tiles[i + 1, j].transform.childCount == 1 &&
                        _tiles[i + 1, j].transform.name == "road"))
                    {
                        right = _tiles[i + 1, j];
                        NearSpawnerPlaces.Add(_tiles[i + 1, j]);
                    }

                    if (_tiles[i - 1, j].transform.childCount == 2 ||
                        (_tiles[i - 1, j].transform.childCount == 1 &&
                        _tiles[i - 1, j].transform.name == "road"))
                    {
                        left = _tiles[i - 1, j];
                        NearSpawnerPlaces.Add(_tiles[i - 1, j]);
                    }

                    if (_tiles[i, j + 1].transform.childCount == 2 ||
                        (_tiles[i, j + 1].transform.childCount == 1 &&
                        _tiles[i, j + 1].transform.name == "road"))
                    {
                        upper = _tiles[i, j + 1];
                        NearSpawnerPlaces.Add(_tiles[i, j + 1]);
                    }

                    if (_tiles[i, j - 1].transform.childCount == 2 ||
                        (_tiles[i, j - 1].transform.childCount == 1 &&
                        _tiles[i, j - 1].transform.name == "road"))
                    {
                        bottom = _tiles[i, j - 1];
                        NearSpawnerPlaces.Add(_tiles[i, j - 1]);
                    }
                    break;
                }
            }
        }

        while (true)
        {
            yield return new WaitForSeconds(tile.spawnerCooldown);

            Random.Range(0, NearSpawnerPlaces.Count);

            GameObject enemy = Instantiate(Resources.Load("EnemyBase") as GameObject, NearSpawnerPlaces[Random.Range(0, NearSpawnerPlaces.Count)].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyOnMap>().EnemyMapObj = tile.EnemyMapObj;
        }
    }

    private IEnumerator startSpawnAwayRoad()
    {
        // Debug.Log("started");
        List<Transform> path = GameObject.FindWithTag("Main").GetComponent<MainParameters>().path;

        while (true)
        {
            yield return new WaitForSeconds(tile.spawnerCooldown);

            Random.Range(0, path.Count);

            GameObject enemy = Instantiate(Resources.Load("EnemyBase") as GameObject, path[Random.Range(0, path.Count)].position, Quaternion.identity);
            enemy.GetComponent<EnemyOnMap>().EnemyMapObj = tile.EnemyMapObj;
        }
    }

    public void setSprite1()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tile.sprite;
    }

    public void setSprite2()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tile.sprite2;
    }
}
