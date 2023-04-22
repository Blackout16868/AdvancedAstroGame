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
    private bool onShip = false;
    private float playerHeight;
    int parts = 0;
    // Start is called before the first frame update
    void Start()
    {
      partsText.text = "Ship Parts: "+parts+"/"+partsList.Length;   
      playerHeight = GetComponent<PlayerBehavior>().getPlayerHeight();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Destroy(other.gameObject);
           parts++;
           partsText.text = "Ship Parts: "+parts+"/"+partsList.Length;
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