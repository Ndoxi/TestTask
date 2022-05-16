using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header("PlayerHealthBarSlider")]
    [SerializeField] private Slider _healthBarSlider;

    public static UIManager Instance;


    private void OnEnable()
    {
        Instance = this;
    }


    public void SetHealthBar(int maxValue)
    {
        _healthBarSlider.maxValue = maxValue;
        _healthBarSlider.value = maxValue;
    }


    public void SetHealthBarValue(int value)
    {
        _healthBarSlider.value = value;
    }
}