using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCrawlMonsterComponent : MonoBehaviour
{
    private System.Random random = new System.Random();
    private Transform player;
    public List<GameObject> MonsterPool;
    public GameObject Monster;
    public int length;
    public float SpawnDistance;

    public float SpawnTime;
    public float SpawnTimeDecreaseRate;
    private float timeForNext;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        MonsterPool = new List<GameObject>();
        for(int i=0; i<length; i++)
        {
            GameObject obj = (GameObject)Instantiate(Monster);
            obj.transform.parent = transform;
            obj.SetActive(false);
            MonsterPool.Add(obj);
        }
        timeForNext = SpawnTime;
    }

    void SpawnMonster()
    {
        GameObject Spawn = null;
        for(int i=0; i<length; i++)
        {
            if (!MonsterPool[i].active)
            {
                Spawn = MonsterPool[i];
                break;
            }
        }

        if(Spawn is null)
        {
            Spawn = (GameObject)Instantiate(Monster);
            Spawn.transform.parent = transform;
            MonsterPool.Add(Spawn);
        }

        float randAngle = (float)random.NextDouble() * 2 * Mathf.PI;
        Spawn.transform.position= new Vector3(SpawnDistance*Mathf.Cos(randAngle) + player.position.x, Spawn.transform.position.y, SpawnDistance * Mathf.Sin(randAngle) + player.position.z);
        Spawn.SetActive(true);
    }

    void SpawnCycle()
    {
        if(timeForNext <= 0)
        {
            SpawnMonster();
            int rand = random.Next((int)(-SpawnTime * 0.1), (int)(SpawnTime * 0.1));
            timeForNext = SpawnTime + rand;
        }
        timeForNext -= 1f;
        SpawnTime -= SpawnTimeDecreaseRate*0.01f;
        if(SpawnTime <= 50)
        {
            SpawnTime = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCycle();
    }
}
