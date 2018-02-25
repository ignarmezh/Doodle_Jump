using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject platformPrefab;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = 0.5f;
    public float maxY = 2.3f;

	// Use this for initialization
	void Start () {
        Vector3 spawnPosition = new Vector3();

        Vector3 leftPoint = Camera.main.ScreenToWorldPoint(new Vector3(2f,Camera.main.pixelHeight/2,0f));
        Vector3 rightPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth-2f,Camera.main.pixelHeight / 2,0f));
        spawnPosition.z = 0f;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY,maxY);
            spawnPosition.x = Random.Range(leftPoint.x,rightPoint.x);
            Instantiate(platformPrefab,spawnPosition,Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
