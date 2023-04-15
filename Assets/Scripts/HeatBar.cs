using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]
public class HeatBar : MonoBehaviour
{
    public float maximum;
    public float current;
    public Image mask;
    public GameObject Weapon;
    public Image background;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current = Weapon.GetComponent<Weapon>().getCurTemp();
        maximum = Weapon.GetComponent<Weapon>().getMaxTemp();
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        if (!Weapon.GetComponent<Weapon>().getRun())
        {
         background.color =  new Color(1f, 0f, 0f);
        }else 
        {
            background.color =  new Color(0.21f, 0.21f, 0.21f);
        }
        float fillAmount = current/maximum;
        mask.fillAmount = fillAmount;
    }
}
