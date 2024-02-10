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
    public float speed;
    int i = 0;
    public GameObject b;

    void Start()
    {
        Texto.text = "";
        StartCoroutine(TypeText());
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
