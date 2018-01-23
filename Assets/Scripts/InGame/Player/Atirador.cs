using UnityEngine;
using UnityEngine.UI;

public class Atirador : MonoBehaviour
{
    public float fireRate = 0;
    static public float Damage;
    public float mainDamage;
    public LayerMask whatToHit;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    public Image mp;
    public float fill;
    public float seeFill;
    public float regenFill;

    

    //public Transform BulletTrailPrefab;
    public PausedTime doc;

    float timeToFire = 0;
    Transform firePoint;

    private float currentTime;
    private GameObject mageBill;
    private bool coolDown;
    private float slowMult;
    private float pontosPsegundo;

    void Awake()
    {
        firePoint = gameObject.transform;
        if (firePoint == null)
        {
            Debug.LogError("No Fire Point, WHAT!");
        }
        currentTime = 3;
    }

    void Start()
    {
        pontosPsegundo = 150;
        mageBill = GameObject.Find("MageBill");
        coolDown = false;
        Damage = mainDamage;
        seeFill = 1.0f;
        fill = mp.fillAmount;
        mp.fillAmount = fill;
    }

    void Update()
    {
        ManagerS.pontuacao += pontosPsegundo * Time.deltaTime;
        currentTime += Time.deltaTime;

        if (mp.fillAmount <= 0.001 && !coolDown)
        {
            coolDown = true;
            currentTime = 0;
            mageBill.GetComponent<SpriteRenderer>().color = Color.red;
            mp.fillAmount += 0.01f;
        }
        else if (coolDown)
        {
            mp.fillAmount += 0.08f * Time.deltaTime;
        }
        if (currentTime >= 3)
        {
            coolDown = false;
            mageBill.GetComponent<SpriteRenderer>().color = Color.white;

            if (fill != 0)
            {
                if (fireRate == 0)
                {
                    return;
                    /*if (Input.GetButtonDown("Fire1"))
                    {
                        Shoot();
                        mp.fillAmount -= 0.01f;
                        doc.tp.fillAmount += 0.001f;
                    }*/
                }
                else
                {
                    if (Input.GetButton("Fire1") && Time.time > timeToFire)
                    {
                        timeToFire = Time.time + 1 / fireRate;
                        Shoot();
                        mp.fillAmount -= 0.006f;
                        doc.tp.fillAmount += 0.001f;
                    }
                }
            }

            if (LifeHandler.numVidas >= 2)
                mp.fillAmount += regenFill * Time.deltaTime;
            else
                mp.fillAmount += 0.07f * Time.deltaTime;
        }
    }

    void Shoot()
    {

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 1,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 1);
        /*Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
		*/
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        /*if (hit.collider != null) 
		{
            return;
		}*/
    }

    void Effect()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MBFire");
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
        }
        //Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}