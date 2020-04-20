using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("The name of the object as it appears in the inventory UI.")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip("Text that will display when the player selects this item in the inventory menu.")]
    [TextArea(3,8)]
    [SerializeField]
    private string description;

    [Tooltip("Icon to display for this item in inventory.")]
    [SerializeField]
    private Sprite icon;

    private new Renderer renderer;
    private new Collider collider;
    public string ObjectName => objectName;

    [SerializeField]
    private GameObject objectToToggle;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }
    /// <summary>
    /// When a player interacts with an inventory object: a) add object to inventory list b)remove object from the scene
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        objectToToggle.SetActive(!objectToToggle.activeSelf);

        //renderer.enabled = false;
        //collider.enabled = false; 
    }
}
