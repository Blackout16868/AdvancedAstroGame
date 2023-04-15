using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]
public class HealthBar : MonoBehaviour
{
    private float maximum = 0f;
    private float current = 0f;
    public Image mask;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current = Player.GetComponent<PlayerLife>().getCurHealth();
        maximum = Player.GetComponent<PlayerLife>().getMaxHealth();
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
       
        float fillAmount = current/maximum;
        mask.fillAmount = fillAmount;
    }
}