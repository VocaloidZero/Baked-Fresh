using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    [SerializeField]
    private string UrlOpener;

    void Start()
    {
        
    }

   public void Open()
    {
        Application.OpenURL(UrlOpener);
    }
}
