using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject explosionEffect;

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (transform.position.y < -7.5f)
        {
            var randomXPos = Random.Range(-7.5f, 7.5f);
            transform.position = new Vector3(randomXPos, 7.5f, 0);
        }
    }


    // damage system
    private void OnTriggerEnter2D(Collider2D other)
    {
        // checking player collision
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage();
            }
            Destroy(this.gameObject);
        }
        // checking player laser collision
        else if (other.CompareTag("Laser"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        // instantiating explosion effect 
        GameObject temp = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(temp, 2);
    }
}
