using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBasedOnProximity : MonoBehaviour
{
    public GameObject loading;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            loading.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            loading.SetActive(false);

        }
    }



}
