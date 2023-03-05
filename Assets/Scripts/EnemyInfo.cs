using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public new string name;
    public Sprite sprite;

    public EnemyType EnemyType;
    public int damage;
    public float moveSpeed;

    [ShowIf("EnemyType", EnemyType.Ranged)]
    [Header("Ranged")]
    public float shootCd;
    [ShowIf("EnemyType", EnemyType.Ranged)]
    public float distanceToPlayer;

    // [ShowIf("EnemyType", EnemyType.Mele)]
    // [Header("Mele")]
    // public string adssad;
}

public enum EnemyType
{
    Mele,
    Ranged,
    Boss
}