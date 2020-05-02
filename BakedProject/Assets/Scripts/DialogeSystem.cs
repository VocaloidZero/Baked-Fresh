using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogeSystem : MonoBehaviour
{
    public Text nameText;
    public Text dialougeText;
    public GameObject dialougeGUI;
    public Transform dialougeBoxGUI;
    public float letterDelay = 1.0f;
    public float letterMultiplier = 0.5f;
    public KeyCode DialougeInput = KeyCode.F;
    public string Names;
    public string[] dialougeLines;

    public bool letterIsMultiplied = false;
    public bool dialougeActive = false;
    public bool dialougeEnded = false;
    public bool outOfRange = true;

    public float audioSpeed = 0.5f;
    public AudioClip audioClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialougeText.text = "";
    }

     public void EnterRangeOfNPC()
    {
        outOfRange = false;
        dialougeGUI.SetActive(true);
        if(dialougeActive == true)
        {
            dialougeGUI.SetActive(false);
        }
    }
    
    public void NPCName()
    {
        outOfRange = false;
        dialougeBoxGUI.gameObject.SetActive(true);
        nameText.text = Names;
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!dialougeActive)
            {
                dialougeActive = true;
                StartCoroutine(StartDialouge());
            }

        }
        StartDialouge();
    }

    private IEnumerator StartDialouge()
    {
        if(outOfRange == false)
        {
            int dialougeLength = dialougeLines.Length;
            int currentDialougeIndex = 0;

            while(currentDialougeIndex < dialougeLength || !letterIsMultiplied)
            {
                if(letterIsMultiplied)
                {
                    letterIsMultiplied = true;
                    StartCoroutine(DisplayString(dialougeLines[currentDialougeIndex++]));
                    if(currentDialougeIndex >= dialougeLength)
                    {
                        dialougeEnded = true;
                    }
                }
                yield return 0;
            }

            while(true)
            {
                if (Input.GetKeyDown(DialougeInput) && dialougeEnded == false)
                {
                    break;
                }
                yield return 0;
            }
            dialougeEnded = false;
            dialougeActive = false;
            DropDialouge();
        }
    }

    private IEnumerator DisplayString (string stringToDisplay)
    {
        if(outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;
            dialougeText.text = "";

            while(currentCharacterIndex < stringLength)
            {
                dialougeText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                if(currentCharacterIndex < stringLength)
                {
                    if(Input.GetKey(DialougeInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);

                        if (audioClip) audioSource.PlayOneShot(audioClip, audioSpeed);
                    }
                    else
                    {
                        yield return new WaitForSeconds(letterDelay);

                       if(audioClip) audioSource.PlayOneShot(audioClip, audioSpeed);
                    }
                   
                }
                else
                {
                    dialougeEnded = false;
                    break;
                }
            }
            while(true)
            {
                if(Input.GetKeyDown(DialougeInput))
                {
                    break;
                }
                yield return 0;
            }
            dialougeEnded = false;
            letterIsMultiplied = false;
            dialougeText.text = "";
        }
    }

    public void DropDialouge()
    {
        dialougeGUI.SetActive(false);
        dialougeBoxGUI.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        outOfRange = true;
        if(outOfRange == true)
        {
            letterIsMultiplied = false;
            dialougeActive = false;
            StopAllCoroutines();
            dialougeGUI.SetActive(false);
            dialougeBoxGUI.gameObject.SetActive(false);
        }
    }

}
