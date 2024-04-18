using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.01f;
    public float maxDistance = 100;

    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;
    private Vector2 screenBounds;
    private Vector2 startPosition;


    // Start is called before the first frame update
    public void Initialize()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.name);
        DisableObject();
    }
}
