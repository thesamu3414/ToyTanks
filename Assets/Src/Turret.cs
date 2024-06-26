using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<Transform> turretBarrels;
    public GameObject bulletPrefab;
    public float reloadDelay = 1;
    public Animator shootAnimation;

    private bool canShoot = true;
    //private Collider2D[] tankcolliders;
    private float currentDelay = 0;

    private void Update()
    {
        shootAnimation.SetBool("shooting", false);
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            shootAnimation.SetBool("shooting", true);
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation ;
                bullet.GetComponent<Bullet>().Initialize();
                
            }
        }
    }
}
