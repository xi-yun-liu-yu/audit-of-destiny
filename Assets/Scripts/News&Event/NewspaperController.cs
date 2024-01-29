using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace News_Event
{
    public class NewspaperController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> newspaperList=new List<GameObject>();
        [SerializeField] private GameObject newspaperPrefab;
        [SerializeField] private GameObject list;
        public int index=0;
        public static NewspaperController Instance{ get; private set; }
        public GameObject t1;// 周报折叠时候的位置
        public GameObject t2;// 周报展开时候的位置
        
        
        private void Awake()
        {
            Instance = this;
        }
        public void GenerateNewspapers()
        {
            index=newspaperList.Count;
            GameObject clone = Instantiate(newspaperPrefab,list.transform,false);
            clone.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            clone.GetComponent<Canvas>().sortingOrder = newspaperList.Count;
            clone.GetComponent<Newspaper>().Information.GetComponent<Information>().FoldTransform = t1.transform;
            clone.GetComponent<Newspaper>().Information.GetComponent<Information>().OpenTransform = t2.transform;
            clone.SetActive(false);
            clone.SetActive(true);
            newspaperList.Add(clone);
            DisplayAll();// 赞美万机之神！
            FoldAll();// 赞美欧姆弥撒亚!
        }
        public void ToPrevious()
        {
            if (index==0) return;
            index -= 1;
            newspaperList[index].GetComponent<Newspaper>().Information.GetComponent<Information>().isFolded = false;
            newspaperList[index].GetComponent<Newspaper>().Information.GetComponent<Information>().isMoving = true;
        }

        public void ToNext()
        {
            if (index==newspaperList.Count) return;
            newspaperList[index].GetComponent<Newspaper>().Information.GetComponent<Information>().isFolded = true;
            newspaperList[index].GetComponent<Newspaper>().Information.GetComponent<Information>().isMoving = true;
            index += 1;
        }

        public void DisplayAll()
        {
            foreach (var newspaper in newspaperList)
            {
                newspaper.GetComponent<Newspaper>().Information.GetComponent<Information>().ToNext();
            }

            index = newspaperList.Count();
        }
        public void FoldAll()
        {
            foreach (var newspaper in newspaperList)
            {
                newspaper.GetComponent<Newspaper>().Information.GetComponent<Information>().ToPrevious();
            }

            index = 0;
        }
    }
}
