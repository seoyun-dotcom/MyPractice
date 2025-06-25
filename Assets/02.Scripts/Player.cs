using System;


namespace PracticeTest
{
    public class Player
    {
        public string name = "";
        public int level = 1;

        public Player(string name, int level)
        {
            this.name = name;
            this.level = level;
            Console.WriteLine($"캐릭터: {name}, 레벨: {level} 생성완료");
           
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Game1", 1);

            Player player2 = new Player("Game2", 2);
        }    
    }
}