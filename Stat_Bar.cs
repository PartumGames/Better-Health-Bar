using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//----need this

public class Stat_Bar : MonoBehaviour
{

    private Slider slider;

    private Image background;
    private Image sliderBar;
    private Text sliderText;

    [SerializeField]
    private float value;

    [SerializeField]
    private float maxValue;

    [SerializeField]
    private string textValue;

    public bool showText = true;

    public Color sliderbarColor;
    public Color backgroundColor;


    private void Start()
    {
        slider = GetComponent<Slider>();
        background = transform.GetChild(0).GetComponent<Image>();
        sliderBar = transform.GetChild(1).GetComponentInChildren<Image>();
        sliderText = transform.GetChild(3).GetComponent<Text>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        value = Mathf.Clamp(value, 0, maxValue);

        slider.value = value;

        if(value == 0)
        {
            sliderBar.enabled = false;
        }
        else
        {
            sliderBar.enabled = true;
        }

        if (showText)
        {
            sliderText.enabled = true;
            // sliderText.text = textValue;
            sliderText.text = textValue + "  " + value.ToString("f2") + " / " + maxValue.ToString();
        }
        else
        {
            sliderText.enabled = false;
        }


        slider.maxValue = maxValue;
        sliderBar.color = sliderbarColor;
        background.color = backgroundColor;

    }


    public void SetValue(float _value)
    {
        value = _value;
        UpdateUI();
    }

    public void SetMaxValue(float _value)
    {
        maxValue = _value;
        UpdateUI();
    }

    public void SetTextValue(string _value)
    {
        textValue = _value;
        UpdateUI();
    }

    public void SetSliderBarColor(Color _value)
    {
        sliderbarColor = _value;
        UpdateUI();
    }

    public void SetBackgroundColor(Color _value)
    {
        backgroundColor = _value;
        UpdateUI();
    }

}
