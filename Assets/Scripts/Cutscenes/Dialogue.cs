using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class Dialogue : MonoBehaviour
{
    public string[] sentences;
    public Text Texto;
    public GameObject king, kingIMG, kingTrue, player;
    public float speed;
    int i = 0;
    public GameObject b;

    void Start()
    {
        Texto.text = "";
        StartCoroutine(TypeText());
    }

    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Cutscene0":
                if (i == 3)
                    player.SetActive(true);
                if (i > 3 && i < 8)
                    king.SetActive(true);
                else    
                    king.SetActive(false);
                break;
            case "Cutscene1":
                if (i == 1)
                    king.SetActive(true);
                break;
            case "Cutscene3":
                if (i == 3)
                    king.SetActive(false);
                else if (i > 3)
                {
                    kingIMG.SetActive(false);
                    kingTrue.SetActive(true);
                    king.SetActive(true);
                } 
                break;
        }       
    }

    IEnumerator TypeText()
    {
        foreach (char c in sentences[i].ToCharArray())
        {
            Texto.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    public void ButtonClick()
    {
        if (Texto.text != sentences[i])
            {
                StopAllCoroutines();
                Texto.text = sentences[i];   
            }
        else
            if (i == sentences.Length - 1)
                b.GetComponent<SceneManagementus>().LoadLevel(SceneManager.GetActiveScene().name);
            else
            {
                Texto.text = "";
                i++;
                StartCoroutine(TypeText());
            }       
    }
}
