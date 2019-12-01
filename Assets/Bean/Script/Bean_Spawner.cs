using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bean_Spawner : MonoBehaviour {

    public int score;

    public Text scoreText;

    public float spawnRate = 1f;

    public GameObject hexagonPrefab;

    private float nextTimeToSpawn = 0f;

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRate;
            score++;
        }

        scoreText.text = score.ToString();
    }
}
