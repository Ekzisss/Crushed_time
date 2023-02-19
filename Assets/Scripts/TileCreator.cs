using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    // [SerializeField] private int _height, _width;

    // [SerializeField] private Tile _tile;

    // [SerializeField] private Color _color1;
    // [SerializeField] private Color _color2;

    // // [SerializeField] private Transform cam;
    // // private int x, y;

    // private float _tileHight;
    // private float _tileWidth;

    // // 537, 336
    // // 1611, 1008

    // void Start()
    // {
    //     _tileHight = 908f / ((float)_height * 100f);
    //     _tileWidth = 1611f / ((float)_width * 100f);
    //     Debug.Log(Screen.width);
    //     Debug.Log(Screen.height);
    //     createGrid();
    // }

    // void createGrid()
    // {
    //     float _tilePosX = 0;
    //     float _tilePosY = 0;
    //     for (float x = 0; x < _width; x++)
    //     {
    //         for (float y = 0; y < _height; y++)
    //         {
    //             var gridTile = Instantiate(_tile, new Vector3(_tilePosX + transform.position.x + (_tileWidth / 2), _tilePosY + transform.position.y + (_tileHight / 2)), Quaternion.identity);
    //             gridTile.transform.localScale = new Vector3(_tileWidth, _tileHight, 1);
    //             gridTile.name = $"Tile {x} {y}";

    //             if ((x % 2 == 0 & y % 2 != 0) || (y % 2 == 0 & x % 2 != 0))
    //             {
    //                 gridTile.GetComponent<SpriteRenderer>().color = _color2;
    //             }
    //             else
    //             {
    //                 gridTile.GetComponent<SpriteRenderer>().color = _color1;
    //             }

    //             _tilePosY += _tileHight;
    //         }
    //         _tilePosX += _tileWidth;
    //         _tilePosY = 0;
    //     }

    //     // cam.position = new Vector3((_width) / 2 - 0.5f, (_height) / 2 - 0.5f, -10f);
    // }
}
