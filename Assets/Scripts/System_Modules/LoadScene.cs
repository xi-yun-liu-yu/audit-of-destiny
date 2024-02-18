using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string Departure ;
    public string aimscene;

    public Button  button;  // 按钮对象
    public Vector3 targetPosition;  // 目标位置
    public Vector3 targetPosition2;  // 目标位置
    public Vector2 targetSize;  // 目标大小
    public Vector2 targetSize2;  // 目标大小
    public Sprite targetSprite;  // 目标贴图
    public Sprite targetSprite2;  // 目标贴图
    private RectTransform buttonRect;  // 按钮的RectTransform组件
    public Sprite thePressedSprite;
    public Sprite thePressedSprite2;
    public Sprite thePressedSprite3;

    public void ToAimScene()
    {
        SceneManager.LoadScene(aimscene);
        buttonRect = button.GetComponent<RectTransform>();
        // 移动按钮到目标位置
        buttonRect.position = targetPosition;

        // 改变按钮大小到目标大小
        buttonRect.sizeDelta = targetSize;

        // 修改按钮贴图
        button.image.sprite = targetSprite;

        // 设置按钮按下时的 Sprite
        button.spriteState = new SpriteState() { pressedSprite = thePressedSprite ,highlightedSprite = null};
        

        
    }
    
    public void back()
    {
        SceneManager.LoadScene(Departure);
        buttonRect = button.GetComponent<RectTransform>();
        // 移动按钮到目标位置
        buttonRect.position = targetPosition2;

        // 改变按钮大小到目标大小
        buttonRect.sizeDelta = targetSize2;

        // 修改按钮贴图
        button.image.sprite = targetSprite2;

        // 设置按钮按下时的 Sprite
        button.spriteState = new SpriteState() { pressedSprite = thePressedSprite2 ,highlightedSprite = thePressedSprite3};
    }
}