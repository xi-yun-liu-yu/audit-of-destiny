using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class News : MonoBehaviour
{
    private String title { get; set; }
    private String content{ get; set; }
    private GameObject news;


    public News([NotNull] string title, [NotNull] string content)
    {
        this.title = title ?? throw new ArgumentNullException(nameof(title));
        this.content = content ?? throw new ArgumentNullException(nameof(content));
    }

    public void SetNews([NotNull] string title, [NotNull] string content)
    {
        this.title = title ?? throw new ArgumentNullException(nameof(title));
        this.content = content ?? throw new ArgumentNullException(nameof(content));
    }
    public void SetNews(News news)
    {
        title = news.title;
        content = news.content;
    }

    private void OnEnable()
    {
        news = this.gameObject;
        gameObject.transform.Find("NewsTitle").GetComponent<Text>().text = title;
        gameObject.transform.Find("NewsBackground").transform.Find("NewsContent").GetComponent<Text>().text = content;
    }
}
