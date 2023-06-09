using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int powerupID;// 0 for tripleshot, 1 for speed, 2 for shield

    private AudioSource audioSource;
    [SerializeField] private AudioClip powerupSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // checks player
        if (other.CompareTag("Player"))
        {
            // accessing the player
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                // ID = 0 for speed boost
                if (powerupID == 0)
                {
                    // enabled triple shot
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 1)
                {
                    // activate speed boost powerup 
                    player.SpeedBoostPowerupOn();
                }
                else if (powerupID == 2)
                {
                    // activate protect shield
                    player.PlayerShieldOn();
                }

            }

            AudioSource.PlayClipAtPoint(powerupSound, Camera.main.transform.position);
            // destroyed powerup
            Destroy(this.gameObject);
        }
    }
}
