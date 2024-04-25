using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC_Project2
{
    internal class Dungeon
    {

        public void DungeonScene()  //던전 씬
        {
            while (true)
            {
                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 쉬운 던전  | 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전  | 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전  | 방어력 17 이상 권장");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (DataManager.Instance.status.hp <= 0)  // hp가 0이면 던전에 입장불가
                {
                    if (choice == 0)
                    {
                        break;
                    }
                    else if((choice > -1 && choice < 4))
                    {
                        Console.WriteLine("던전에 입장할 체력이 충분하지 않습니다.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 행동입니다.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    if (choice > -1 && choice < 4)
                    {
                        if (choice == 0)
                        {
                            break;
                        }
                        else if (choice == 1)
                        {
                            EasyDungeon();
                        }
                        else if (choice == 2)
                        {
                            NormalDungeon();
                        }
                        else if (choice == 3)
                        {
                            HardDungeon();
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 행동입니다.");
                        Console.WriteLine();
                    }
                }   
            }
        }


        Random random = new Random();

        public void EasyDungeon()
        {
            int recommendDefense = 5;
            int reward = 1000;

            DungeonResult(recommendDefense,reward);            
        }
        public void NormalDungeon()
        {
            int recommendDefense = 11;
            int reward = 1700;

            DungeonResult(recommendDefense, reward);
        }
        public void HardDungeon()
        {
            int recommendDefense = 17;
            int reward = 2500;

            DungeonResult(recommendDefense, reward);
        }

        public void DungeonResult(int recommend, int reward)  // 던전 결과 계산
        {
            while (true)
            {
                int addition = Convert.ToInt32(recommend - DataManager.Instance.status.defense);
                int temp;
                int tmp;

                if (DataManager.Instance.status.defense < recommend)  // 던전 권장 방어력보다 플레이어의 방어력이 낮을 시
                {
                    int r = random.Next(1, 11);

                    if (r < 5)  // 40% 확률로 던전 실패
                    {
                        temp = DataManager.Instance.status.hp / 2;

                        Console.WriteLine("던전 실패!");
                        Console.WriteLine("아쉬워요.");
                        Console.WriteLine();

                        Console.WriteLine("[탐험 결과]");
                        Console.WriteLine();
                        Console.WriteLine($"체력 {DataManager.Instance.status.hp} -> {temp}");
                        DataManager.Instance.status.hp = temp;

                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                    }
                    else  // 던전 클리어
                    {
                        int addreward = random.Next(1, 3);
                        int decreaseHP = random.Next(20 + addition, 36 + addition);

                        Console.WriteLine("던전 클리어!");
                        Console.WriteLine("축하해요.");
                        Console.WriteLine();
                        Console.WriteLine("[탐험 결과]");
                        Console.WriteLine();

                        temp = DataManager.Instance.status.hp;
                        tmp = temp - decreaseHP;
                        if(tmp > 0)  
                        {
                            Console.WriteLine($"체력 {temp} -> {tmp}");
                            DataManager.Instance.status.hp = tmp;
                        }
                        else
                        {
                            Console.WriteLine($"체력 {temp} -> 0");
                            DataManager.Instance.status.hp = 0;
                        }

                        temp = DataManager.Instance.status.gold;
                        tmp = temp + reward + Convert.ToInt32(reward * ((DataManager.Instance.status.attack * (addreward)) * 0.01f));
                        Console.WriteLine($"골드 {temp} G-> {tmp} G");
                        DataManager.Instance.status.gold = tmp;
                        DataManager.Instance.LevelUp();

                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                    }
                }
                else  // 플레이어 방어력이 던전 권장 방어력보다 높으니 던전 클리어
                {
                    int addreward = random.Next(1, 3);
                    int decreaseHP = random.Next(20 + addition, 36 + addition);

                    Console.WriteLine("던전 클리어!");
                    Console.WriteLine("축하해요.");
                    Console.WriteLine();
                    Console.WriteLine("[탐험 결과]");
                    Console.WriteLine();

                    temp = DataManager.Instance.status.hp;
                    tmp = temp - decreaseHP;
                    if (tmp > 0)
                    {
                        Console.WriteLine($"체력 {temp} -> {tmp}");
                        DataManager.Instance.status.hp = tmp;
                    }
                    else
                    {
                        Console.WriteLine($"체력 {temp} -> 0");
                        DataManager.Instance.status.hp = 0;
                    }

                    temp = DataManager.Instance.status.gold;
                    tmp = temp + reward + Convert.ToInt32(reward * ((DataManager.Instance.status.attack * (addreward)) * 0.01f));
                    Console.WriteLine($"골드 {temp} G-> {tmp} G");
                    DataManager.Instance.status.gold = tmp;
                    DataManager.Instance.LevelUp();

                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                }

                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (choice == 0)
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
