using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 m per second

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if bottom of screen, then respawn at the top with a new random x position

        if (transform.position.y < -8f)
        {
            float randomX = Random.Range(-7.5f, 7.5f);

            transform.position = new Vector3(randomX, 8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if other is Player, damage the player and destroy us

        if (other.tag == "Player")
        {
            // damage player

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        // if other is laser, destroy laser and then us

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        
    }
}
