﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image content;

    [SerializeField]
    private Text valueText;

    [SerializeField]
    private Color fullColor;

    [SerializeField]
    private Color lowColor;
    
    public float MaxValue { get; set; }

    public float Value {
        set {
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
            fillAmount = Map(value,0,MaxValue,0,1);
        }
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar() {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
        content.color = Color.Lerp(lowColor, fullColor, fillAmount);
    }

    private float Map(float value, float inMin, float inMAX, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMAX - inMin) + outMin;
    }
}
