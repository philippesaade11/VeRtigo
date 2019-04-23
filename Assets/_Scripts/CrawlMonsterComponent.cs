using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlMonsterComponent : MonoBehaviour
{
    private System.Random random = new System.Random();
    private List<AudioSource> audios;
    public int numAudios = 3;
    private int currentlyPlaying = 0;

    private Transform player;
    private Vector3 target;

    public float speed = 0.015f;
    public bool stopped = false;
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        audios = new List<AudioSource>();
        player = GameObject.Find("Player").transform;
        target = new Vector3(player.position.x, player.position.y + 0.5f, player.position.z);
        transform.parent.LookAt(target);

        for(int i=0; i<numAudios; i++)
        {
            audios.Add(transform.parent.Find("audio" + i).GetComponent<AudioSource>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        PlayAudio();
        if (health <= 0)
        {
            StartCoroutine(DestroyMonster());
        }
    }

    void FollowPlayer()
    {

        transform.parent.LookAt(target);
        if (Vector3.Distance(player.position, transform.parent.position) >= 1.25f)
        {
            transform.parent.Translate(Vector3.forward * speed);
        }
        else if (!stopped)
        {
            stopped = true;
            transform.parent.GetComponent<Animator>().SetBool("Stopped", true);
        }
    }

    void PlayAudio()
    {
        if (!audios[currentlyPlaying].isPlaying)
        {
            currentlyPlaying = random.Next(0, numAudios);
            audios[currentlyPlaying].Play();
        }
    }

    IEnumerator DestroyMonster()
    {
        //transform.parent.GetComponent<Animator>().enabled = false;
        Renderer rend = transform.parent.Find("Body").GetComponent<Renderer>();
        float r = rend.material.color.r;
        float g = rend.material.color.g;
        float b = rend.material.color.b;
        while (r > 0 || g > 0 || b > 0)
        {
            rend.material.color = new Color(r, g, b);
            r -= 0.075f;
            g -= 0.075f;
            b -= 0.075f;
            yield return new WaitForSeconds(0.1f);
        }
        transform.parent.gameObject.SetActive(false);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Sword Collider")
        {
            health -= 20;
        }
    }
}
