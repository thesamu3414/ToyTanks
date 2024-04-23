using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.01f;
    public float maxDistance = 100;
    public int remainingCollisions = 2;

    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;
    private Vector2 screenBounds;
    private Vector2 startPosition;
    private Vector2 direction;


    // Start is called before the first frame update
    public void Initialize()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        this.direction = rb2d.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance > maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        remainingCollisions--;

        if (remainingCollisions < 0)
        {
            DisableObject();
            return;
        }

        var firstContact = collision.contacts[0];
        Vector2 newVelocity = Vector2.Reflect(direction, firstContact.normal);
        rb2d.velocity = newVelocity;
        direction = rb2d.velocity;

        float newRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f,0f, newRotation - 90f); // Rotate sprite
    }
}
