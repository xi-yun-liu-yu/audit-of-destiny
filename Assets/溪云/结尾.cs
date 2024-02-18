using System.Collections;
using UnityEngine;

public class 结尾 : MonoBehaviour
{
    public float switchInterval = 5f; // 切换图片的时间间隔（以秒为单位）
    public Sprite[] 保守派; // 图片数组，包含你想要切换的图片
    public Sprite[] 激进派; // 图片数组，包含你想要切换的图片
    public Sprite[] 毁灭派; // 图片数组，包含你想要切换的图片
    public Sprite[] 平淡; // 图片数组，包含你想要切换的图片

    private int imageIndex = 0; // 当前图片索引
    private GameObject imageComponent; // Image组件的引用
    public GameObject action; // Image组件的引用

    public void 保守派结局()
    {
        imageComponent.gameObject.SetActive(true);
        // 启动协程来定时切换图片
        StartCoroutine(SwitchImages(保守派));
        action.gameObject.SetActive(true);
    }
    public void 激进派结局()
    {
        imageComponent.gameObject.SetActive(true);
        // 启动协程来定时切换图片
        StartCoroutine(SwitchImages(激进派));
        action.gameObject.SetActive(true);
    }

    public void 毁灭派结局()
    {
        imageComponent.gameObject.SetActive(true);
        // 启动协程来定时切换图片
        StartCoroutine(SwitchImages(毁灭派));
        action.gameObject.SetActive(true);
    }

    public void 平淡结局()
    {
        imageComponent.gameObject.SetActive(true);
        // 启动协程来定时切换图片
        StartCoroutine(SwitchImages(平淡));
        action.gameObject.SetActive(true);
    }


    private IEnumerator SwitchImages(Sprite[] 图片组)
    {
        while (imageIndex < 图片组.Length)
        {
            yield return new WaitForSeconds(switchInterval);
            // 切换到下一张图片
            imageIndex = imageIndex + 1;
            Sprite nextImage = 图片组[imageIndex];
            imageComponent.GetComponent<SpriteRenderer>().sprite = nextImage;
        }
        imageComponent.gameObject.SetActive(false);
    }
}
