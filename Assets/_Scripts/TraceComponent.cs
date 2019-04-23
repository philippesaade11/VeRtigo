using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceComponent : MonoBehaviour
{
    private GameObject point;
    private Transform player;

    public bool pinpoint = true;
    // Start is called before the first frame update
    void Start()
    {
        point = transform.Find("Point").gameObject;
        player = GameObject.Find("Player").transform;
        StartCoroutine(addTrace());
    }

    IEnumerator addTrace()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (pinpoint)
            {
                GameObject childObject = Instantiate(point) as GameObject;
                childObject.transform.parent = gameObject.transform;
                childObject.transform.position = new Vector3(player.position.x, childObject.transform.position.y, player.position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
