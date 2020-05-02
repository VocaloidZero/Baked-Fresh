using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float xUpdate;
    public float yUpdate;
    public float zUpdate;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xUpdate,yUpdate,zUpdate));
    }
}
