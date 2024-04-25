using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NBC_Project2
{
    struct IItem  // 아이템 구조체
    {
        public string itemname;  // 아이템 이름
        public int effect;      // 아이템 효과
        public string description;  //아이템 설명
        public int price;       //아이템 가격
        public bool isEquip;    // 장비했는지
        public bool isBuy;      // 구매했는지
        public int itemType;    // 아이템 타입 1이면 방어구 2면 무기

        public IItem(string itemname, int effect, string description, int price, bool isEquip, bool isBuy, int type)
        {
            this.itemname = itemname;
            this.effect = effect;
            this.description = description;
            this.price = price;
            this.isEquip = isEquip;
            this.isBuy = isBuy;
            this.itemType = type;
        }

        public void PrintInfoInven()  //인벤토리 목록 출력
        {
            if(itemType == 1)
            {
                Console.WriteLine($"{itemname} | 방어력 +{effect} | {description}");
            }
            else
            {
                Console.WriteLine($"{itemname} | 공격력 +{effect} | {description}");
            }
        }

        public void PrintInfoShop()  //상점 목록 출력
        {
            if (itemType == 1) 
            {
                Console.WriteLine($"{itemname} | 방어력 +{effect} | {description} | {price}G");
            }
            else
            {
                Console.WriteLine($"{itemname} | 공격력 +{effect} | {description} | {price}G");
            }

        }
        public void PrintInfoSell()  //판매 목록 출력
        {
            if (itemType == 1)
            {
                Console.WriteLine("{0} | 방어력 +{1} | {2} | {3}G", itemname, effect, description, Convert.ToInt32(price * 0.85));
            }
            else
            {
                Console.WriteLine("{0} | 공격력 +{1} | {2} | {3}G", itemname, effect, description, Convert.ToInt32(price * 0.85));
            }

        }

        public void PrintIsBuy()  //상점 목록 중 구매한 적이 있는 아이템에만 출력
        {
            if (itemType == 1)
            {
                Console.WriteLine($"{itemname} | 방어력 +{effect} | {description} | 구매 완료");
            }
            else
            {
                Console.WriteLine($"{itemname} | 공격력 +{effect} | {description} | 구매 완료");
            }
        }
    }

    struct Status  //상태 구조체
    {
        public int level;       //레벨
        public string nickname;  //이름
        public float attack;      //공격력
        public float defense;     //방어력
        public int hp;          //체력
        public int gold;        //보유 골드
    }

    internal class DataManager
    {
        public Status status;
        public IItem item;

        public List<IItem> inven = new List<IItem>();  //인벤토리 리스트
        public List<IItem> list = new List<IItem>();  //아이템 리스트


        private static DataManager instance;
        public static DataManager Instance  // 싱글톤 사용
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }

        public void InputItemtoInven(IItem item)  // 인벤에 아이템 추가
        {
            inven.Add(item);
        }

        public void PrintInvenList()  //인벤 출력
        {
            int i= 1;

            foreach (var item in inven)
            {
                Console.Write($"{i}. ");
                item.PrintInfoInven();
                Console.WriteLine();
                i++;
            }
        }

        public void PrintShopList()  //상점 목록 출력
        {
            int i = 1;

            foreach (var item in list)
            {
                if (!item.isBuy)  //산적이 없다면
                {
                    Console.Write($"{i}. ");
                    item.PrintInfoShop();
                    Console.WriteLine();
                    i++;
                }
                else  //산적이 있다면
                {
                    Console.Write($"{i}. ");
                    item.PrintIsBuy();
                    Console.WriteLine();
                    i++;
                }
            }
        }

        public void PrintSellList()  // 판매 목록 출력
        {
            int i = 1;
            foreach (var item in inven)
            {
                Console.Write($"{i}. ");
                item.PrintInfoSell();
                Console.WriteLine();
                i++;
            }
        }

        public void InputStatus(int lv, string name, float a, float d, int h, int g)
        {
            status.level = lv;
            status.nickname = name;
            status.attack = a;
            status.defense = d;
            status.hp = h;
            status.gold = g;
        }

        public void PrintStatus()  //상태 출력
        {
            int a = 0;
            int d = 0;

            foreach(var item in inven)  // 아이템 장착 시, 아이템 효과 적용
            {
                if (item.isEquip)
                {
                    if(item.itemType == 1)
                    {
                        d = item.effect;
                    }
                    else
                    {
                        a = item.effect;
                    }
                }
            }

            Console.WriteLine("LV. " + status.level);
            Console.WriteLine(status.nickname);
            Console.WriteLine("공격력 : " + (status.attack + a) + $" (+{a})");
            Console.WriteLine("방어력 : " + (status.defense + d) + $" (+{d})");
            Console.WriteLine("체력 : " + status.hp);
            Console.WriteLine("Gold : " + status.gold + " G");
        }

        public void LevelUp()  // 레벨 업
        {
            status.level++;
            status.attack += 0.5f;
            status.defense += 1;
        }

    }
}

