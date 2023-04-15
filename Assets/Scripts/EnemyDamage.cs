using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 5f;
    public float pushForce = 10f;
    private Rigidbody player;
    private Rigidbody self;

    private void Start() {
        self = GetComponent<Rigidbody>();
    }
    
    
    public float getDamage()
    {
        return damage;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")){
            player = collision.gameObject.GetComponent<Rigidbody>();
            pushPlayer(player, collision);
            goBack();
        }
    }

    private void pushPlayer(Rigidbody rb, Collision collision){
         Transform orientation = collision.gameObject.GetComponent<Transform>();
         Vector3 moveDirection = orientation.forward * 1f + orientation.right * 1f;
         rb.AddForce(-moveDirection.normalized * pushForce * 10f, ForceMode.Force);
    }

    private void goBack()
    {
        Transform orientation = GetComponent<Transform>();
        Vector3 moveDirection = orientation.forward * 1f + orientation.right * 1f;
        self.AddForce(-moveDirection.normalized * 10f * 10f, ForceMode.Force);
    }
}
