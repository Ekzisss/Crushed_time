using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyMapObj : ScriptableObject
{
    public new string name;
    public Sprite sprite;
}
