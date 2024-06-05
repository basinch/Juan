using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Image> arrowImages; // Ekrandaki tuş görselleri
    [SerializeField] private Sprite upArrow, downArrow, leftArrow, rightArrow; // Yön tuşu görselleri
    [SerializeField] private float resetDelay = 1f; // Yanlış tuş basıldığında yeniden başlama gecikmesi

    private List<KeyCode> currentCombination; // Mevcut kombinasyon
    private List<KeyCode> playerInput; // Oyuncu girdisi
    private int currentStep; // Şu anki adım

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        CheckPlayerInput();
    }

    void InitializeGame()
    {
        // Kombinasyonu tanımla
        currentCombination = new List<KeyCode> { KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.LeftArrow };
        playerInput = new List<KeyCode>();
        currentStep = 0;
        DisplayArrows();
    }

    void DisplayArrows()
    {
        // Yön tuşlarını ekranda göster
        for (int i = 0; i < arrowImages.Count; i++)
        {
            switch (currentCombination[i])
            {
                case KeyCode.UpArrow:
                    arrowImages[i].sprite = upArrow;
                    break;
                case KeyCode.RightArrow:
                    arrowImages[i].sprite = rightArrow;
                    break;
                case KeyCode.DownArrow:
                    arrowImages[i].sprite = downArrow;
                    break;
                case KeyCode.LeftArrow:
                    arrowImages[i].sprite = leftArrow;
                    break;
            }
        }
    }

    void CheckPlayerInput()
    {
        if (Input.anyKeyDown)
        {
            KeyCode keyPressed = GetCurrentKeyPressed();

            if (keyPressed == currentCombination[currentStep])
            {
                playerInput.Add(keyPressed);
                currentStep++;
                if (currentStep == currentCombination.Count)
                {
                    // Başarılı
                    Debug.Log("Başarılı!");
                    InitializeGame();
                }
            }
            else
            {
                // Yanlış tuş basıldı
                Debug.Log("Yanlış tuş! Yeniden başla.");
                StartCoroutine(ResetGame());
            }
        }
    }

    KeyCode GetCurrentKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) return KeyCode.UpArrow;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return KeyCode.RightArrow;
        if (Input.GetKeyDown(KeyCode.DownArrow)) return KeyCode.DownArrow;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return KeyCode.LeftArrow;
        return KeyCode.None;
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(resetDelay);
        InitializeGame();
    }
}