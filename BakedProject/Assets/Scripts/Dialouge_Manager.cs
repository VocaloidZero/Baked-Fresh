using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge_Manager : MonoBehaviour
{

    //https://www.youtube.com/watch?v=iPTIbORnYkk
    public GameObject dialogPanel;
    public Text npcNameText;
    public Text dialogText;

    private List<string> conversation;
    private int convoIndex;

    private void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
    }

    public void StopDialog()
    {
        dialogPanel.SetActive(false);
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
    }

    public void Next()
    {
        if(convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
        
    }

}
