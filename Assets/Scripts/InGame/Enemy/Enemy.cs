using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public float speed;
    public float rand;
    public Vector3 dir;	
	private float currentTime;
    private float currentTime2;
    private float currentTimeFire;
    private float rateChange;
    public float rateFireChange;

	public float timeToSpawnBullet = 6;

	public Transform BulletTrailPrefab;
	public Transform firePoint;
	public GameObject mageBill;
	public int rotationOffset;
	public Vector3 difference;

    public AudioSource fireSound;
	private Quaternion rot = new Quaternion(0,0,0,0);

	void Start () 
	{
        currentTimeFire = 0;
        rateFireChange = 3;
        timeToSpawnBullet = 8;        
		speed = 1.0f;
        Randommizer();
        rateChange = Random.Range(1.5f, 4.5f);
        mageBill = GameObject.Find("MageBill");
    }

    void Update()
    {
        
        currentTime += Time.deltaTime;
        currentTime2 += Time.deltaTime;
        currentTimeFire += Time.deltaTime;    

        if (currentTime >= rateChange)
        {
            dir = new Vector3(1, -speed, 0.0f);
            if (currentTime >= rateChange * 2)
            {
                Randommizer();
                rateChange = Random.Range(0.1f, 1.5f);
                currentTime = 0;
            }
        }
        else
        {
            dir = new Vector3(-1, -speed, 0.0f);
        }

        if (currentTime2 >= timeToSpawnBullet)
        {
            timeToSpawnBullet = Random.Range(6, 20);
            float bulletAmount = 6;
            fireSound.Play();
            for (float i = 0; i < bulletAmount; i++)
            {
                float aux1 = (i / bulletAmount) * 360;
                rot.eulerAngles = new Vector3(0.0f, 0.0f, 360 + aux1);
                Instantiate(BulletTrailPrefab, transform.position, rot);
            }
            currentTime2 = 0;
        }

        if (currentTimeFire >= rateFireChange)
        {
            //mageBill = GameObject.Find("MageBill");
            Vector3 difference = mageBill.transform.position - transform.position;
            difference.Normalize();
            rateFireChange = Random.Range(1.0f, 5.0f);
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            firePoint.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
            Shoot();
            currentTimeFire = 0;
        }

        if (transform.position.y >= 4.8f)
            dir = new Vector3(0, -1, 0);

        transform.Translate(dir * (speed * Time.deltaTime));
    }

	public void Shoot()
	{		
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }

	void Randommizer()
	{        
        speed = Random.Range (1, 2.5f);
        rand = Random.Range(0, 99);
        if (rand <= 12)
            speed = Random.Range(-1.5f, -2.5f);
    }	
}
