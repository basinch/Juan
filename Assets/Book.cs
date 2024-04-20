using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public GameObject panelObject;
    public Sprite[] bookImg = null;
    public GameObject imageHolder;
    private Image rawimg;
    private int bookNumber = 0;
    private int bookNum;
    // Start is called before the first frame update
    void Start()
    {
        rawimg = imageHolder.GetComponent<Image>();
        rawimg.sprite = bookImg[0];
        bookNum = bookImg.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bookNumber); 
        Debug.Log(bookImg);
    }
    public void NextButton()
    {
        if (bookNumber == bookNum - 1)
        {
            rawimg.sprite = bookImg[0]; 
            bookNumber = 0;
        }
        else
        {
            rawimg.sprite = bookImg[bookNumber + 1];
            bookNumber++;
        }
    }

    public void PrevButton()
    {
        if (bookNumber == 0)
        {
            rawimg.sprite = bookImg[bookNum - 1];
            bookNumber = bookNum - 1;
        }
        else
        {
            rawimg.sprite = bookImg[bookNumber - 1];
            bookNumber--;
        }
    }
    public void Onclick()
    {
        if (panelObject.activeSelf)
        {
            panelObject.SetActive(false);
        }
        else
        {
            panelObject.SetActive(true);
        }
    }
}
