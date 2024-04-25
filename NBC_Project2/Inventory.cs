using NBC_Project2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC_Project2
{
    internal class Inventory
    {   
        public void InitInvenFirst()  //기본 장비 지급
        {
            DataManager.Instance.inven.Add(new IItem("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000, false, true, 1));
            DataManager.Instance.inven.Add(new IItem("낡은 검", 2, "쉽게 볼수 있는 낡은 검 입니다.", 600, false, true, 2));
        }

        public void InventoryScene()  //인벤토리
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다 ");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                DataManager.Instance.PrintInvenList();

                Console.WriteLine();
                Console.WriteLine("1. 장착관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">>");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (choice == 1)
                {
                    EquipmentScene();
                }
                else if (choice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 행동입니다.");
                }
            }
        }

        public void EquipmentScene()  //장착 관리
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다 ");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                DataManager.Instance.PrintInvenList();

                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("장착할 장비를 정해주세요");
                Console.WriteLine();

                int choice = int.Parse(Console.ReadLine()) - 1;
                Console.Clear();

                if(choice > -1 &&choice < DataManager.Instance.inven.Count)  //인벤의 목록 내에서 선택 했다면
                {
                    IItem temp = DataManager.Instance.inven[choice];

                    if (!temp.isEquip)
                    {
                        int i = 0;
                        IItem tmp;
                        foreach(IItem item in DataManager.Instance.inven)
                        {
                            if (item.isEquip == true && temp.itemType == item.itemType)  // 인벤토리 내에 같은 타입의 아이템이 장착되어 있다면 장착 해제
                            {
                                tmp = DataManager.Instance.inven[i];
                                tmp.isEquip = false;
                                tmp.itemname = tmp.itemname.Replace("[E]", "");
                                DataManager.Instance.inven[i] = tmp;
                                break;
                            }
                            i++;
                        }

                        temp.itemname = "[E]" + temp.itemname;
                        temp.isEquip = true;
                        DataManager.Instance.inven[choice] = temp;
                    }
                    else
                    {
                        temp.itemname = temp.itemname.Replace("[E]","");
                        temp.isEquip = false;
                        DataManager.Instance.inven[choice] = temp;
                    }
                }
                else if(choice == -1)
                {
                    break;
                }
                else
                {
                    Console.Write("잘못된 입력입니다.");
                }
            }
        }
    }
}