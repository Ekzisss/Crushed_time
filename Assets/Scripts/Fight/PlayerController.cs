using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x;
    private float y;

    public float speed = 7f;

    private Rigidbody2D rb;

    [SerializeField] private int HighestDamage = 0;

    public int hp;

    [SerializeField] private ContactFilter2D filter;
    [SerializeField] private List<Collider2D> results = new List<Collider2D>();

    private bool isDamageRunning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 move = new Vector3(x, y);
        move.Normalize();
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        Physics2D.OverlapCollider(GetComponent<BoxCollider2D>(), filter, results);

        if (results.Count != 0)
        {
            foreach (var item in results)
            {
                int damage = item.gameObject.GetComponent<EnemyManager>().EnemyInfo.damage;
                if (HighestDamage < damage)
                {
                    HighestDamage = damage;
                }
            }

            if (!isDamageRunning)
            {
                StartCoroutine(damageTime());
            }
        }
        else if (isDamageRunning && results.Count == 0)
        {
            HighestDamage = 0;
            isDamageRunning = false;
            StopCoroutine(damageTime());
        }
        Debug.Log(results.Count);
    }

    public IEnumerator damageTime()
    {
        isDamageRunning = true;
        while (true)
        {
            takeDamage();
            yield return new WaitForSeconds(0.7f);
        }
    }

    private void takeDamage()
    {
        hp -= HighestDamage;
    }
}
