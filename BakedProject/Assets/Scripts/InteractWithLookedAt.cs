using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking 
/// at an IInteractive and then calls that IInteractive's InteractWith()
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && lookedAtInteractive !=null)
        {
            Debug.Log("Player pressed the interact button.");
            lookedAtInteractive.InteractWith();
        }

    }

    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region Event sub/unsub
    private void OnEnable()
    {
        DetectLookedAtInteractions.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractions.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}

