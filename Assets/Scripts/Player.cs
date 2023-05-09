using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _speed = 5f;

    [Header("Player Shooting")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float fireRate = .25f;
    private float canFire = 0f;


    void Start()
    {

    }

    void Update()
    {
        PlayerMovement();
        PlayerShooting();
    }

    // player shooting method
    void PlayerShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > canFire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, .88f, 0), Quaternion.identity);
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
        transform.Translate(Vector2.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector2.up * Time.deltaTime * _speed * verticalInput);

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
}
