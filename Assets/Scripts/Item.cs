using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;
using UnityEngine.UIElements;
using NaughtyAttributes;

[System.Serializable]
public class Item : MonoBehaviour
{
    public ItemType ItemType;

    [ShowIf("ItemType", ItemType.Weapon)]
    [Header("Weapon")]
    public WeaponType WeaponType;

    [ShowIf("ItemType", ItemType.Armor)]
    [Header("Armor")]
    public ArmorType ArmorType;

    [ShowIf("ItemType", ItemType.Potion)]
    [Header("Potion")]
    public PotionType PotionType;

}

public enum ItemType
{
    Weapon = 0,
    Armor,
    Potion
};

public enum ArmorType
{
    Helmet = 0,
    BodyArmor,
    Pants,
    Boots,
    Ring,
    Necklace,
    Belt
};

public enum WeaponType
{
    Mele = 0,
    Range,
};

public enum PotionType
{
    Healing = 0,
    Buff,
};