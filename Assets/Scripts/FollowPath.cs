using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private Transform path;
    private List<Transform> points = new List<Transform>();
    [SerializeField] private bool useChieldsPoints;
    [SerializeField] public GameObject pathHolder;

    [SerializeField] private float speed;

    private Transform target;
    [System.NonSerialized] public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (useChieldsPoints)
        {
            for (int i = 0; i < path.childCount; i++)
            {
                points.Add(path.GetChild(i).transform);
            }
        }
        else
        {
            // points = pathHolder.GetComponent<CircileCreator2>().path;
            points = GameObject.FindWithTag("Main").GetComponent<MainParameters>().path;
        }

        target = points[counter];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(points[points.Count - 1].position, points[0].position);
        for (int i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(points[i].position, points[i + 1].position);
        }
    }

    void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        Vector3 norm = Vector3.Normalize(target.position - transform.position);
        // Debug.Log(dist);
        // Debug.Log(norm);
        // Debug.Log(counter + " counter");
        transform.Translate((norm * speed * Time.fixedDeltaTime) / 10);
        if (dist <= 0.05)
        {
            if (counter == points.Count - 1)
            {
                counter = -1;
            }
            target = points[++counter];
        }
    }
}
