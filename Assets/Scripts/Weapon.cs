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
    public float overHeatCoolDown = 100f;
    public float damage = 5f;
    public float coolDown = 0.66f;
    public float maxTemp = 100f;
    private float minTemp = 23f;
    private float curTemp;
    private float timer = 0f;
    private float timer2 = 0f;
    private float timer3 = 0f;
    private bool run = true;
    

    void Start(){
      curTemp = minTemp;
      setWeaponText();
    }
    // Update is called once per frame
    void Update()
    {
      if (curTemp>=maxTemp)
        {
          timer3 = overHeatCoolDown;
          run = false;
          curTemp = minTemp;
        }

        if (!run && timer3<=0){
          setWeaponText();
          run = true;
          
        }
        if (timer3 > 0f)
        {
          timer3 --;
          return;
        }

        if (timer > 0f)
        {

            timer -= Time.deltaTime; 
            
        }

        if (timer2 > 0f)
        {
          timer2 -= Time.deltaTime;
        }



        if (run)
        {        
        if (Input.GetMouseButton(0)&&timer<=0f && !PauseMenu.GamePaused)
        {
       fire();
      } 
      
      else if (!(Input.GetMouseButton(0))&&timer2<=0f && !PauseMenu.GamePaused&&curTemp>minTemp)
      {
       decreaseHeat();
      }

    }
    }

    public float getDamage(){
      return damage;
    }

    public void setWeaponText()
    {
      weaponText.text = "Laser Heat: "+(curTemp)+"°/"+(maxTemp)+"°";
    }
  

    public void fire(){
         GameObject bulletObject = Instantiate (bulletPrefab);
        bulletObject.transform.position = playerWeapon.transform.position+playerCamera.transform.forward;
        bulletObject.transform.forward = playerCamera.transform.forward;

        timer = coolDown;
        timer2 = coolDown;
        
        FindObjectOfType<AudioManager>().Play("LaserPew");
        curTemp += Mathf.Round(Random.Range(1f,10f));
        setWeaponText();
    }

    public void decreaseHeat()
    {
       curTemp -= 6;
       if (curTemp<0){
        curTemp = 0;
       }
        setWeaponText();
        timer2 = coolDown;
    }
    
  }
