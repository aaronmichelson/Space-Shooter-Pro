﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]  // 0 = Triple Shot, 1 = Speed, 2 = Shields
    private int powerupID;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                switch(powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;

                    case 1:
                        player.SpeedPowerupActive();
                        break;

                    case 2:
                        Debug.Log("Collected Shields...");
                        break;

                    default:
                        Debug.Log("Default value");
                        break;
                }
            }

            Destroy(this.gameObject);
        }
    }

    
}
