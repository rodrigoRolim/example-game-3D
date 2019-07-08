using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{   
    private Quaternion rotOriginal;
    private float rotMY=0;
    // Start is called before the first frame update
    void Start()
    {
        rotOriginal = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotMY += Input.GetAxis("Mouse Y");
        rotMY = Mathf.Clamp(rotMY, -50, 50);
        Quaternion cimabaixo = Quaternion.AngleAxis(rotMY, Vector3.left);
        transform.localRotation = rotOriginal * cimabaixo;

    }
}
