using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int left = 15;
    public Text counter, counter2;
    public Text buffT, buffT2;
    public Image i;
    public int buff;
    public Sprite b1, b2, b3, b4, b5;
    // Start is called before the first frame update
    void Start()
    {
        i.enabled = false;
        buff = PlayerPrefs.GetInt("Buff", 0);
        buffT.text = "";
        buffT2.text = buffT.text;
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            counter.enabled = false;
            counter2.enabled = false;
        }
        else
            left = 15;   
    }

    // Update is called once per frame
    void Update()
    {
        if (left < 0)
            left = 0;
        buff = PlayerPrefs.GetInt("Buff", 0);
        counter.text = left.ToString() + "/15";
        counter2.text = left.ToString() + "/15";
        switch (buff)
        {
            case 1:
                i.enabled = true;
                i.sprite = b1;
                buffT.text = "скорость движения";
                buffT2.text = "скорость движения";
                break; 
            case 2:
                i.enabled = true;
                i.sprite = b2;
                buffT.text = "скорость полёта пули";
                buffT2.text = "скорость полёта пули";
                break;
            case 3:
                i.enabled = true;
                i.sprite = b3;
                buffT.text = "скорость движения \nскорость полёта пули";
                buffT2.text = "скорость движения \nскорость полёта пули";
                break;
            case 4:
                i.enabled = true;
                i.sprite = b4;
                buffT.text = "доп. пуля";
                buffT2.text = "доп. пуля";
                break;
            case 5:
                i.enabled = true;
                i.sprite = b5;
                buffT.text = "скорость движения \nдоп. пуля";
                buffT2.text = "скорость движения \nдоп. пуля";
                break;
        }
    }
}
