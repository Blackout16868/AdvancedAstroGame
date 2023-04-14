using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShot : MonoBehaviour
{
 public GameObject weapon; 
  public float health = 10f;
  
private void OnCollisionEnter(Collision collision)
  {
    
     if (collision.gameObject.CompareTag("Bullet")){
      float weaponDamage = weapon.GetComponent<Weapon>().getDamage();
        health -= weaponDamage;
         if (health <= 0f){
    Destroy( transform.parent.gameObject);
  }
     }
  }
}
