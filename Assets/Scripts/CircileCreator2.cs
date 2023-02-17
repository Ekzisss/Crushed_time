using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircileCreator2 : MonoBehaviour
{
    [SerializeField] private int _maxY;
    [SerializeField] private int _maxX;

    private GameObject[,] _tiles;

    private int x;
    private int y;

    private int _xHalf;
    private int _yHalf;

    private int _boxHeight;
    private int _boxWidth;

    private int _yUpperCord;
    private int _yBottomCord;
    private int _xRightCord;
    private int _xLeftCord;

    private int[,] startCord = new int[4, 2];
    private int[,] endCord = new int[4, 2];
    // Start is called before the first frame update
    void Start()
    {
        _xHalf = _maxX / 2;
        _yHalf = _maxY / 2;

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

        _boxWidth = Random.Range(_maxX - 12, _maxX - 7);
        if (_boxWidth <= 10)
        {
            _boxHeight = Random.Range(_maxY - 1, _maxY);
        }
        else if (_boxWidth >= 13)
        {
            _boxHeight = Random.Range(_maxY - 4, _maxY - 2);
        }
        else
        {
            _boxHeight = Random.Range(_maxY - 3, _maxY - 1);
        }

        _yUpperCord = (int)(_maxY / 2f + _boxHeight / 2f) - 1;
        _yBottomCord = (int)(_maxY / 2f - _boxHeight / 2f);
        _xRightCord = (int)(_maxX / 2f + _boxWidth / 2f) - 1;
        _xLeftCord = (int)(_maxX / 2f - _boxWidth / 2f);

        int a = 4;
        int roadOnBox = Random.Range(3, _boxWidth - a);
        int space = Random.Range(1, _boxWidth - roadOnBox - 1);

        startCord[0, 0] = _xLeftCord + space;
        startCord[0, 1] = _yUpperCord;

        for (int i = space; i < space + roadOnBox; i++)
        {
            _tiles[_xLeftCord + i, _yUpperCord].GetComponent<SpriteRenderer>().color = new Color(203, 175, 81, 1);

            if (i == space + roadOnBox - 1)
            {
                endCord[0, 0] = _xLeftCord + i;
                endCord[0, 1] = _yUpperCord;
            }
        }

        roadOnBox = Random.Range(3, _boxWidth - a);
        space = Random.Range(1, _boxWidth - roadOnBox - 1);

        startCord[2, 0] = _xLeftCord + space;
        startCord[2, 1] = _yBottomCord;

        for (int i = space; i < space + roadOnBox; i++)
        {
            _tiles[_xLeftCord + i, _yBottomCord].GetComponent<SpriteRenderer>().color = new Color(203, 175, 81, 1);

            if (i == space + roadOnBox - 1)
            {
                endCord[2, 0] = _xLeftCord + i;
                endCord[2, 1] = _yBottomCord;
            }
        }

        roadOnBox = Random.Range(3, _boxHeight - a);
        space = Random.Range(1, _boxHeight - roadOnBox - 1);

        startCord[3, 0] = _xLeftCord;
        startCord[3, 1] = _yBottomCord + space;

        for (int i = space; i < space + roadOnBox; i++)
        {
            _tiles[_xLeftCord, _yBottomCord + i].GetComponent<SpriteRenderer>().color = new Color(203, 175, 81, 1);

            if (i == space + roadOnBox - 1)
            {
                endCord[3, 0] = _xLeftCord;
                endCord[3, 1] = _yBottomCord + i;
            }
        }

        roadOnBox = Random.Range(3, _boxHeight - a);
        space = Random.Range(1, _boxHeight - roadOnBox - 1);

        startCord[1, 0] = _xRightCord;
        startCord[1, 1] = _yBottomCord + space;

        for (int i = space; i < space + roadOnBox; i++)
        {
            _tiles[_xRightCord, _yBottomCord + i].GetComponent<SpriteRenderer>().color = new Color(203, 175, 81, 1);

            if (i == space + roadOnBox - 1)
            {
                endCord[1, 0] = _xRightCord;
                endCord[1, 1] = _yBottomCord + i;
            }
        }

        //0 - top
        //1 - right
        //2 - bottom
        //3 - left

        // Debug.Log(startCord[0, 0]);
        // Debug.Log(startCord[0, 1]);
        // Debug.Log(endCord[0, 0]);
        // Debug.Log(endCord[0, 1]);

        for (int i = 0; i < 4; i++)
        {
            if (i % 3 == 0)
            {
                x = endCord[i, 0];
                y = endCord[i, 1];
            }
            else
            {
                x = startCord[i, 0];
                y = startCord[i, 1];
            }
            for (int j = 0; j < 100; j++)
            {
                if (i % 3 == 0)
                {
                    if (i == 3)
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            if (y == _yUpperCord || y == _yBottomCord)
                            {
                                continue;
                            }
                            x += Mathf.Clamp(startCord[0, 0] - x, -1, 1);
                        }
                        else
                        {
                            if (x == _xLeftCord || x == _xRightCord)
                            {
                                continue;
                            }
                            y += Mathf.Clamp(startCord[0, 1] - y, -1, 1);
                        }
                        if (x == startCord[0, 0] && y == startCord[0, 1])
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            if (y == _yUpperCord || y == _yBottomCord)
                            {
                                continue;
                            }
                            x += Mathf.Clamp(endCord[i + 1, 0] - x, -1, 1);
                        }
                        else
                        {
                            if (x == _xLeftCord || x == _xRightCord)
                            {
                                continue;
                            }
                            y += Mathf.Clamp(endCord[i + 1, 1] - y, -1, 1);
                        }
                        if (x == endCord[i + 1, 0] && y == endCord[i + 1, 1])
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (i == 2)
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            if (y == _yUpperCord || y == _yBottomCord)
                            {
                                continue;
                            }
                            x += Mathf.Clamp(startCord[i + 1, 0] - x, -1, 1);
                        }
                        else
                        {
                            if (x == _xLeftCord || x == _xRightCord)
                            {
                                continue;
                            }
                            y += Mathf.Clamp(startCord[i + 1, 1] - y, -1, 1);
                        }
                        if (x == startCord[i + 1, 0] && y == startCord[i + 1, 1])
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            if (y == _yUpperCord || y == _yBottomCord)
                            {
                                continue;
                            }
                            x += Mathf.Clamp(endCord[i + 1, 0] - x, -1, 1);
                        }
                        else
                        {
                            if (x == _xLeftCord || x == _xRightCord)
                            {
                                continue;
                            }
                            y += Mathf.Clamp(endCord[i + 1, 1] - y, -1, 1);
                        }
                        if (x == endCord[i + 1, 0] && y == endCord[i + 1, 1])
                        {
                            break;
                        }
                    }
                }

                x = Mathf.Clamp(x, _xLeftCord + 1, _xRightCord - 1);
                y = Mathf.Clamp(y, _yBottomCord + 1, _yUpperCord - 1);

                _tiles[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
                // Debug.Log($"{x} {y}");
            }
        }
    }
}
