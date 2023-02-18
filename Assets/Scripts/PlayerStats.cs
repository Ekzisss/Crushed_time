using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public string ClassName;

    // public int strength;
    // public int agility;

    public float HP;
    public float armor;
    public float EvadeChance;
    public float Regen;

    public List<float> damage;
    public float attackSpeed;
    public float critChance;
    public float critMultiplier;

    public float lifeSteal;
}
