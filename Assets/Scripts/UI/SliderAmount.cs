using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAmount : MonoBehaviour
{
    public static SliderAmount main;

    public Text text;

    public Slider sliderObject;

    public int maxAmount;

    public int _amount;

    private void Awake()
    {
        main = this;
    }

    public void ChangeValue()
    {
        _amount = (int) (sliderObject.value);
        if (_amount >= maxAmount)
        {
            text.text = "MAX";
        }
        else
        {
            //main.GetComponent<UnityEngine.UI.Text>().text = "" + _amount;
            text.text = "" + _amount;
        }
    }
}
