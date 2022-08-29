using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{ 
    Weapon,
    CraftWeapons,
    CraftMagicalItems
}

[CreateAssetMenu(fileName = "Collectable Inventory Item SO", menuName = "Scriptable Object Custom/Colletable Inventory")]
public class CollectableInventoryItemsSO : ScriptableObject
{
    public Sprite Image;
    public string Name = default;
    public string Description = default;
    public Material MeshMaterial = default;
    public Mesh ModelMesh;
    public InventoryType InventoryTypeItem;
}
