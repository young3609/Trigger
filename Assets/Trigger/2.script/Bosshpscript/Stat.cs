using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {            
            this.currentVal = Mathf.Clamp(value,0,MaxVal); // 0이하나 100이상 되지 않게 하기위해 사용
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    public void Initialize() {
        this.MaxVal = maxVal+(100*Global.stagecount);
        this.CurrentVal = currentVal + (100 * Global.stagecount);
    }
}
