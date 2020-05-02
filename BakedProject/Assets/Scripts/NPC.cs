using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform ChatBackground;
    public Transform NpcCharacter;
    public string Name;
    private DialogeSystem dialougeSystem;

    [TextArea(5, 10)]
    public string[] sentances;

    void Start()
    {
        dialougeSystem = FindObjectOfType<DialogeSystem>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NpcCharacter.position);
        Pos.y = 100;
        ChatBackground.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogeSystem>().EnterRangeOfNPC();
        if((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialougeSystem.Names = Name;
            dialougeSystem.dialougeLines = sentances;
            FindObjectOfType<DialogeSystem>().NPCName();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogeSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
