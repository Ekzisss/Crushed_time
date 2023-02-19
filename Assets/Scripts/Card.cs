using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private Tile tile;
    [SerializeField] private Canvas canvas;

    private SpriteRenderer sprite;

    private Vector3 mousePos;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.7f);
    }

    private void OnMouseDrag()
    {
        gameObject.transform.position = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)) * canvas.gameObject.transform.localScale.x;
        Debug.Log(Input.mousePosition / 2);
    }

    private void OnMouseUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        transform.localPosition = Vector3.zero;
    }

    public void place(Transform boo)
    {
        GameObject obj = Instantiate(Resources.Load("TileBase") as GameObject, boo.position, Quaternion.identity, boo);
        obj.GetComponent<TileManager>().tile = tile;
        DestroyImmediate(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("placed");
    }
}
