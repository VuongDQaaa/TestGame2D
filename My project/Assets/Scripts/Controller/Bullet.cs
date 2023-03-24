using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Instantiate(bulletEffect, transform.position, transform.rotation);
    }
}
