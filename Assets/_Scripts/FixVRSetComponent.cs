using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixVRSetComponent : MonoBehaviour
{
    GameObject leftCam;
    GameObject rightCam;
    public float CamRotation = 0;
    public float CamTranslation = 0;
    Vector3 leftinitPoz;
    Vector3 rightinitPoz;
    Vector3 leftinitRot;
    Vector3 rightinitRot;

    // Start is called before the first frame update
    void Start()
    {
        leftCam = GameObject.Find("Main Camera Left");
        rightCam = GameObject.Find("Main Camera Right");
        leftinitPoz = leftCam.transform.localPosition;
        leftinitRot = leftCam.transform.localEulerAngles;
        rightinitPoz = rightCam.transform.localPosition;
        rightinitRot = rightCam.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal3") == -1)
        {
            CamRotation += 0.05f;
        }
        if (Input.GetAxis("Horizontal3") == 1)
        {
            CamRotation -= 0.05f;
        }
        if (Input.GetAxis("Vertical3") == 1)
        {
            CamTranslation -= 0.005f;
        }
        if (Input.GetAxis("Vertical3") == -1)
        {
            CamTranslation += 0.005f;
        }
        leftCam.transform.localEulerAngles = new Vector3(leftinitRot.x, leftinitRot.y + CamRotation, leftinitRot.z);
        rightCam.transform.localEulerAngles = new Vector3(rightinitRot.x, rightinitRot.y - CamRotation, rightinitRot.z);
        leftCam.transform.localPosition = new Vector3(leftinitPoz.x - CamTranslation, leftinitPoz.y, leftinitPoz.z);
        rightCam.transform.localPosition = new Vector3(rightinitPoz.x + CamTranslation, rightinitPoz.y, rightinitPoz.z);
    }

    void Save()
    {
        PlayerPrefs.SetFloat("CamRotation", CamRotation);
        PlayerPrefs.SetFloat("CamTranslation", CamTranslation);
    }

    void Reset()
    {
        CamRotation = 0;
        CamTranslation = 0;
        PlayerPrefs.SetFloat("CamRotation", 0);
        PlayerPrefs.SetFloat("CamTranslation", 0);
    }
}
