using UnityEngine;

public class SpawnControllerBoss : MonoBehaviour 
{
	public GameObject bossPrefab;
	public float timeToSpawnBoss;
	public float currentTime;
	private int posicao;

	static public bool isBossActive;

	void Start () 
	{
		currentTime = 0;
	}
	

	void Update () 
	{
		if (LifeHandler.numVidas > 0 && SpawnControllerX.isBossActive == false)
		{
			currentTime += Time.deltaTime;
			if (currentTime >= timeToSpawnBoss) 
			{
				GameObject tempPrefab = Instantiate (bossPrefab) as GameObject;
				tempPrefab.transform.position = new Vector3 (transform.position.x , transform.position.y, transform.position.z);
				currentTime = 0;
			}
		}
	}
}
