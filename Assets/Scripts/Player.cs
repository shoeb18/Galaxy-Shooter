using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _speed = 5f;

    [Header("Player Shooting")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleShotLaser;
    [SerializeField] private float fireRate = .25f;
    private float canFire = 0f;
    public bool canTripleShot = false;
    public bool canSpeedBoost = false;
    public bool shieldEnable = false;

    [Header("Player Health")]
    [SerializeField] private int lives = 3;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject shield;

    private UIManager uIManager;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private AudioSource audioSource;

    [SerializeField] private GameObject[] engineFailure;
    private int hitcount = 0;


    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        audioSource = GetComponent<AudioSource>();

        uIManager.UpdateLives(lives);
        spawnManager.SpawnRoutines();

        hitcount = 0;
    }

    void Update()
    {
        PlayerMovement();
        PlayerShooting();
    }

    // player damage
    public void TakeDamage()
    {
        if (shieldEnable)
        {
            return;
        }

        lives--;
        hitcount++;
        uIManager.UpdateLives(lives);

        // player ship engine failure effect
        if (hitcount == 1)
        {
            engineFailure[0].SetActive(true);
        }
        else if (hitcount == 2)
        {
            engineFailure[1].SetActive(true);
        }


        if (lives <= 0)
        {
            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 2);
            uIManager.ShowTitleScreen();
            gameManager.gameOver = true;
            Destroy(this.gameObject);
        }
    }

    // player shooting method
    void PlayerShooting()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > canFire)
            {
                audioSource.Play();

                if (canTripleShot)
                {
                    Instantiate(tripleShotLaser, transform.position + new Vector3(0, .88f, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(laserPrefab, transform.position + new Vector3(0, .88f, 0), Quaternion.identity);
                }
                canFire = Time.time + fireRate;
            }
        }
    }

    void PlayerMovement()
    {
        // getting input values
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        // make player move
        if (canSpeedBoost)
        {
            // speed boost power
            transform.Translate(Vector2.right * Time.deltaTime * 1.5f * _speed * horizontalInput);
            transform.Translate(Vector2.up * Time.deltaTime * 1.5f * _speed * verticalInput);
        }
        else
        {
            // normal movement
            transform.Translate(Vector2.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector2.up * Time.deltaTime * _speed * verticalInput);
        }

        // make player bound on y axis
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        // player wrapping if its outoff screen
        if (transform.position.x > 9.45f)
        {
            transform.position = new Vector3(-9.45f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.45f)
        {
            transform.position = new Vector3(9.45f, transform.position.y, 0);
        }
    }

    // triple shot enable method
    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }
    // speed boost enable method
    public void SpeedBoostPowerupOn()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedBoostPowerDown());
    }
    // player shield method
    public void PlayerShieldOn()
    {
        shieldEnable = true;
        shield.SetActive(true);
        StartCoroutine(PlayerShieldPowerDown());
    }

    // player shield routine
    IEnumerator PlayerShieldPowerDown()
    {
        yield return new WaitForSeconds(5f);
        shieldEnable = false;
        shield.SetActive(false);
    }
    // speed boost disable coroutine
    IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(5f);
        canSpeedBoost = false;
    }

    // triple shot disable coroutine
    IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5f);
        canTripleShot = false;
    }
}
