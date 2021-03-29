using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeLayer : MonoBehaviour
{
    int originalLayer;
    Vector3 originalScale;
    public AudioSource sManager;

    void Start()
    {
        originalLayer = 0;
        originalScale = gameObject.transform.localScale;
        sManager = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }
    public void BringToFront()
    {
        SoundManager.PlaySound("cardScroll");
        gameObject.transform.GetChild(1).GetComponent<Canvas>().sortingOrder = 250;
        /*gameObject.transform.localScale = originalScale*1.05f; */
        Debug.Log(gameObject.name);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void ReturnToLayer()
    {

        gameObject.transform.GetChild(1).GetComponent<Canvas>().sortingOrder = originalLayer;
        gameObject.transform.localScale = originalScale;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
