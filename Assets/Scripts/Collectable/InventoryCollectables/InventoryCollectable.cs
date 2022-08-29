using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollectable : Collectable
{
    [SerializeField] Collider collider;
    [SerializeField] MeshFilter meshFilterComponent = default;
    [SerializeField] MeshRenderer meshRendererComponent = default;
    [SerializeField] CollectableInventoryItemsSO itemDescription = default;
    
    public string NameOfItem { get; private set; }
    public string DescriptionOfItem { get; private set; }
    public Sprite ImageOfItem { get; private set; }
    public Mesh MeshOfItem { get; private set; }
    public Material MaterialOfItem { get; private set; }

    public CollectableInventoryItemsSO ItemDescription { get { return itemDescription; } }
    public override void OnPickedUp()
    {
        //add to inventory
        collider.enabled = false;
        collectableController.OnPickedUp(this.gameObject);
    }
    protected override void PickedUpEvent(GameObject gameObject)
    {
        if (gameObject != this.gameObject)
        {
            return;
        }

        collectableController.Inventory.AddToDictionary(this);
        gameObject.SetActive(false);

    }
    void SetupObject(CollectableInventoryItemsSO itemDescription)
    {
        if (itemDescription == null)
        {
            Debug.LogError("Item Description is empty for " + this.gameObject.name);
            return;
        }

        this.NameOfItem = itemDescription.Name;
        this.DescriptionOfItem = itemDescription.Description;
        this.ImageOfItem = itemDescription.Image;
        this.MeshOfItem = itemDescription.ModelMesh;
        this.MaterialOfItem = itemDescription.MeshMaterial;

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

        if (collider == null)
        {
            collider = GetComponent<Collider>();
        }
        
    }
    private void Awake()
    {
        SetupObject(this.itemDescription);
    }

  
}
