using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI text displays info about currently looked at interactive object. Text is hidden if player is not looking at an interactive
/// object.
/// </summary>
public class LookedAtInteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractive !=null)
        { displayText.text = lookedAtInteractive.DisplayText; }
        else
        { displayText.text = string.Empty; }
        
    }
    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive the player is looking at.</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayText();
    }

    #region event subscription/unsub
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
