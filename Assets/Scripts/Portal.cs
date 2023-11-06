using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    public Sprite enabledd;
    bool e = false;
    string Sname = "";
    void Start()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Level1":
                Sname = "Cutscene1";
                break;
            case "Level2":
                Sname = "Cutscene2";
                break;
            case "Level3":
                Sname = "Cutscene3";
                break;
            case "Level4":
                Sname = "Cutscene4";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.GetComponent<Counter>().left <= 0)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = enabledd;
            e = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && e)
            SceneManager.LoadScene(Sname);
    }
}
