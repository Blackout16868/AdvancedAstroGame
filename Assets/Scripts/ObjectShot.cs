using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShot : MonoBehaviour
{
 public GameObject weapon; 
  public float health = 10f;
  private float maxHealth;

  private void Start() {
    maxHealth = health;
    }
  
private void OnCollisionEnter(Collision collision)
  {
    
     if (collision.gameObject.CompareTag("Bullet")){
      float weaponDamage = weapon.GetComponent<Weapon>().getDamage();
        health -= weaponDamage;
         if (health <= 0f){
          if (TryGetComponent<BossEnemy>(out BossEnemy boss)){
            boss.spawnThing();
          }
          if (TryGetComponent<HasHB>(out HasHB hb)){
            hb.turnOff();
          }
    Destroy( transform.parent.gameObject);
  }
     }
  }

  public float gethealth(){
    return health;
  }

  public float getMaxHealth(){
    return maxHealth;
  }
}
