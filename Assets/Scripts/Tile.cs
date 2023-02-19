using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tile")]
public class Tile : ScriptableObject
{
    public new string name;
    public Sprite sprite;

    public tileType tileType;

    [ShowIf("tileType", tileType.Spawner)]
    [Header("Spawner")]
    public string enemyName;
    public spawnerType spawnerType;
    public int spawnerCooldown;

    [ShowIf("tileType", tileType.Environment)]
    [Header("Environment")]
    public environmentType environmentType;

    [ShowIf("tileType", tileType.Area)]
    [Header("Area")]
    public areaType areaType;

    [ShowIf("tileType", tileType.Unique)]
    [Header("Unique")]
    public string what;
}

public enum tileType
{
    Spawner,
    Environment,
    Area,
    Unique
}

public enum spawnerType
{
    OnRoad,
    NearRoad,
    AwayRoad
}

public enum environmentType
{
    hp,
    damage,
    attackSpeed
}

public enum areaType
{
    speed,
    damage,
}