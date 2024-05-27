using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootDelay = 1.5f;

    private bool isAttacking = false;
    private float lastShotTime = 0f;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {

        }
    }

    public void Shoot()
    {
        if (Time.time - lastShotTime >= shootDelay)
        {
            lastShotTime = Time.time;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            Vector3 lookDirection = transform.right;

            if (mousePosition.x < transform.position.x)
            {
                lookDirection = -transform.right;
            }

            float dotProduct = Vector3.Dot(lookDirection, direction);
            if (dotProduct > 0)
            {
                Fire(direction);
            }
            else
            {
                Fire(-direction);
            }
        }
    }

    private void Fire(Vector2 direction)
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        currentBulletVelocity.velocity = direction * fireSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        currentBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
