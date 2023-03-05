using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{
    public List<EnemyInfo> EnemyInfo;
    public List<int> EnemyCount;

    public float borderX = 19.5f;
    public float borderY = 17.5f;

    public float timerBetweenSpawns = 0.2f;

    public float timerTillSpawn = 1f;

    public GameObject alertObj;

    public GameObject EnemyHolder;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (EnemyCount.Count != 0)
        {
            yield return new WaitForSeconds(timerBetweenSpawns);

            StartCoroutine(Spawn());
        }
        Debug.Log("end");
    }

    private IEnumerator Spawn()
    {
        if (EnemyCount.Count == 0)
        {
            yield break;
        }

        int i = Random.Range(0, EnemyInfo.Count);
        Vector2 pos = new Vector2(Random.Range(-borderX, borderX), Random.Range(-borderY, borderY));
        GameObject alert = Instantiate(alertObj, pos, Quaternion.identity);

        EnemyInfo EnemyInfoTemp = EnemyInfo[i];

        EnemyCount[i] -= 1;
        if (EnemyCount[i] <= 0)
        {
            EnemyCount.RemoveAt(i);
            EnemyInfo.RemoveAt(i);
        }

        yield return new WaitForSeconds(timerTillSpawn);

        // if (EnemyCount.Count == 0)
        // {
        //     DestroyImmediate(alert);
        //     yield break;
        // }

        GameObject enemy = Instantiate(Resources.Load("EnemyBaseInFight") as GameObject, pos, Quaternion.identity, EnemyHolder.transform);
        DestroyImmediate(alert);
        enemy.GetComponent<EnemyManager>().EnemyInfo = EnemyInfoTemp;
    }
}
