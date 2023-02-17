using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleCreator : MonoBehaviour
{
    private GameObject[,] tiles;

    private int x;
    private int y;
    private int scetor;

    private int counter = 0;

    public int maxY;
    public int maxX;

    private float xHalf;
    private float yHalf;

    private bool endCircile = false;

    private int _startx;
    private int _starty;

    private int minPathLenght = 15;

    private bool _checkCircile = false;
    private int _sinsCounter = 0;
    private int endCountdown = 150;
    private int direction = 0;

    void Start()
    {
        xHalf = maxX / 2;
        yHalf = maxY / 2;
        tiles = new GameObject[maxX, maxY];
        int counter = 0;
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                tiles[i, j] = transform.GetChild(counter).gameObject;
                counter += 1;
            }
        }
        // foreach (GameObject element in tiles)
        // {
        //     Debug.Log($"{element} ");
        // }

        _startx = x = Random.Range(2, maxX - 2);
        _starty = y = Random.Range(1, maxY - 1);

        if (x > xHalf && y > yHalf)
        {
            scetor = 1;
        }
        else if (x > xHalf && y <= yHalf)
        {
            scetor = 2;
        }
        else if (x <= xHalf && y > yHalf)
        {
            scetor = 3;
        }
        else if (x <= xHalf && y <= yHalf)
        {
            scetor = 4;
        }
    }


    void FixedUpdate()
    {
        if (_checkCircile)
        {
            fateDecide();
        }
        else if (!endCircile)
        {
            // circile making
            counter += 1;

            Debug.Log($"{x} {y}");
            // Debug.Log(Random.Range(0, 1));

            tiles[x, y].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            // Debug.Log("куда?");
            if (x > xHalf && y > yHalf)
            {
                Debug.Log('1');
                if (scetor == 1 && counter > minPathLenght)
                {
                    endCircile = true;
                }
                if (Random.Range(0, 2) == 0)
                {
                    checkAndChangePath(true, 1, -1);
                    // x += 1;
                }
                else
                {
                    checkAndChangePath(false, -1, 1);
                    // y -= 1;
                }

                x = Mathf.Clamp(x, 4, maxX - 4);
                y = Mathf.Clamp(y, 1, maxY - 1);
            }
            else if (x > xHalf && y <= yHalf)
            {
                Debug.Log('2');
                if (scetor == 2 && counter > minPathLenght)
                {
                    endCircile = true;
                }
                if (Random.Range(0, 2) == 0)
                {
                    checkAndChangePath(true, -1, -1);
                    // x -= 1;
                }
                else
                {
                    checkAndChangePath(false, -1, -1);
                    // y -= 1;
                }

                x = Mathf.Clamp(x, 4, maxX - 4);
                y = Mathf.Clamp(y, 1, maxY - 1);
            }
            else if (x <= xHalf && y > yHalf)
            {
                Debug.Log('3');
                if (scetor == 3 && counter > minPathLenght)
                {
                    endCircile = true;
                }
                if (Random.Range(0, 2) == 0)
                {
                    checkAndChangePath(true, 1, 1);
                    // x -= 1;
                }
                else
                {
                    checkAndChangePath(false, 1, 1);
                    // y += 1;
                }

                x = Mathf.Clamp(x, 4, maxX - 4);
                y = Mathf.Clamp(y, 1, maxY - 1);
            }
            else if (x <= xHalf && y <= yHalf)
            {
                Debug.Log('4');
                if (scetor == 4 && counter > minPathLenght)
                {
                    endCircile = true;
                }
                if (Random.Range(0, 2) == 0)
                {
                    checkAndChangePath(true, -1, 1);
                    // x += 1;
                }
                else
                {
                    checkAndChangePath(false, 1, -1);
                    // y += 1;
                }

                x = Mathf.Clamp(x, 4, maxX - 4);
                y = Mathf.Clamp(y, 1, maxY - 1);
            }
            // Debug.Log("end");
        }
        else
        {
            Debug.Log($"{x} {y} circileEnd");
            int rand = Random.Range(0, 2);
            tiles[x, y].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            if (x == _startx && y == _starty)
            {
                // Destroy(gameObject.GetComponent<CircleCreator>());

                // gameObject.GetComponent<CircleCreator>().enabled = false;
                Debug.Log("fatestarted");
                _checkCircile = true;
            }
            else if (x == _startx)
            {
                if (y < _starty)
                {
                    y += 1;
                }
                else if (x > _starty)
                {
                    y -= 1;
                }
            }
            else if (y == _starty)
            {
                if (x < _startx)
                {
                    x += 1;
                }
                else if (x > _startx)
                {
                    x -= 1;
                }
            }
            else if (rand == 0)
            {
                if (x < _startx)
                {
                    x += 1;
                }
                else if (x > _startx)
                {
                    x -= 1;
                }
            }
            else
            {
                if (y < _starty)
                {
                    y += 1;
                }
                else if (x > _starty)
                {
                    y -= 1;
                }
            }
        }

    }


    void checkAndChangePath(bool xy, int num, int num2)
    {
        if (xy)
        {
            x += num;
        }
        else
        {
            y += num;
        }
        // x = Mathf.Clamp(x, 0, 15);
        // y = Mathf.Clamp(y, 0, 8);
        Debug.Log($"{counter} counter");
        Debug.Log($"{x} {y}");
        try
        {
            if (tiles[x, y].GetComponent<SpriteRenderer>().color == new Color(255, 255, 255, 1))
            {
                Debug.Log("true");
                if (xy)
                {
                    x -= num;
                    y += num2;
                }
                else
                {
                    y -= num;
                    x += num2;
                }
            }
        }
        catch (System.Exception)
        {
            if (xy)
            {
                x -= num;
                y += num2;
            }
            else
            {
                y -= num;
                x += num2;
            }
            // throw;
        }
    }

    void fateDecide()
    {
        Debug.Log($"{x} {y}");
        endCountdown -= 1;
        if (endCountdown <= 0)
        {
            Debug.Log("All good!!!!!");
            gameObject.GetComponent<CircleCreator>().enabled = false;
        }
        _sinsCounter = 0;
        // bool numberDesided = false;
        if (tiles[x + 1, y].GetComponent<SpriteRenderer>().color == new Color(255, 255, 255, 1))
        {
            _sinsCounter += 1;
            // numberDesided = true;
            if (direction != 4)
            {
                x += 1;
                direction = 1;
            }
        }
        if (tiles[x, y + 1].GetComponent<SpriteRenderer>().color == new Color(255, 255, 255, 1))
        {
            _sinsCounter += 1;
            // if (!numberDesided)
            // {
            //     y += 1;
            // }
            if (direction != 3)
            {
                y += 1;
                direction = 2;
            }
        }
        if (tiles[x, y - 1].GetComponent<SpriteRenderer>().color == new Color(255, 255, 255, 1))
        {
            _sinsCounter += 1;
            // if (!numberDesided)
            // {
            //     y -= 1;
            // }
            if (direction != 2)
            {
                y -= 1;
                direction = 3;
            }
        }
        if (tiles[x - 1, y].GetComponent<SpriteRenderer>().color == new Color(255, 255, 255, 1))
        {
            _sinsCounter += 1;
            // if (!numberDesided)
            // {
            //     x -= 1;
            // }
            if (direction != 1)
            {
                x -= 1;
                direction = 4;
            }
        }

        if (_sinsCounter > 2)
        {
            Debug.Log("need restart!!!!!");
            gameObject.GetComponent<CircleCreator>().enabled = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}