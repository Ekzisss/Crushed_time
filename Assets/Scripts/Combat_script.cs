using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_script : MonoBehaviour
{
    public float RotateSpeed;
    public int targetFrameRate = 30;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));

    }
}
