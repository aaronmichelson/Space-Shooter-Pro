using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed variable of 8

    [SerializeField]
    private float _speed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        // translate laser up

        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // if laser position is greater than 7 on the y, then destroy the object

        if (transform.position.y > 7f)
        {
            Destroy(this.gameObject);
        }
    }
}
