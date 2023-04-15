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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current = Weapon.GetComponent<Weapon>().getCurTemp();
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = current/maximum;
        mask.fillAmount = fillAmount;
    }
}
