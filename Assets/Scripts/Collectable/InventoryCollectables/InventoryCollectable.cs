﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollectable : Collectable
{
    [SerializeField] MeshFilter meshFilterComponent = default;
    [SerializeField] MeshRenderer meshRendererComponent = default;
    [SerializeField] CollectableInventoryItemsSO itemDescription = default;

    public string NameOfItem { get; private set; }
    public string DescriptionOfItem { get; private set; }
    public Sprite ImageOfItem { get; private set; }
    public Mesh MeshOfItem { get; private set; }
    public Material MaterialOfItem { get; private set; }

  
    public override void OnPickedUp()
    {
        //add to inventory
    }
    void SetupObject(CollectableInventoryItemsSO itemDescription)
    {
        if (itemDescription == null)
        {
            Debug.LogError("Item Description is empty for " + this.gameObject.name);
            return;
        }

        NameOfItem = itemDescription.Name;
        DescriptionOfItem = itemDescription.Description;
        ImageOfItem = itemDescription.Image;
        MeshOfItem = itemDescription.ModelMesh;
        MaterialOfItem = itemDescription.MeshMaterial;

        if (meshFilterComponent == null)
        {
            meshFilterComponent = GetComponentInChildren<MeshFilter>();
        }

        if (meshFilterComponent.mesh == null)
        {
            meshFilterComponent.mesh = MeshOfItem;
        }

        if (meshRendererComponent == null)
        {
            meshRendererComponent = GetComponentInChildren<MeshRenderer>();
        }        

        if (meshRendererComponent.material = null)
        {
            meshRendererComponent.material = MaterialOfItem;
        }
    }
    private void Awake()
    {
        SetupObject(this.itemDescription);
    }

  
}