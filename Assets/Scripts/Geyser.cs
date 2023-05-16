using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    private Rigidbody player;
    public float upForce = 15f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")){
            player = collision.gameObject.GetComponent<Rigidbody>();
            player.AddForce(transform.up * upForce, ForceMode.Impulse);
        }
    }
}
