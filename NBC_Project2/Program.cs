namespace NBC_Project2
{
    internal class Program
    {
        static Character player = new Character();
        static Inventory inventory = new Inventory();
        static Item item = new Item();
        static Shop shop = new Shop();
        static Dungeon dungeon = new Dungeon();
        static Rest rest = new Rest();

        static void Main(string[] args)
        {
            Login();
            item.InitItem();
            inventory.InitInvenFirst();

            while (true)
            {
                int choice;
                choice = StartScene();
                
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        player.StatusScene();
                        break;
                    case 2:
                        inventory.InventoryScene();
                        break;
                    case 3:
                        shop.ShopScene();
                        break;
                    case 4:
                        dungeon.DungeonScene();
                        break;
                    case 5:
                        rest.RestScene();
                        break;
                    default:
                        Console.WriteLine("잘못된 행동입니다.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        
        static void Login()  // 유저의 닉네임을 받아 플레이어 정보 초기화
        {
            Console.WriteLine("캐릭터를 생성합니다.");
            Console.Write("닉네임을 입력해주세요: ");
            string name = Console.ReadLine();
            Console.Clear();

            DataManager.Instance.InputStatus(1, name, 10, 5, 100, 1500);
        }

        static int StartScene()  // 메인 화면
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("스파르타 마을에 오신 여러분을 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();

                Console.WriteLine("1. 상태 보기"); ;
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                return choice;
            }
            
        }

    }
}
