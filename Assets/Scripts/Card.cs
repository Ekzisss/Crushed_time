using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Tile tile;
    private Canvas canvas;

    private SpriteRenderer sprite;

    private Vector3 mousePos;

    private GameObject projection;
    private Transform lastTile;
    private bool onRoad = false;
    private bool nearRoad = false;
    private List<Transform> nearPath;

    private GameObject[,] _tiles;

    private List<GameObject> baseFrame = new List<GameObject>();
    [SerializeField] private GameObject frame;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        nearPath = GameObject.FindWithTag("Main").GetComponent<MainParameters>().nearPath;
        _tiles = GameObject.FindWithTag("Main").GetComponent<MainParameters>()._tiles;
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.7f);

        projection = Instantiate(Resources.Load("TileBase") as GameObject, new Vector3(100, 100, 0), Quaternion.identity);
        projection.GetComponent<TileManager>().tile = tile;
        if (projection.GetComponent<TileManager>().tile.tileType == tileType.Spawner && projection.GetComponent<TileManager>().tile.spawnerType == spawnerType.OnRoad)
        {
            onRoad = true;
        }
        else if (projection.GetComponent<TileManager>().tile.tileType == tileType.Spawner && projection.GetComponent<TileManager>().tile.spawnerType == spawnerType.NearRoad)
        {
            nearRoad = true;
        }
        projection.GetComponent<TileManager>()._isProjection = true;
        projection.transform.localScale = new Vector3(0.7671428f, 0.7671428f, 1);
        createFrame();
    }

    private void OnMouseDrag()
    {
        gameObject.transform.position = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)) * canvas.gameObject.transform.localScale.x;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, 2.5f, (int)LayerMask.GetMask("Tile"));
        if (onRoad)
        {
            if (hit.collider != null && hit.transform.childCount == 1 && hit.transform.GetChild(0).GetComponent<road>())
            {
                canPlace(hit);
            }
            else
            {
                lastTile = null;
                projection.transform.position = new Vector3(100, 100, 0);
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (nearRoad)
        {
            if (hit.collider != null && hit.transform.childCount == 0 && nearPath.Contains(hit.transform))
            {
                canPlace(hit);
            }
            else
            {
                lastTile = null;
                projection.transform.position = new Vector3(100, 100, 0);
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            if (hit.collider != null && hit.transform.childCount == 0 && !nearPath.Contains(hit.transform))
            {
                canPlace(hit);
            }
            else
            {
                lastTile = null;
                projection.transform.position = new Vector3(100, 100, 0);
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void OnMouseUp()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        transform.localPosition = Vector3.zero;
        clearFrames();
        if (lastTile)
        {
            DestroyImmediate(projection);
            place();
        }
    }

    private void place()
    {
        if (onRoad)
        {
            GameObject obj = Instantiate(Resources.Load("TileBase") as GameObject, lastTile.position, lastTile.GetChild(0).rotation, lastTile);
            obj.GetComponent<TileManager>().tile = tile;
            if (lastTile.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name == "roads_0")
            {
                obj.GetComponent<TileManager>()._isCorner = true;
            }
        }
        else if (nearRoad)
        {
            GameObject obj = Instantiate(Resources.Load("TileBase") as GameObject, lastTile.position, Quaternion.identity, lastTile);
            obj.GetComponent<TileManager>().tile = tile;
        }
        else
        {

        }
        DestroyImmediate(gameObject);
    }

    private void canPlace(RaycastHit2D hit)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        lastTile = hit.transform;
        projection.transform.position = hit.transform.position;

        if (onRoad)
        {
            projection.transform.rotation = hit.transform.GetChild(0).rotation;
            // Debug.Log(hit.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name);
            if (hit.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name == "roads_0")
            {
                projection.GetComponent<TileManager>().setSprite2();
            }
            else
            {
                projection.GetComponent<TileManager>().setSprite1();
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log("placed");
    }

    private void createFrame()
    {
        for (int i = 0; i < _tiles.GetLength(0); i++)
        {
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                if (onRoad)
                {
                    if (_tiles[i, j].transform.childCount == 1 && _tiles[i, j].transform.GetChild(0).GetComponent<road>())
                    {
                        // GameObject a = Instantiate(frame, _tiles[i, j].transform.position, Quaternion.identity);
                        baseFrame.Add(Instantiate(frame, _tiles[i, j].transform.position, Quaternion.identity));
                    }
                }
                else if (nearRoad)
                {
                    if (_tiles[i, j].transform.childCount == 0 && nearPath.Contains(_tiles[i, j].transform))
                    {
                        // GameObject a = Instantiate(frame, _tiles[i, j].transform.position, Quaternion.identity);
                        baseFrame.Add(Instantiate(frame, _tiles[i, j].transform.position, Quaternion.identity));
                    }
                }
                else
                {
                    if (_tiles[i, j].transform.childCount == 0 && !nearPath.Contains(_tiles[i, j].transform))
                    {
                        // GameObject a = Instantiate(frame, _tiles[i, j].transform.position, Quaternion.identity);
                        baseFrame.Add(Instantiate(frame, _tiles[i, j].transform.position, Quaternion.identity));
                    }
                }
            }
        }
    }

    private void clearFrames()
    {
        foreach (var item in baseFrame)
        {
            DestroyImmediate(item);
        }
        // baseFrame.Clear();
    }
}
