using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Boss1 : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject fireWxplosion;
	public Atirador fillPoint;
	public AudioSource fireSound;
	public Transform bullet;
	public float bulletAmount;
    public float spawnTime;
    public float timeChangeDir;
	public float timeToSpawnBullet;
	public float boss1Life;
	static public float sBoss1Life;
	public Vector3 bossPosition;
	public Vector3 dir;
	public float speed;
    public bool BossDead;
    public bool canShoot;

    private bool startedLastPattern;
    private bool startedPattern1;
    private bool startedPattern2;
    private bool startedPattern3;

    private float currentTime;
	private float currentTime2;
	private float currentTime3;
    private Vector2 bulletCoords;
	private Quaternion rot = new Quaternion(0,0,0,0);
	

	void Start () 
	{
        startedLastPattern = false;
        startedPattern1 = false;
        startedPattern2 = false;
        startedPattern3 = false;

        speed = 1;
		if (fillPoint == null) {
			fillPoint = GameObject.Find ("FirePoint").GetComponent<Atirador> ();
		}

		canShoot = false;
		timeToSpawnBullet = 3;
		SpawnControllerX.isBossActive = true;
		dir = new Vector3 (0.0f, -1.2f, 0.0f);
		boss1Life = 12000;
	}	

	void Update () 
	{
		sBoss1Life = boss1Life;
		transform.Translate (dir * (speed * Time.deltaTime));

        bossPosition = new Vector3 (transform.position.x, transform.position.y, 0.0f);

		currentTime += Time.deltaTime;
        currentTime2 += Time.deltaTime;

        if (transform.position.y <= 2.55f && canShoot == false)
        {
            dir = new Vector3(0.0f, 0.0f, 0.0f);
            canShoot = true;
        }

        //Shoot after current time surpass a constant value
        if (currentTime >= timeToSpawnBullet && canShoot == true)
        {
            StartCoroutine(SpawnBullet());
        }

        
        // x axis movement direction changer
        if (currentTime2 >= timeChangeDir && boss1Life <= 10000)
        {
            timeChangeDir = Random.Range(1.0f, 3.1f);
            speed = 2;
            if (transform.position.x > -5)
            {
                dir = new Vector3(-1.0f, 0.0f, 0.0f);
            }

            if (currentTime2 >= timeChangeDir * 2 && boss1Life <= 10000)
            {
                if (transform.position.x < 1)
                {
                    dir = new Vector3(1.0f, 0.0f, 0.0f);
                }

                timeChangeDir = Random.Range(1.0f, 2.1f);
                currentTime2 = 0;
            }
        }

        //Velocity and shooting patterns
        if (boss1Life <= 500 && !startedPattern3)
        {
            startedLastPattern = true;
            startedPattern3 = true;
            speed = 7;
            timeToSpawnBullet = 1.5f;
            bulletAmount = Random.Range(60, 90);
        }
        else if (boss1Life <= 1000 && !startedPattern2)
        {
            startedPattern2 = true;
            speed = 5;
            timeToSpawnBullet = 2;
        }
        else if (boss1Life <= 5000 && !startedPattern1)
        {
            startedPattern1 = true;
            speed = 3.5f;
            timeToSpawnBullet = 3;
        }

        if (BossDead == true)
        {
            currentTime3 += Time.deltaTime;
            if (currentTime3 >= 2)
            {
                GameObject.Find("_Manager").GetComponent<ChangeScene>().SceneToChangeTo(5);
            }
        }        
	}

    public void CircleSpawn()
    {
        for (float i = 0; i < bulletAmount; i++)
        {
            float aux1 = (i / bulletAmount) * 360;
            rot.eulerAngles = new Vector3(0.0f, 0.0f, 270 + aux1);
            Instantiate(bullet, bossPosition, rot);
        }
        fireSound.Play();
        currentTime = 0;
    }
    IEnumerator SpawnBullet()
    {
        CircleSpawn();
        if (startedLastPattern)
        {
            yield return new WaitForSeconds(timeToSpawnBullet / 2);
            CircleSpawn();
        }
    }
   
    // Cool pattern but too hard for first boss **Delete Later**
    /*IEnumerator RotateCounterClockWise()
    {
        for (float i = 0; i < bulletAmount; i++)
        {
            fireSound.Play();
            yield return new WaitForSeconds(spawnTime);
            float aux1 = (i / bulletAmount) * 360;
            rot.eulerAngles = new Vector3(0.0f, 0.0f, 270 + aux1);
            Instantiate(bullet, bossPosition, rot);
        }
        yield return StartCoroutine(RotateClockWise());
    }
    IEnumerator RotateClockWise()
    {
        yield return StartCoroutine(RotateCounterClockWise());
        for (float i = 0; i < bulletAmount; i++)
        {
            fireSound.Play();
            yield return new WaitForSeconds(spawnTime);
            float aux1 = (i / bulletAmount) * 360;
            rot.eulerAngles = new Vector3(0.0f, 0.0f, 270 - aux1);
            Instantiate(bullet, bossPosition, rot);
        }
        
    }*/

    void OnTriggerEnter2D (Collider2D other)
	{        
		if (other.tag == "Enemy")
        {
			return;
		}		
		if (explosion == null)
        {
			Instantiate(explosion, transform.position, transform.rotation);
		}
		if (other.tag == "Tiro") 
		{            
			Instantiate(fireWxplosion, other.transform.position, transform.rotation);
            other.gameObject.SetActive(false);
            boss1Life -= Atirador.Damage;
			ManagerS.pontuacao += Random.Range(500, 1000) * Time.deltaTime;
			if(boss1Life <= 0)
			{
				ManagerS.pontuacao += 1000000;
				Instantiate(explosion, transform.position, transform.rotation);
				fillPoint.mp.fillAmount += Random.Range(0.05f, 0.2f);
				BossDeath();
				transform.position = new Vector3 (20, 5, 0);
			}
		}		
		else if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			LifeHandler.numVidas -= 1;
			if(LifeHandler.numVidas < 1)
			{
				Destroy (other.gameObject);
			}
			other.transform.position = new Vector3(-1.3f, -3.5f, 0.0f);
		}		
	}
        
    void BossDeath()
	{
		currentTime3 = 0;
		Time.timeScale = 0.25f;
		BossDead = true;	
	}
}
