using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public int foodInLevel = 0;
    public BoxCollider2D gridArea;
    [SerializeField] private GameObject food;
    [SerializeField] private GameManager gameManager;
    GameObject tempFood;

    void Start()
    {
        SpawnFood();
    }

    void Update()
    {
        if (tempFood == null)
        {
            foodInLevel = 0;
        }

        if (foodInLevel == 0)
        {
            SpawnFood();
            gameManager.AddScore(10);
        }
    }

    private void SpawnFood()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        tempFood = Instantiate<GameObject>(food, new Vector3(Mathf.Round(x), Mathf.Round(y), 0), Quaternion.identity);

        foodInLevel++;
    }


}
