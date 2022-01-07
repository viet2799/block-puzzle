using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    // Start is called before the first frame update
    public Image normalImage;
    public Sprite normalImages;
    void Start()
    {
        
    }

    public void SetImage(bool setFirstImage)
    {
        normalImage.GetComponent<Image>().sprite = normalImages;
    }

}
