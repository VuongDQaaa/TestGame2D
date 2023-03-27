using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject turret, fireBullet;
    public float bulletSpeed;
    private bool coolDown;
    public float time;

    private void Start()
    {
        coolDown = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(coolDown == false)
        {
            GameObject bulletClone = Instantiate(fireBullet, transform.position, Quaternion.identity);
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.velocity =  turret.transform.up * bulletSpeed;
            coolDown = true;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(time);
        coolDown = false;
    }
}
