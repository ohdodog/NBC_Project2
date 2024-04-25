using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NBC_Project2
{
    internal class Character
    {
        public void StatusScene()  // 상태 보기
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");

                Console.WriteLine();

                DataManager.Instance.PrintStatus();

                Console.WriteLine();
                Console.WriteLine("0. 나가기");


                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 행동입니다.");
                }
            }
        }
    }
}
