using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoradManager : MonoBehaviour
{
    [SerializeField] private int _maxY;
    [SerializeField] private int _maxX;

    private GameObject[,] _tiles;
    // Start is called before the first frame update
    void Start()
    {
        _tiles = new GameObject[_maxX, _maxY];
        int counter = 0;
        for (int i = 0; i < _maxX; i++)
        {
            for (int j = 0; j < _maxY; j++)
            {
                _tiles[i, j] = transform.GetChild(counter).gameObject;
                counter += 1;
            }
        }
    }

    public void placeTile(int x, int y, GameObject item)
    {
        GameObject tile = Instantiate(item, _tiles[x, y].transform.position, Quaternion.identity);
        tile.transform.SetParent(_tiles[x, y].transform);
    }
}
