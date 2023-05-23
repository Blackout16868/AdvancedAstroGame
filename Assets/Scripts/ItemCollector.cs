using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] TMP_Text partsText;
    [SerializeField] GameObject[] partsList;
    [SerializeField] LayerMask ship;
    [SerializeField] GameObject continueUi;
    [SerializeField] GameObject jetpackBar;
    private bool onShip = false;
    private float playerHeight;
    int parts = 0;

    public static bool hasJetpack = false;
    // Start is called before the first frame update
    void Start()
    {
      partsText.text = "Ship Parts: "+parts+"/"+partsList.Length;   
      playerHeight = GetComponent<PlayerBehavior>().getPlayerHeight();
      jetpackBar.SetActive(false);
      hasJetpack = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Destroy(other.gameObject);
           parts++;
           partsText.text = "Ship Parts: "+parts+"/"+partsList.Length;
        }
        else if (other.gameObject.CompareTag("Jetpack"))
        {
            Destroy(other.gameObject);
            hasJetpack = true;
            jetpackBar.SetActive(true);
        }
    }

    private void Update() {
        
        if (inShip()&&hasAllParts()&&!onShip){
        onShip = true;
        continueUi.SetActive(true);
        }else if (!inShip()&&onShip)
        {
            onShip = false;
        }
    }

    public bool inShip(){
        return Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ship);
    }

    public bool hasAllParts(){
        return parts == partsList.Length;
    }

    // Update is called once per frame

}