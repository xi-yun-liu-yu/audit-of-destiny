using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�л�����
public class imageController : MonoBehaviour
{
    public Image image;
    public Sprite sprite;

    public void setImage()
    {
        image.sprite = sprite;
    }
}
