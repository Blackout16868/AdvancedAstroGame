using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
public float lifeDuration = 20f;
public float speed = 0.7f;
public float damageToPlayer = 10f;
private float lifeTimer;
// Use this for initialization
  void Start () {
    lifeTimer = lifeDuration;
  }
// Update is called once per frame
  void Update () {
    // Make the bullet move.
    transform.position += transform.forward * speed * Time.deltaTime;
    // Check if the bullet should be destroyed.
    lifeTimer -= Time.deltaTime;
    if (lifeTimer <= 0f) {
      DestroyImmediate(gameObject);
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Player")){
      collision.gameObject.GetComponent<PlayerLife>().takeDamage(damageToPlayer);
    }
    Destroy(gameObject);
    
  }
}
