using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Tutorial");
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
        transform.Find("4").gameObject.SetActive(false);
        transform.Find("5").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        transform.Find("5").gameObject.SetActive(false);
        transform.Find("6").gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        transform.Find("6").gameObject.SetActive(false);
        transform.Find("7").gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        transform.Find("7").gameObject.SetActive(false);
        transform.Find("8").gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        transform.Find("8").gameObject.SetActive(false);
        transform.Find("9").gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        transform.Find("9").gameObject.SetActive(false);
        transform.Find("10").gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        transform.Find("10").gameObject.SetActive(false);
        transform.Find("11").gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        transform.Find("11").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
