using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]
public class BigBossHealthBar : MonoBehaviour
{
    public  float maximum;
   public  float current;
    public Image mask;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current = Player.GetComponent<ObjectShot>().gethealth();
        maximum = Player.GetComponent<ObjectShot>().getMaxHealth();
        
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
       
        float fillAmount = current/maximum;
        mask.fillAmount = fillAmount;
    }
}