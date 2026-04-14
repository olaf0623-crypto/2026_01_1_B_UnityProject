using NUnit.Framework;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject MissilePrefabs;


    [Header("스폰 타이밍 설정")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;

    public float timer = 0.0f;
    public float nextSpawnTime;
    private int coinSpawnChance;

    [Header("동전 스폰 확률 설정")]
    [UnityEngine.Range(0, 100)]
    public int coinspawnchance = 50;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNextSpawnTime();
    }

    private void SetNextSpawnTime()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if(timer > nextSpawnTime)
        {
           SpawnObject();
           timer = 0.0f;
           SetNextSpawnTime();
        }


        void SetNextSpawnTime()
        {
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }



    void SpawnObject()
    {
        Transform spawnTransform = transform;

        int randomValue = Random.Range(0, 100);
            
        if(randomValue < coinspawnchance
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        {

            Instantiate(MissilePrefabs, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
