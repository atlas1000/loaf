using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 1.0f;
    public float speedStep = 0;
    public string axisX = "Horizontal";
    public string axisY = "Vertical";
    public Object blockaPrefab;
    public Object blockbPrefab;
    public Object blockcPrefab;
    public float respawnX1, respawnY1;
    public float respawnX2, respawnY2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private Rigidbody2D rb;

    private SpriteRenderer sr;
    private object Vector3;

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxisRaw(axisX);
        var moveY = Input.GetAxisRaw(axisY);
        if (moveX != 0)
        {
            sr.flipX = moveX > 0 ? true : false;
        }

        rb.velocity = new Vector2(moveX * speed, moveY * speed);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Power up":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Obstacle: '"
                          + other.gameObject.name + "'");
                // Destroy the obstacle.
                Destroy(other.gameObject);
                speed = speed + speedStep;
                var position = 
                    new Vector3 (Random.Range(respawnX1, respawnX2),
                        Random.Range(respawnY1, respawnY2),0) ;
                var rotation = Quaternion.identity;
                Instantiate(blockaPrefab, position, rotation);
                break;
            case "Power up1":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Obstacle: '"
                          + other.gameObject.name + "'");
                // Destroy the obstacle.
                Destroy(other.gameObject);
                speed = speed + speedStep;
                position = 
                    new Vector3 (Random.Range(respawnX1, respawnX2),
                        Random.Range(respawnY1, respawnY2),0) ;
                rotation = Quaternion.identity;
                Instantiate(blockbPrefab, position, rotation);
                break;
            case "Power up2":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Obstacle: '"
                          + other.gameObject.name + "'");
                // Destroy the obstacle.
                Destroy(other.gameObject);
                speed = speed + speedStep;
                position = 
                    new Vector3 (Random.Range(respawnX1, respawnX2),
                        Random.Range(respawnY1, respawnY2),0) ;
                rotation = Quaternion.identity;
                Instantiate(blockcPrefab, position, rotation);
                break;
        }
    }
}