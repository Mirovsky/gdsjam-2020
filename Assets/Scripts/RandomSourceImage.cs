using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSourceImage : MonoBehaviour
{
    public Sprite[] Sprites;

    // Start is called before the first frame update
    void Start()
    {
        int index = (int)Random.Range(0, Sprites.Length-1);
        Sprite sprite = Sprites[index];

        var image = GetComponent<Image>();
        image.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
