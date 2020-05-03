using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    //https://www.youtube.com/watch?v=p4a_OYmk1uU&t=531s

    public Transform ChatBackGround;
    public Transform NPCCharacter;
    private Animator playerAnimator;
    private DialogueSystem dialogueSystem;
    private AudioSource audioSource;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {

        if (this.gameObject.GetComponent<NPC>().enabled == false)
        {
            playerAnimator.SetInteger("AnimIndex", 4);

        }
        else
        {
            playerAnimator.SetInteger("AnimIndex", 55);
        }

    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
       
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
            playerAnimator.SetInteger("AnimIndex", 55);
            audioSource.Play();
        }
       

    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        playerAnimator.SetInteger("AnimIndex", 4);
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}

