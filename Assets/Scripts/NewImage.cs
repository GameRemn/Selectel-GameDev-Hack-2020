using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewImage : MonoBehaviour
{
    public Sprite image;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Canvas").GetComponent<Image>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
