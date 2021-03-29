using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyCard : MonoBehaviour
{
    public GameObject frontPanel;
    public int numberOfCards = 1;
    public int scrollNumber;
    public int addRemove;
    public int removeRemove;
    public List<string> storedNames = new List<string>();
    public int randomCard;
    public TextMeshProUGUI cardObj;
    public TextMeshProUGUI amountOfCards;
    public TextMeshProUGUI storedNameText;
    public GameObject emptyText;
    public TMP_InputField textInput;
    public TMP_InputField saveInputText;
    public List<string> cardNames = new List<string>();
    public List<string> saveFiles = new List<string>();
    public string[] currentList;
    public string[] saveFileArray;
    public GameObject[] saveSlots;
    public GameObject[] removeButtons;
    public GameObject[] loadButtons;
    public GameObject[] cardsInPlay;
    public GameObject saveInput;
    public GameObject inputCard;
    public GameObject loadFiles;
    public GameObject backButton;
    public GameObject chosenCard;
    public GameObject playArea;
    public GameObject reshuff;
    public GameObject madnessButton;
    public int saveSlot;
    public string[] saveArrays;
    public string[] emptyPref;
    public Animator anim;
    public SoundManager sManager;
    public AudioDistortionFilter loopSong;
    public bool isPlaying;
    public bool madness;

    void Start()
    {
        madness = true;
        saveFiles.Clear();
        saveFileArray = PlayerPrefsX.GetStringArray("Saves");
        sManager = GameObject.Find("AudioManager").GetComponent<SoundManager>();
        if (saveFileArray.Length < 1)
        {
            saveFiles.Add("Empty Slot");
            saveFiles.Add("Empty Slot");
            saveFiles.Add("Empty Slot");
            saveFiles.Add("Empty Slot");
            saveFiles.Add("Empty Slot");
            saveFiles.Add("Empty Slot");
            for (int i = 0; i < 6; i++)
            {
                loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFiles[i];
                saveSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFiles[i];
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFileArray[i];
                saveSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFileArray[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        saveFileArray = PlayerPrefsX.GetStringArray("Saves");
        textInput.characterLimit = 180;
        saveInputText.characterLimit = 11;;
        storedNameText = GameObject.Find("StoredNames").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(this.gameObject);
        storedNameText.text = "";
        PlayerPrefsX.GetStringArray("1");
        PlayerPrefsX.GetStringArray("2");
        PlayerPrefsX.GetStringArray("3");
        PlayerPrefsX.GetStringArray("4");
        PlayerPrefsX.GetStringArray("5");
        PlayerPrefsX.GetStringArray("6");       

        if ((textInput.isFocused || saveInputText.isFocused )&& Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Return))
            {
                return; 
            }
            else
            {
                SoundManager.PlaySound("typingSound");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < cardNames.Count; i++)
            {
                Debug.Log("Remaining Cards" + cardNames[i]);
            }
        }
        if ((cardNames.Count < 1) && isPlaying)
        {
            emptyText.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        { 
                OnClick();
            textInput.text = null;
        }
        for (int i = 0; i < 6; i++)
        {
            if(loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text == "Empty Slot")
            {
                loadButtons[i].SetActive(false);
            }
            else
            {
                loadButtons[i].SetActive(true);
            }
            if (saveSlots[i].GetComponentInChildren<TextMeshProUGUI>().text == "Empty Slot")
            {
                if (i < 5)
                {
                    saveSlots[i + 1].SetActive(false);
                }
            }
            else
            {
                saveSlots[i].SetActive(true);
            }
            
        }
    }
    public void AddNewCard ()
    {
        if (storedNames.Count < 21)
        {
            SoundManager.PlaySound("drawCard");
            string inputText = textInput.text + "\n";
            storedNames.Add(inputText);
            removeButtons[storedNames.Count - 1].GetComponentInChildren<TextMeshProUGUI>().text = "";
            for (int i = 0; i < storedNames.Count; i++)
            {
                if(storedNames.Count > 1)
                {
                    removeButtons[storedNames.Count - 2].transform.GetChild(1).GetComponent<Canvas>().sortingOrder = 0;
                }
                removeButtons[storedNames.Count - 1].GetComponentInChildren<TextMeshProUGUI>().text = (storedNames[i]);
                removeButtons[storedNames.Count - 1].transform.GetChild(1).GetComponent<Canvas>().sortingOrder = 250;
            }
            removeButtons[storedNames.Count-1].SetActive(true);
            if (storedNames.Count > 1)
            {
                removeButtons[storedNames.Count - 2].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            SoundManager.PlaySound("errorSound");
            Debug.Log("Deck is full");
            return;
        }
    }
    public void AddNewSave(string nameoffile)
    {
        SoundManager.PlaySound("buttonClick");
        saveFiles.Add(nameoffile);
    }
    public void HowManyCards()
    {
        if (numberOfCards != 4)
        {
            scrollNumber += 1;
        }
        else
        {
            scrollNumber -= 3;
        }


            switch (scrollNumber)
            {
                default: 
                    numberOfCards = 1;
                    amountOfCards.text = "1";
                SoundManager.PlaySound("buttonClick");
                break;
                case 1:
                    numberOfCards = 2;
                    amountOfCards.text = "2";
                SoundManager.PlaySound("buttonClick");
                break;
                case 2:
                    numberOfCards = 3;
                    amountOfCards.text = "3";
                SoundManager.PlaySound("buttonClick");
                break;
                case 3:
                    numberOfCards = 4;
                    amountOfCards.text = "4";
                SoundManager.PlaySound("buttonClick");
                break;
            }
    }
    public void OnClick()
    {
        if (textInput.text == "")
            {
            SoundManager.PlaySound("errorSound");
            Debug.Log("Please enter a rule");
            return;
            }
            else
            {
            SoundManager.PlaySound("buttonClick");

            if (numberOfCards >= 0)
                {
                    AddNewCard();
                    if (numberOfCards > 1)
                    {
                        AddNewCard();
                        if (numberOfCards > 2)
                        {
                            AddNewCard();
                            if (numberOfCards > 3)
                            {
                                AddNewCard();
                            }
                        }
                    }
                }
            }
    }
    public void RemoveCard(int listNumber)
    {
        SoundManager.PlaySound("buttonClick");
        SoundManager.PlaySound("removeCard");
        removeRemove -= 1;
        storedNames.RemoveAt(listNumber);
        for (int i = 0; i < storedNames.Count; i++)
        {
            removeButtons[storedNames.Count - 1].GetComponentInChildren<TextMeshProUGUI>().text = (storedNames[i]);
        }
        removeButtons[storedNames.Count].SetActive(false);

    }
    public void OpenSave()
    {
        SoundManager.PlaySound("buttonClick");
        saveInput.SetActive(true);
        inputCard.SetActive(false);
        backButton.SetActive(true);
    }
    public void OpenLoad()
    {
        SoundManager.PlaySound("buttonClick");
        loadFiles.SetActive(true);
        inputCard.SetActive(false);
        backButton.SetActive(true);
    }


    public void Save(int saveSlot)
    {
        if ((saveInputText.text == "") || (saveInputText.text == "Empty Slot"))
        {
            Debug.Log("You must name your deck.");
            SoundManager.PlaySound("errorSound");
        }
        else
        {
            string sinputText = saveInputText.text;
            saveFiles.AddRange(saveFileArray);
            saveFiles[saveSlot - 1] = (sinputText);
            currentList = storedNames.ToArray();
            loadButtons[saveSlot - 1].SetActive(true);
            saveSlots[saveSlot - 1].SetActive(true);
            if (saveSlot < 6)
            {
                saveSlots[saveSlot].SetActive(true);
            }
            loadButtons[saveSlot - 1].GetComponentInChildren<TextMeshProUGUI>().text = (sinputText);
            saveSlots[saveSlot - 1].GetComponentInChildren<TextMeshProUGUI>().text = (sinputText);
            PlayerPrefsX.SetStringArray("" + (saveSlot), currentList);
            saveInput.SetActive(false);
            inputCard.SetActive(true);
            backButton.SetActive(true);
            saveArrays = saveFiles.ToArray();
            PlayerPrefsX.SetStringArray("Saves", saveArrays);
            saveFiles.Clear();
            backButton.SetActive(false);
            SoundManager.PlaySound("buttonClick");
            SoundManager.PlaySound("saveDeck");
        }
    }
    public void LoadCards(string saveName)
    {
        string[] loadedCards = PlayerPrefsX.GetStringArray(saveName);
        List<string> loadList = new List<string>();
        loadList.AddRange(loadedCards);
        storedNames.Clear();
        for (int i = 0; i < removeButtons.Length; i++)
        {
            removeButtons[i].SetActive(false);
        }
        storedNames = loadList;
        removeButtons[storedNames.Count].GetComponentInChildren<TextMeshProUGUI>().text = "";
        for (int i = 0; i < storedNames.Count; i++)
        {
            removeButtons[i].SetActive(true);
            removeButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = storedNames[i];
            removeButtons[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        loadFiles.SetActive(false);
        inputCard.SetActive(true);
        backButton.SetActive(false);
        SoundManager.PlaySound("buttonClick");
        SoundManager.PlaySound("loadDeck");
    }
    public void Back()
    {
        GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel = 0f;
        SoundManager.PlaySound("buttonClick");
        backButton.SetActive(false);
        loadFiles.SetActive(false);
        saveInput.SetActive(false);
        inputCard.SetActive(true);
        isPlaying = false;
        playArea.SetActive(false);
    }
    public void DrawCard()
    {
        if (cardNames.Count > 0)
        {
            SoundManager.PlaySound("drawCard");
            StartCoroutine("CardActive");
            if (madness)
            {
                if (GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel < 1f)
                {
                    if (GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel < 0.97f)
                    {
                        if (GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel < 0.8f)
                        {
                            GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel += 0.1f;

                        }
                        else
                        {
                            GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel += 0.017f;
                        }
                    }
                    else
                    {
                        GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel += 0.0082f;
                    }
                }
                else if (GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel > 1f)
                {
                    GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel = 1f;
                }
            }
            else
            {
                GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel = 0f;
            }
        }
        else
        {
            SoundManager.PlaySound("errorSound");
            chosenCard.SetActive(false);
            Debug.Log("Deck is empty, press F to Reshuffle ");
            cardObj.text = null;
            emptyText.SetActive(true);
        }
    }
    public void CardSetInActive()
    {
        SoundManager.PlaySound("dropCard");
        StartCoroutine("CardInactive");
    }
    public void Play()
    {
        if (storedNames.Count < 1)
        {
            Debug.Log("You don't have a deck selected");
            SoundManager.PlaySound("noDeck");
        }
        else
        {
            SoundManager.PlaySound("buttonClick");
            playArea.SetActive(true);
            backButton.SetActive(true);
            inputCard.SetActive(false);
            isPlaying = true;
        }
    }
    IEnumerator CardInactive()
    {
        anim.SetFloat("Inout", -2f);
        anim.Play("Card");
        yield return new WaitForSeconds(0.31f);
        chosenCard.SetActive(false);
        backButton.SetActive(true);
        reshuff.SetActive(true);
    }
    IEnumerator CardActive()
    {
        chosenCard.SetActive(true);
        anim.SetFloat("Inout", 1f);
        anim.Play("Card");
        Debug.Log("Card chosen is " + cardNames[randomCard]);
        cardObj.text = (cardNames[randomCard]);
        cardNames.Remove(cardNames[randomCard]);
        randomCard = Random.Range(0, cardNames.Count);
        backButton.SetActive(false);
        reshuff.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        anim.SetFloat("Inout", 0f);
    }
    public void LetsGo()
    {
        SoundManager.PlaySound("buttonClick");
        frontPanel.SetActive(false);
    }
    public void ReShuffle()
    {
            Debug.Log("Deck has been refilled");
            SoundManager.PlaySound("reshuffle");
            cardNames.Clear();
        GameObject.Find("MusicLoop").GetComponent<AudioDistortionFilter>().distortionLevel = 0f;
        GameObject.Find("MusicLoop").GetComponent<AudioSource>().volume = 0.01f;

        for (int i = 0; i < storedNames.Count; i++)
            {
                cardNames.Add(storedNames[i]);
                randomCard = Random.Range(0, cardNames.Count);
            }
            emptyText.SetActive(false);
            for (int i = 0; i < cardsInPlay.Length; i++)
            {
                cardsInPlay[i].SetActive(false);
            }
            for (int i = 0; i < storedNames.Count; i++)
            {
                cardsInPlay[i].SetActive(true);
            }
    }
    public void ClearSaves()
    {
        if (saveFileArray.Length < 1)
        {
            SoundManager.PlaySound("errorSound");
            Debug.Log("You don't have any decks saved");
        }
        else
        {
            PlayerPrefsX.SetStringArray("Saves", emptyPref);
            saveFiles.Clear();
            if (saveFiles.Count < 1)
            {
                saveFiles.Add("Empty Slot");
                saveFiles.Add("Empty Slot");
                saveFiles.Add("Empty Slot");
                saveFiles.Add("Empty Slot");
                saveFiles.Add("Empty Slot");
                saveFiles.Add("Empty Slot");
                for (int i = 0; i < 6; i++)
                {
                    loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFiles[i];
                    saveSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFiles[i];
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFileArray[i];
                    saveSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = saveFileArray[i];
                }
            }
        }
    }
    public void StopTheMadness()
    {
        madness = false;
        madnessButton.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
