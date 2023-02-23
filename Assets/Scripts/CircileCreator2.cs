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

    public List<Transform> path = new List<Transform>();
    public List<Transform> nearPath = new List<Transform>();

    [SerializeField] private GameObject road1;
    [SerializeField] private GameObject road2;

    [SerializeField] private GameObject hero;

    // Start is called before the first frame update
    void Awake()
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
            if (i == space)
            {
                makeRoad(_xLeftCord + i, _yUpperCord, false, 0);
            }
            else if (i == space + roadOnBox - 1)
            {
                makeRoad(_xLeftCord + i, _yUpperCord, false, 270);
            }
            else
            {
                makeRoad(_xLeftCord + i, _yUpperCord, true, 0);
            }

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
            if (i == space)
            {
                makeRoad(_xLeftCord + i, _yBottomCord, false, 90);
            }
            else if (i == space + roadOnBox - 1)
            {
                makeRoad(_xLeftCord + i, _yBottomCord, false, 180);
            }
            else
            {
                makeRoad(_xLeftCord + i, _yBottomCord, true, 0);
            }

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
            if (i == space)
            {
                makeRoad(_xLeftCord, _yBottomCord + i, false, 90);
            }
            else if (i == space + roadOnBox - 1)
            {
                makeRoad(_xLeftCord, _yBottomCord + i, false, 0);
            }
            else
            {
                makeRoad(_xLeftCord, _yBottomCord + i, true, 90);
            }

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
            if (i == space)
            {
                makeRoad(_xRightCord, _yBottomCord + i, false, 180);
            }
            else if (i == space + roadOnBox - 1)
            {
                makeRoad(_xRightCord, _yBottomCord + i, false, 270);
            }
            else
            {
                makeRoad(_xRightCord, _yBottomCord + i, true, 90);
            }

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
            path.Add(_tiles[x, y].transform);
            for (int j = 0; j < 100; j++)
            {
                int lastX = x;
                int lastY = y;
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

                // makeRoad(lastX, lastY, bool straight, int degress)

                path.Add(_tiles[x, y].transform);
                // _tiles[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
                // Debug.Log($"{x} {y}");
            }
            path.Add(_tiles[x, y].transform);
        }

        for (int x = 1; x < _maxX - 2; x++)
        {
            for (int y = 1; y < _maxY - 2; y++)
            {
                // Debug.Log("enterd");
                // Debug.Log(path.Contains(_tiles[x + 1, y].transform));
                if (path.Contains(_tiles[x, y].transform) && path.Contains(_tiles[x + 1, y].transform) && path.Contains(_tiles[x - 1, y].transform))
                {
                    // Debug.Log(1);
                    makeRoad(x, y, true, 0);
                }
                else if (path.Contains(_tiles[x, y].transform) && path.Contains(_tiles[x, y + 1].transform) && path.Contains(_tiles[x, y - 1].transform))
                {
                    // Debug.Log(2);
                    makeRoad(x, y, true, 90);
                }
                else if (path.Contains(_tiles[x, y].transform) && path.Contains(_tiles[x + 1, y].transform) && path.Contains(_tiles[x, y - 1].transform))
                {
                    // Debug.Log(3);
                    makeRoad(x, y, false, 0);
                }
                else if (path.Contains(_tiles[x, y].transform) && path.Contains(_tiles[x + 1, y].transform) && path.Contains(_tiles[x, y + 1].transform))
                {
                    // Debug.Log(4);
                    makeRoad(x, y, false, 90);
                }
                else if (path.Contains(_tiles[x, y].transform) && path.Contains(_tiles[x - 1, y].transform) && path.Contains(_tiles[x, y + 1].transform))
                {
                    // Debug.Log(5);
                    makeRoad(x, y, false, 180);
                }
                else if (path.Contains(_tiles[x, y].transform) && path.Contains(_tiles[x - 1, y].transform) && path.Contains(_tiles[x, y - 1].transform))
                {
                    // Debug.Log(6);
                    makeRoad(x, y, false, 270);
                }
            }
        }

        a = Random.Range(0, path.Count);

        GameObject.FindWithTag("Main").GetComponent<MainParameters>().path = path;

        GameObject heroObj = Instantiate(hero, path[a].position, Quaternion.identity);

        heroObj.GetComponent<FollowPath>().pathHolder = gameObject;
        heroObj.GetComponent<FollowPath>().counter = a;

        makeNearPath();
        GameObject.FindWithTag("Main").GetComponent<MainParameters>().nearPath = nearPath;
        GameObject.FindWithTag("Main").GetComponent<MainParameters>()._tiles = _tiles;
    }

    void makeRoad(int x, int y, bool straight, int degress)
    {
        Instantiate(straight ? road1 : road2, _tiles[x, y].transform.position, Quaternion.Euler(0, 0, degress), _tiles[x, y].transform);
    }

    void makeNearPath()
    {
        for (int i = 0; i < _maxX; i++)
        {
            for (int j = 0; j < _maxY; j++)
            {
                if (i + 1 < _maxX && _tiles[i + 1, j].transform.childCount > 0)
                {
                    nearPath.Add(_tiles[i, j].transform);
                    continue;
                }

                if (i - 1 >= 0 && _tiles[i - 1, j].transform.childCount > 0)
                {
                    nearPath.Add(_tiles[i, j].transform);
                    continue;
                }

                if (j + 1 < _maxY && _tiles[i, j + 1].transform.childCount > 0)
                {
                    nearPath.Add(_tiles[i, j].transform);
                    continue;
                }

                if (j - 1 >= 0 && _tiles[i, j - 1].transform.childCount > 0)
                {
                    nearPath.Add(_tiles[i, j].transform);
                    continue;
                }
            }
        }
    }
}