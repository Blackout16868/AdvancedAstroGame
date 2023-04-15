using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public TMP_Text weaponText;

    public GameObject bulletPrefab;
    public GameObject playerCamera;
    public GameObject playerWeapon;
    public float overHeatCoolDown;
    public float damage;
    public float coolDown;
    public float fireSpeed;
    public float maxTemp;
    private float minTemp;
    public float curTemp;
    private float timer1;
    private float timer3;
    private bool run = true;

    void Start(){
      curTemp = minTemp;
    }
    // Update is called once per frame
    void Update()
    {
      checkOverHeat();

      if (timer1 > 0f)
      {
        timer1 -= Time.deltaTime; 
      }

      if (run)
      {        
        if (Input.GetMouseButton(0) && timer1<=0 && timer3<=0 && !PauseMenu.GamePaused)
        {
          fire();
        } 
      
        else if (!(Input.GetMouseButton(0)) && timer1<=0 && timer3<=0 && !PauseMenu.GamePaused && curTemp>minTemp)
        {
          decreaseHeat();
        }
      }
    }

    public float getDamage(){
      return damage;
    }
    public float getMaxTemp(){
      return maxTemp;
    }
    public float getCurTemp(){
      return curTemp;
    }

    public void fire(){
         GameObject bulletObject = Instantiate (bulletPrefab);
        bulletObject.transform.position = playerWeapon.transform.position+playerCamera.transform.forward;
        bulletObject.transform.forward = playerCamera.transform.forward;

        timer1 = fireSpeed;
        
        FindObjectOfType<AudioManager>().Play("LaserPew");
        curTemp += Mathf.Round(Random.Range(3f,7f));
    }

    public void decreaseHeat()
    {
       curTemp -= (Time.deltaTime * (maxTemp/coolDown));
       if (curTemp<0){
        curTemp = 0;
       }
    }

    public void checkOverHeat()
    {
     if (curTemp>=maxTemp||!run)
        {
          if (run){
          timer3 = overHeatCoolDown;
          run = false;
          return;
        }
          
          if (timer3>0)
          {
            timer3 -= Time.deltaTime;
            curTemp -= (Time.deltaTime * (maxTemp/overHeatCoolDown));
            return;
          }
          if (timer3 <= 0 && !run){
          curTemp = 0;
          run = true;
          return;
          }
        }
    }

    public bool getRun()
    {
      return run;
    }
    
  }
