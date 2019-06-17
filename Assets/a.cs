using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public float speed = 1.0f;
    public float speedStep = 0;
    public string axisX = "Horizontal";
    public string axisY = "Vertical";
    public Object blockaPrefab;
    public float respawnX1, respawnY1;
    public float respawnX2, respawnY2;
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
        }
    }
}
