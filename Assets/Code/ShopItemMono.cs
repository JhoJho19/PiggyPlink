using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using ProgressAndDataNamespace;
using static UnityEditor.Progress;
using UnityEngine.Events;



public class ShopItemMono : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _prevButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _bonusesTabButton;
    [SerializeField] private Button _skinsTabButton;

    [SerializeField] List<Sprite> _boostsSpritesList;
    [SerializeField] List<Sprite> _skinsSpritesList;
    private List<Sprite> _currentsList;

    private int _currentIndex;

    private void Start()
    {
        _prevButton.onClick.AddListener(ShowPrevious);
        _nextButton.onClick.AddListener(ShowNext);
        _buyButton.onClick.AddListener(BuyCurrent);
        _bonusesTabButton.onClick.AddListener(SelectBonuses);
        _skinsTabButton.onClick.AddListener(SelectSkins);

        SelectBonuses();
    }

    private void SelectBonuses()
    {
        _currentsList = _boostsSpritesList;
        _currentIndex = 0;
        UpdateUI();
    }

    private void SelectSkins()
    {
        _currentsList = _skinsSpritesList;
        _currentIndex = 0;
        UpdateUI();
    }

    private void ShowPrevious()
    {
        if (_currentsList.Count == 0) return;
        _currentIndex = (_currentIndex - 1 + _currentsList.Count) % _currentsList.Count;
        UpdateUI();
    }

    private void ShowNext()
    {
        if (_currentsList.Count == 0) return;
        _currentIndex = (_currentIndex + 1) % _currentsList.Count;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_currentsList.Count == 0)
        {
            _buyButton.interactable = false;
            return;
        }

        _iconImage.sprite = _currentsList[_currentIndex];

        if(_currentsList == _boostsSpritesList && _currentIndex == 0) // двойной доход
        {
            _descriptionText.text = "Multiplies your winnings!";
            _priceText.text = $"¢ 800";
            _buyButton.interactable = ProgressData.GoldCoinCounter >= 800;
        }
        else if (_currentsList == _boostsSpritesList && _currentIndex == 1) // двойной мяч
        {
            _descriptionText.text = "Double your balls!";
            _priceText.text = $"¢ 500";
            _buyButton.interactable = ProgressData.GoldCoinCounter >= 500;
        }
        else if(_currentsList == _boostsSpritesList && _currentIndex == 2) // ускорение
        {
            _descriptionText.text = "Game Accelerator!";
            _priceText.text = $"¢ 100";
            _buyButton.interactable = ProgressData.GoldCoinCounter >= 100;
        }
        else if(_currentsList == _skinsSpritesList && _currentIndex == 0) // желтый мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isYellowBakkOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isYellowBakkOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isYellowBakkOpen)
                _buyButton.interactable = true;
            if (ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 1) // зеленый мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isGreenBallOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isGreenBallOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isGreenBallOpen)
                _buyButton.interactable = true;
            if (ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 2) // оранжевый мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isOrangeBallOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isOrangeBallOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isOrangeBallOpen)
                _buyButton.interactable = true;
            if (ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 3) // синий мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isBlueBallOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isBlueBallOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isBlueBallOpen)
                _buyButton.interactable = true;
            if (ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 4) // розовый мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isPinkBallOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isPinkBallOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isPinkBallOpen)
                _buyButton.interactable = true;
            if (ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 5) // фиолетовый мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isVioletBallOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isVioletBallOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isVioletBallOpen)
                _buyButton.interactable = true;
            if (ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 6) // оранжевый 2 мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isOrange2BallOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isOrange2BallOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isOrange2BallOpen)
                _buyButton.interactable = true;
            if (ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 7) // красный мяч
        {
            _descriptionText.text = "";
            _priceText.text = ProgressData.isRedBallOpen ? "USE" : $"¢ 100";
            _buyButton.interactable = !ProgressData.isRedBallOpen && ProgressData.GoldCoinCounter >= 100;
            if (ProgressData.isRedBallOpen)
                _buyButton.interactable = true;
            if(ProgressData.currentSkinIndex == _currentIndex)
                _buyButton.interactable = false;
        }
    }

    private void BuyCurrent()
    {
        if (_currentsList == _boostsSpritesList && _currentIndex == 0) // двойной доход
        {
            ProgressData.GoldCoinCounter -= 800;
            ProgressData.DoubleCoins++;
        }
        else if (_currentsList == _boostsSpritesList && _currentIndex == 1) // двойной мяч
        {
            ProgressData.GoldCoinCounter -= 500;
            ProgressData.DoubleBalls++;
        }
        else if (_currentsList == _boostsSpritesList && _currentIndex == 2) // ускорение
        {
            ProgressData.GoldCoinCounter -= 100;
            ProgressData.FasterBonus++;
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 0) // желтый мяч
        {
            if(!ProgressData.isYellowBakkOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isYellowBakkOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 1) // зеленый мяч
        {
            if (!ProgressData.isGreenBallOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isGreenBallOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 2) // оранжевый мяч
        {
            if (!ProgressData.isOrangeBallOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isOrangeBallOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 3) // синий мяч
        {
            if (!ProgressData.isBlueBallOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isBlueBallOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 4) // розовый мяч
        {
            if (!ProgressData.isPinkBallOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isPinkBallOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 5) // фиолетовый мяч
        {
            if (!ProgressData.isVioletBallOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isVioletBallOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 6) // оранжевый 2 мяч
        {
            if (!ProgressData.isOrange2BallOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isOrange2BallOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        else if (_currentsList == _skinsSpritesList && _currentIndex == 7) // красный мяч
        {
            if (!ProgressData.isRedBallOpen)
            {
                ProgressData.GoldCoinCounter -= 100;
                ProgressData.isRedBallOpen = true;
                ProgressData.currentSkinIndex = _currentIndex;
            }
            else
            {
                ProgressData.currentSkinIndex = _currentIndex;
            }
        }
        UpdateUI();
        CoinsOutput[] coinsOutputs = FindObjectsOfType<CoinsOutput>();
        foreach(var c in coinsOutputs)
        {
            c.UpdateCoinCounter();
        }
    }
}

