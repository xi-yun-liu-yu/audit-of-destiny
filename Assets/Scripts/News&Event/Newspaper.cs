using System;
using UnityEngine;

namespace News_Event
{
    public class Newspaper: MonoBehaviour
    {
        public GameObject News_Background;
        public GameObject Information;
        public GameObject BalanceOfPower;
        public GameObject Relationship;
        public GameObject Money;
        public GameObject NewsList;

        private bool isDisplay;

        private void Update()
        {
            if ((!Information.GetComponent<Information>().isMoving)&&(!Information.GetComponent<Information>().isFolded)&&
                (!isDisplay))
            {
                NewsList.GetComponent<NewsListConroller>().Display();
                BalanceOfPower.GetComponent<BalanceOfPower>().RenewBalance();
                Relationship.GetComponent<Relationship>().RenewRelationship();
                Money.GetComponent<Money>().RenewMoney();
                isDisplay = true;
            }
        }
    }
    
}