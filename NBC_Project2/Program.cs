namespace NBC_Project2
{
    struct Status
    {
        public int level;
        public string nickname;
        public int attack;
        public int defense;
        public int hp;
        public int gold;

        public void ShowStatus()
        {
            Console.WriteLine("LV. " + level);
            Console.WriteLine(nickname);
            Console.WriteLine("공격력 : " + attack);
            Console.WriteLine("방어력 : " + defense);
            Console.WriteLine("체력 : " + hp);
            Console.WriteLine("Gold : " + gold + " G");
        }
    }

    internal class Program
    {
        static Status status;

        static void Main(string[] args)
        {
            Login();

            while (true)
            {
                int choice;
                choice = StartScene();

                Console.WriteLine(choice);
                switch (choice)
                {
                    case 1:
                        StatusScene();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }
        
        static void Login()
        {
            Console.WriteLine("캐릭터를 생성합니다.");
            Console.Write("닉네임을 입력해주세요: ");
            string name = Console.ReadLine();

            status.level = 1;
            status.nickname = name;
            status.attack = 10;
            status.defense = 5;
            status.hp = 100;
            status.gold = 1500;
        }

        static int StartScene()
        {
            Console.WriteLine();
            Console.WriteLine("스파르타 마을에 오신 여러분을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("1. 상태 보기"); ;
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            int choice = int.Parse(Console.ReadLine());

            return choice;
        }

        static void StatusScene()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            status.ShowStatus();

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int choice = int.Parse(Console.ReadLine());
                if(choice == 0)break;
                else
                {
                    Console.WriteLine("잘못된 행동입니다.") ;
                }
            }
        }
    }
}
