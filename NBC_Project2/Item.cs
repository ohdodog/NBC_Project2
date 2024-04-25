using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC_Project2
{
    internal class Item
    {  
        public void InitItem()
        {
            DataManager.Instance.list.Add(new IItem("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000, false, true, 1));
            DataManager.Instance.list.Add(new IItem("무쇠갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, false, false, 1));
            DataManager.Instance.list.Add(new IItem("스파르타 갑옷", 15, "스파르타 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false, false, 1));
            DataManager.Instance.list.Add(new IItem("아킬레우스의 갑옷", 25, "그리스 신화의 아킬레우스가 사용했다는 신화 속 갑옷입니다.", 5000, false, false, 1));
            DataManager.Instance.list.Add(new IItem("낡은 검", 2, "쉽게 볼수 있는 낡은 검 입니다.", 600, false, true, 2));
            DataManager.Instance.list.Add(new IItem("청동 도끼", 5, "어디선가 사용됐던거 같은 도끼입니다", 1500, false, false, 2));
            DataManager.Instance.list.Add(new IItem("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000, false, false, 2));
            DataManager.Instance.list.Add(new IItem("궁니르", 12, "북유럽 신화의 최고신 오딘이 사용했다는 신화 속 창입니다.", 4500, false, false, 2));
        }
    }
}

