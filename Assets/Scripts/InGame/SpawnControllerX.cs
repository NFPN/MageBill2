using UnityEngine;
using System.Collections;

public class SpawnControllerX : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public float rateSpawn;
	public float currentTime;
	private int posicao;
	private float y;
	private float x;
	private int spawnMode;
	public int rotationOffset;

	static public bool isBossActive;   


	void Start () 
	{
		isBossActive = false;
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (LifeHandler.numVidas > 0 && isBossActive == false)
		{
			currentTime += Time.deltaTime;
			if (currentTime >= rateSpawn) 
			{
				rateSpawn = Random.Range (0.1f, 1.5f);
				currentTime = 0;
				posicao = Random.Range (-5, 5);
				x = posicao;
				GameObject tempPrefab = Instantiate (enemyPrefab) as GameObject;
				tempPrefab.transform.position = new Vector3 (transform.position.x + x, transform.position.y, transform.position.z);
			}
		}
	}

	static public void DestroyAllEnemies()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject go in gos)
			Destroy (go);
	}
}
