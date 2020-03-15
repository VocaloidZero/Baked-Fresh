using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The game object to toggle.")]
    [SerializeField]
    private GameObject objectToToggle;
    private GameObject droppedItem;

    [Tooltip("Can the player interact with this more than once?")]
    [SerializeField]
    private bool isReuseable = true;

    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this item.
    /// </summary>
    public override void InteractWith()
    {
        if(isReuseable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            hasBeenUsed = true;
            if (!isReuseable)  displayText = string.Empty;
        }
        
    }

}
