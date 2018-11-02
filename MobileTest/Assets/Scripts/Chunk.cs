using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {
	public Transform[] spawnPoints;
	public string code;

	public GameObject[] obstacleList;
	private List<GameObject> obstacles = new List<GameObject>();
	// Use this for initialization
	void Start () {
		SpawnObstacles();
	}
	void SpawnObstacles()
	{
		for(int i = obstacles.Count-1; i >= 0; i--)
		{
			Destroy(obstacles[i]);
		}
		obstacles.Clear();
		for (int i = 0; i < code.Length; i++)
		{
			if (code[i] == '0')
				continue;
			else
			{
				int c = int.Parse(code[i].ToString());
				if (float.IsNaN(c))
					continue;
				GameObject go = Instantiate(obstacleList[c - 1], spawnPoints[i].position, spawnPoints[i].rotation);
				obstacles.Add(go);
			}
		}
	}

	void GenerateNewCode()
	{
		string tempCode = "";
		for (int i = 0; i < 12; i++)
		{
			char c = Random.Range(0, 4).ToString()[0];
			tempCode += c;
		}
		code = tempCode;

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.A))
		{
			GenerateNewCode();
			SpawnObstacles();
		}
	}
}
