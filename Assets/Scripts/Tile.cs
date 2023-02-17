using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject content;
    public Sprite tileTexture;
    // private float scale = 3.125f;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void refresh()
    {
        if (tileTexture)
        {
            sprite.color = new Color(255, 255, 255, 1);
            sprite.sprite = tileTexture;
        }

        // var TileContent = Instantiate(content, transform.position, Quaternion.identity);

        // sprite.transform.localScale = new Vector3(scale, scale, 1);
    }
}
