using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenCard : MonoBehaviour
{
    public MyCard cardScript;
    void Start()
    {
        cardScript = GameObject.Find("GameManager").GetComponent<MyCard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickCard()
    {
        cardScript.DrawCard();
        this.gameObject.SetActive(false);
    }
}
 