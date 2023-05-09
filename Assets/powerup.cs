using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
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
                // enabled triple shot
                player.TripleShotPowerupOn();

            }
            // destroyed powerup
            Destroy(this.gameObject);
        }
    }
}
