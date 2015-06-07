using System;

namespace AlgorithmCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 魔法陣
            //new Q1.Zentansaku().Start();
            //new Q1.BackTrack().Start();

            // n クイーン問題
            //new Q2.Zentansaku().Start(4);
            //new Q2.BackTrack().Start(4);

            // トロミノパズル
            //new Q3().Start(2);

            // アナグラム発見
            new Q4().Start("Q4.txt");


            Console.ReadLine();
        }
    }
}
