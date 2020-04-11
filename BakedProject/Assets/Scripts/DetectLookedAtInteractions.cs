using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookedAtInteractions : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from a raycast origin will search for interactive elements.")]
    [SerializeField]
    private float maxRange = 5.0f;

    [SerializeField]
    private LayerMask interactableLayer;

    /// <summary>
    /// Event raised when the player looks at a different interactive.
    /// </summary>
    public static event Action<IInteractive> LookedAtInteractiveChanged;


    public IInteractive LookedAtInteractive
    {   get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if(isInteractiveChanged)
            {
                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);

            }
            
        }
    }

    private IInteractive lookedAtInteractive;

    /// <summary>
    /// Raycast forward from the camera to look for IInteractives.
    /// </summary>
    private void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive();

    }

    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;

        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange, interactableLayer.value);
        IInteractive interactive = null;

        if (objectWasDetected)
        {
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        return interactive;
    }
}
