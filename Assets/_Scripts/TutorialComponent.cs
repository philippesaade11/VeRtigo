using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialComponent : MonoBehaviour
{
    MovementComponent player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Tutorial");
        player = GameObject.Find("Player").GetComponent<MovementComponent>();
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(3);
        transform.Find("1").gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        transform.Find("1").gameObject.SetActive(false);
        transform.Find("2").gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        transform.Find("2").gameObject.SetActive(false);
        transform.Find("3").gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
        transform.Find("3").gameObject.SetActive(false);
        transform.Find("4").gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        //Detect Gyroscope
        yield return new WaitForSeconds(1);
        //----------------
        transform.Find("4").gameObject.SetActive(false);
        transform.Find("goodwork").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        transform.Find("goodwork").gameObject.SetActive(false);

        transform.Find("5").gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        while(!player.isRunning)
        {
            yield return new WaitForSeconds(0.5f);
        }
        transform.Find("5").gameObject.SetActive(false);
        transform.Find("goodwork").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        transform.Find("goodwork").gameObject.SetActive(false);

        transform.Find("6").gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        while (player.isNotJumping)
        {
            yield return new WaitForSeconds(0.1f);
        }
        transform.Find("6").gameObject.SetActive(false);
        transform.Find("goodwork").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        transform.Find("goodwork").gameObject.SetActive(false);

        transform.Find("7").gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        transform.Find("7").gameObject.SetActive(false);
        transform.Find("8").gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        transform.Find("8").gameObject.SetActive(false);
        transform.Find("9").gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        transform.Find("9").gameObject.SetActive(false);
        transform.Find("bestofluck").gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
