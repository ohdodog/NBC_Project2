using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC_Project2
{
    internal class Shop
    {
        public void ShopScene()  // 상점 씬
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다. ");
                Console.WriteLine();

                Console.WriteLine("[보유 골드]");
                Console.WriteLine(DataManager.Instance.status.gold + "G");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                DataManager.Instance.PrintShopList();

                Console.WriteLine();

                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">>");

                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (choice == 1)
                {
                    BuyScene();
                }
                else if(choice == 2)
                {
                    SellScene();
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

        public void BuyScene()  // 구매페이지
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 구매합니다. ");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine(DataManager.Instance.status.gold + "G");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                DataManager.Instance.PrintShopList();
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("구매할 아이템을 선택해주세요");
                Console.Write(">>");

                int choice = int.Parse(Console.ReadLine()) - 1;
                Console.Clear();

                if (choice > -1 && choice <= DataManager.Instance.list.Count) // 상점 목록의 크기 내에서 숫자를 입력했다면
                {
                    IItem temp = DataManager.Instance.list[choice];

                    if (!temp.isBuy)  //아이템을 구매한적 이 있는지 체크
                    {
                        if(DataManager.Instance.status.gold >= temp.price)  //보유 골드가 가격보다 높은지 체크
                        {
                            temp.isBuy = true;
                            DataManager.Instance.list[choice] = temp;
                            DataManager.Instance.InputItemtoInven(temp);
                            DataManager.Instance.status.gold -= temp.price;
                        }
                        else
                        {
                            Console.Write("잔액이 부족합니다.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.Write("이미 구매한 아이템 입니다.");
                        Console.WriteLine();
                    }

                }
                else if (choice == -1)
                {
                    break;
                }
                else
                {
                    Console.Write("잘못된 입력입니다.");
                    Console.WriteLine();
                }
            }
        }
        public void SellScene()  // 판매페이지
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("아이템을 판매합니다. ");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine(DataManager.Instance.status.gold + "G");
                Console.WriteLine();

                Console.WriteLine("[보유 아이템 목록]");

                DataManager.Instance.PrintSellList();
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("판매할 아이템을 선택해주세요");
                Console.Write(">>");

                int choice = int.Parse(Console.ReadLine()) - 1;
                Console.Clear();

                if (choice > -1 && choice < DataManager.Instance.inven.Count)  // 인벤 목록의 크기 내에서 숫자를 입력했다면
                {
                    IItem temp = DataManager.Instance.inven[choice];

                    temp.isBuy = false;

                    if (temp.isEquip)  //장착중인 아이템을 판매한다면 장착해제
                    {
                        temp.isEquip = false;
                        temp.itemname = temp.itemname.Replace("[E]", "");
                    }

                    DataManager.Instance.status.gold += Convert.ToInt32(temp.price * 0.85f);  //판매 가격은 85%


                    // 데이터 형식이 객체로 구성된 List에서 특정값이 존재하는지 체크하는 람다식
                    // 해당 값이 있는 인덱스를 반환
                    // 인벤 리스트에서 판매 하려고 선택받은 아이템의 이름과 같은 데이터 값을 가진 인덱스를 가져오기 
                    int index = DataManager.Instance.list.FindIndex(item => item.itemname.Equals($"{temp.itemname}"));

                    DataManager.Instance.list[index] = temp;
                    DataManager.Instance.inven.RemoveAt(choice);


                }
                else if (choice == -1)  // 0 입력 시
                {
                    break;
                }
                else  // 나머지 숫자
                {
                    Console.Write("잘못된 입력입니다.");
                    Console.WriteLine();
                }
            }
        }
    }
}
