using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
 
    public float maxHealth = 100f;
    private float curHealth;
    bool dead = false;
    [SerializeField] GameObject deathUI;
    private float healcoolDown = 300f;
    private float healtimer;

 private void Start() {
        curHealth = maxHealth;
        healtimer = healcoolDown;
    }

    private void Update() {
        if (curHealth<=0f&&!dead)
        {   
            die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
;
       if (collision.gameObject.CompareTag("EnemyBody")){ 
            float damage = collision.gameObject.GetComponent<EnemyDamage>().getDamage();
           takeDamage(damage);
           
         }
    }

    public void die(){
        GetComponent<PlayerBehavior>().enabled = false;
        deathUI.SetActive(true);
        dead = true;
        Invoke(nameof(reloadLevel),1.3f);
    }
    
    public void reloadLevel(){
        //TODO: Change to go to a checkpoint?
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float getCurHealth(){
        return curHealth;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void takeDamage(float attackDamage){
            curHealth -= attackDamage;
            FindObjectOfType<AudioManager>().Play("Hurt");
    }

    public void heal(float healthAmount){
        if (healtimer <= 0f){
        curHealth += healthAmount;
        if (curHealth>maxHealth){
            curHealth=maxHealth;
        }
        healtimer = healcoolDown;
        return;
        }
        healtimer--;
    }
}
