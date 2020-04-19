using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door. If they key is in their inventory, it will unlock the door.")]
    [SerializeField]
    private InventoryObject key;    

    [Tooltip("The text that displays when the player looks at the door while it is locked.")]
    [SerializeField]
    private string lockedDisplayText = "Locked.";

    //public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;
    public override string DisplayText
    {
        get
        {
            string toReturn;
            if (isLocked)
                toReturn = HasKey ? $"Go to next tray." : lockedDisplayText;
            else
                toReturn = base.DisplayText;

            return toReturn;
        }
    }

    [Tooltip("This sound plays when the door is locked without owning the key.")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("This plays when the player opens the door.")]
    [SerializeField]
    private AudioClip openedAudioClip;

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isLocked;
    private bool isOpen = false;
    private int shouldOpenAnimParameter= Animator.StringToHash(nameof(shouldOpenAnimParameter));
    /// <summary>
    /// Constructor to initalize displayText in editor.
    /// </summary>
    /// 
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
        {
            isLocked = true;
        }
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else //if it is not locked or if it is locked and we have the key
            {
                audioSource.clip = openedAudioClip;
                animator.SetBool(shouldOpenAnimParameter, true);
                displayText = string.Empty;
                isOpen = true;
                isLocked = false;
            }
            base.InteractWith(); //this plays a sound effect
        }

    }

}
