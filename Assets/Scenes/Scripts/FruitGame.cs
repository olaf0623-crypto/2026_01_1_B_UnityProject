using UnityEngine;

public class FruitGame : MonoBehaviour
{

    public GameObject[] fruitPrefabs;
    public float[] fruitSizes = { 0.5f, 0.7f, 0.9f, 1.1f, 1.3f, 1.5f, 1.7f, 1.9f };

    public GameObject currentFruit;
    public int currentFruitType;

    public float fruitStartHeight = 6.0f;
    public float gameWidth = 5.0f;
    public bool isGameOver = false;
    public Camera mainCamera;

    void Update()
    {
        if (isGameOver) return;
        if (currentFruit != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            Vector3 newPosition = currentFruit.transform.position;
            newPosition.x = worldPosition.x;

            float halfFruitSize = fruitSizes[currentFruitType] / 2f;

            if (newPosition.x < -gameWidth / 2 + halfFruitSize)
            {
                newPosition.x = -gameWidth / 2 + halfFruitSize;
            }

            if (newPosition.x > gameWidth / 2 + halfFruitSize)
            {
                newPosition.x = gameWidth / 2 + halfFruitSize;
            }

            currentFruit.transform.position = newPosition;
        }
    }

    void SpawnNewFuit()
    {
        if (!isGameOver)
        {
            currentFruitType = Random.Range(0, 3);

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            Vector3 spawnPosition = new Vector3(worldPosition.x, fruitStartHeight, 0);

            float halfFruitSize = fruitSizes[currentFruitType] / 2f;

            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -gameWidth / 2 + halfFruitSize, gameWidth / 2 - halfFruitSize);

            currentFruit = Instantiate(fruitPrefabs[currentFruitType], spawnPosition, Quaternion.identity);
            currentFruit.transform.localScale = new Vector3(fruitSizes[currentFruitType], fruitSizes[currentFruitType], 1);

            Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = 0f;
            }

        }
    }
}

