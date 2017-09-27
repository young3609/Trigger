using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCtrl : MonoBehaviour {

    public float sayi;
    public Text sayiyazi;
    public GameObject ekran;
    public Image bar;

    // Use this for initialization
    void Start()
    {
        ekran.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        sayiyazi.text = "" + (int)sayi + "%";
        //bar.transform.localScale = new Vector3(sayi / 100, 1, 1);
        bar.fillAmount = sayi / 100;
        if (sayi < 100)
        {
            sayi += Time.deltaTime * 5;
        }
        if (sayi >= 100)
        {
            sayi = 100;
            ekran.SetActive(false);
        }
    }
}
//public float sayi;
//public Text sayiyazi;
//public GameObject bar, ekran;

//// Use this for initialization
//void Start()
//{
//    ekran.SetActive(true);
//}

//// Update is called once per frame
//void Update()
//{
//    sayiyazi.text = "" + (int)sayi + "%";
//    bar.transform.localScale = new Vector3(sayi / 100, 1, 1);
//    if (sayi < 100)
//    {
//        sayi += Time.deltaTime * 5;
//    }
//    if (sayi >= 100)
//    {
//        sayi = 100;
//        ekran.SetActive(false);
//    }
//}