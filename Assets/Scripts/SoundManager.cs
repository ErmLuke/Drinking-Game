using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip buttonClick, addCard, removeCard, saveDeck, loadDeck, reshuffle, errorSound, drawCard, dropCard, typingSound, cardScroll, noDeck;
    public static AudioSource audioSrc;
    void Start()
    {
        buttonClick = Resources.Load<AudioClip>("buttonClick");
        addCard = Resources.Load<AudioClip>("addCard");
        removeCard = Resources.Load<AudioClip>("removeCard");
        saveDeck = Resources.Load<AudioClip>("saveDeck");
        loadDeck = Resources.Load<AudioClip>("loadDeck");
        reshuffle = Resources.Load<AudioClip>("reshuffle");
        errorSound = Resources.Load<AudioClip>("errorSound");
        drawCard = Resources.Load<AudioClip>("drawCard");
        dropCard = Resources.Load<AudioClip>("dropCard");
        typingSound = Resources.Load<AudioClip>("typingSound");
        cardScroll = Resources.Load<AudioClip>("cardScroll");
        noDeck = Resources.Load<AudioClip>("noDeck");

        audioSrc = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "buttonClick":
                audioSrc.PlayOneShot(buttonClick,30f);
                break;
            case "addCard":
                audioSrc.PlayOneShot(addCard, 100f);
                break;
            case "removeCard":
                audioSrc.PlayOneShot(removeCard, 100f);
                break;
            case "saveDeck":
                audioSrc.PlayOneShot(saveDeck, 100f);
                break;
            case "loadDeck":
                audioSrc.PlayOneShot(loadDeck, 100f);
                break;
            case "reshuffle":
                audioSrc.PlayOneShot(reshuffle, 90f);
                break;
            case "errorSound":
                audioSrc.PlayOneShot(errorSound, 100f);
                break;
            case "drawCard":
                audioSrc.PlayOneShot(drawCard, 100f);
                break;
            case "dropCard":
                audioSrc.PlayOneShot(dropCard, 60f);
                break;
            case "typingSound":
                audioSrc.PlayOneShot(typingSound, 30f);
                break;
            case "cardScroll":
                audioSrc.PlayOneShot(cardScroll, 10f);
                break;
            case "noDeck":
                audioSrc.PlayOneShot(noDeck, 80f);
                break;
        }
    }
}
