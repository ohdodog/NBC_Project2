using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC_Project2
{
    internal class Rest
    {
        public void RestScene()  // 휴식 씬
        {
            while(true)
            {
                Console.WriteLine("휴식하기");
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유골드 : {DataManager.Instance.status.gold})");
                Console.WriteLine();
                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if(choice == 1)
                {
                    if(DataManager.Instance.status.gold > 500)  //  보유 골드가 휴식비용보다 많은지 체크
                    {
                        DataManager.Instance.status.gold -= 500;
                        DataManager.Instance.status.hp = 100;
                        Console.Write("휴식 완료.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("잔액이 부족합니다.");
                        Console.WriteLine();
                    }
                }
                else if(choice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 행동입니다.");
                    Console.WriteLine();
                }
            }
        }
    }
}
