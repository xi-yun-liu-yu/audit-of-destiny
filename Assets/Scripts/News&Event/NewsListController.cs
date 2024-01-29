using System;
using System.Collections.Generic;
using UnityEngine;

namespace News_Event
{
    public class NewsListConroller : MonoBehaviour
    {
        [Header("新闻的尺寸")]
        [Tooltip("注意宽度不要超过容器的宽度")]
        [SerializeField] private float newsLength;
        [SerializeField] private float newsWidth;

        [Header("边距")] 
        [SerializeField] private float leftMargin;
        [SerializeField] private float topMargin;
        [Header("news预制体")] [SerializeField] private GameObject newsPrefabs;

        [Header("绑定目标内容物")] [Tooltip("默认为Content，最好别改")]
        [SerializeField]private GameObject Content;

        private List<(string,string)> NewsList=new List<(string, string)>();
        public static NewsListConroller Instance{ get; private set; }
        private void Awake() { Instance = this; }
    
        // 展示新闻列表中的所有新闻
        public void Display()
        {
            int i;
            for ( i= 0; i < NewsList.Count; i++)
            {
                var news = NewsList[i];
                GameObject clone = Instantiate(newsPrefabs, Content.transform, true);
                clone.GetComponent<News>().SetNews(news.Item1, news.Item2);
                clone.GetComponent<RectTransform>().sizeDelta = new Vector2(newsWidth, newsLength);
                clone.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(leftMargin, -topMargin - (i * (topMargin+newsLength)), 0);
                clone.SetActive(false);
                clone.SetActive(true);
            }

            Content.GetComponent<RectTransform>().sizeDelta = new Vector2(20 + newsWidth + leftMargin + leftMargin,
                i*(topMargin + topMargin + newsLength));
        }

        // 测试方法
        public void test()
        {
            NewsList.Add(("标题","内容"));
        }

        public void AddNews(string title, string content)
        {
            Debug.Log(title);
            NewsList.Add((title, content));
        }
        
    }
}
