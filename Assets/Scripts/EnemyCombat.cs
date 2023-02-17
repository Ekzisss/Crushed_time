using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public string EnemyName;

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

    public int ItemChance;
    public int ItemTier;

    public List<Object> abilities;
    public List<Object> resurses;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}
