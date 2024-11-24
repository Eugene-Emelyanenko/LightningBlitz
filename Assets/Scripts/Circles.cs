using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Circles : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;
    public Vector2 startSpawnPoint;
    public float xOffset;
    public int circleCount;
    public int maxCoins = 3;
    [SerializeField] private GameObject[] circles;

    void Start()
    {
        SpawnNewCircles();
    }

    public int CalculateSumOfNumbers()
    {
        int sum = 0;
        foreach (var circle in circles)
        {
            sum += circle.GetComponent<Circle>().GetNumber();
        }
        return sum;
    }

    public int CalculateBonuses()
    {
        int countCoins = 0;
        foreach (var circle in circles)
        {
            if (circle.GetComponent<Circle>().isCoin)
                countCoins++;
        }

        return 200 * countCoins;
    }

    public void SpawnNewCircles()
    {
        foreach (GameObject circle in circles)
        {
            Destroy(circle);
        }
        
        circles = new GameObject[circleCount];
        
        for (int i = 0; i < circleCount; i++)
        {
            Vector2 spawnPosition = startSpawnPoint + new Vector2(i * xOffset, transform.position.y);

            GameObject circle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);

            circle.transform.SetParent(this.transform);

            circles[i] = circle;
        }
        
        SetCoins();
    }

    private void SetCoins()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            circles[Random.Range(0, circles.Length)].GetComponent<Circle>().SetCoin();
        }
    }
}