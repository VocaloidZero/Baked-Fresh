using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("Image used to show the associated object's icon")]
    [SerializeField]
    private Image iconImage;

    private InventoryObject associatedInventoryObject;
    public static event Action<InventoryObject> inventoryMenuItemSelected;

    public InventoryObject AssociatedInventoryObject
    {
       get { return associatedInventoryObject; }
       set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    /// <summary>
    /// This will be plugged to the toggle's "OnValueChanged" property in editor. And called when the toggled is clicked.
    /// </summary>
    public void InventoryMenuItemWasToggled(bool isOn)
    {
        //only  want to do this stuff when the toggle has been selected, not when it has been deselected
        if (isOn)
            inventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        Debug.Log($"Toggled: {isOn}");
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup; 
    }

}
