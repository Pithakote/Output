using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Inventory Instance { get; private set; }

    Dictionary<string, InventoryCollectable> inventoryItems = default;
    
    public Dictionary<string, InventoryCollectable> InventoryItems { get { return inventoryItems; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != null && GameObject.Find(this.gameObject.name) != null)
        {
            Destroy(this.gameObject);
        }

        inventoryItems = new Dictionary<string, InventoryCollectable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
