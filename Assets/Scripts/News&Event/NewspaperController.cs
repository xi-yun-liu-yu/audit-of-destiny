using System.Collections.Generic;
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

        public GameObject t1;
        public GameObject t2;
        public void GenerateNewspapers()
        {
            GameObject clone = Instantiate(newspaperPrefab,list.transform,false);
            clone.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            clone.GetComponent<Canvas>().sortingOrder = index;
            clone.GetComponent<Newspaper>().Information.GetComponent<Information>().FoldTransform = t1.transform;
            clone.GetComponent<Newspaper>().Information.GetComponent<Information>().OpenTransform = t2.transform;
            clone.SetActive(false);
            clone.SetActive(true);
            newspaperList.Add(clone);
            index++;
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
        }
    }
}
