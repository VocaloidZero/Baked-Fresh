using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The game object to toggle.")]
    [SerializeField]
    private GameObject objectToToggle;

    [Tooltip("The game object to toggle.")]
    [SerializeField]
    private GameObject foodToToggleOn;

    [Tooltip("Can the player interact with this more than once?")]
    [SerializeField]
    private bool isReuseable = true;

    public ParticleSystem smokePuff;
    private bool hasBeenUsed = false;
    public AudioClip foodDisappearAudio;
     AudioSource audio;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this item.
    /// </summary>
    public override void InteractWith()
    {
        if(isReuseable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            foodToToggleOn.SetActive(!foodToToggleOn.activeSelf);
            hasBeenUsed = true;
            if (!isReuseable)  displayText = string.Empty;
            audio.PlayOneShot(foodDisappearAudio);
            smokePuff.Play();
        }
        
    }

}
