using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyComponent : MonoBehaviour
{
    Transform follow;
    // Start is called before the first frame update
    void Start()
    {
        follow = transform.parent.Find("Head").Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, follow.eulerAngles.y, 0);
    }
}
