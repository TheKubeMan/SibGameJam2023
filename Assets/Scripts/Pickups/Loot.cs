using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : MonoBehaviour
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Loot(string lootName, int dropChance) 
    { 
        this.lootName = lootName;   
        this.dropChance = dropChance;
    }
}
