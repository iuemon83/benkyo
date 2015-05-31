using System;

namespace AlgorithmCSharp
{
    /// <summary>
    /// 数当てゲーム
    /// </summary>
    class Q3
    {
        private int count = 0;

        public void Start(int n)
        {
            var min = 1d;
            var max = (double)n;

            var km = new kazuateMachine((int)max);

            kazuateMachine.Response res = kazuateMachine.Response.Empty;
            while (res != kazuateMachine.Response.Right)
            {
                this.count++;

                var ceil = (int)(Math.Ceiling((max - min) / 2d) + min);

                res = km.IsAnswer(ceil);

                if (res == kazuateMachine.Response.Big)
                {
                    min = ceil + 1;
                }
                else if (res == kazuateMachine.Response.Small)
                {
                    max = ceil;
                }
            }

            Console.WriteLine("正解！");
            Console.WriteLine("試行回数：" + this.count);
        }

        /// <summary>
        /// 数当てマシーン
        /// １～ｎの中から数をひとつランダムに選択し、それを当てさせる。
        /// </summary>
        class kazuateMachine
        {
            public enum Response
            {
                Empty,
                Big,
                Small,
                Right
            }

            private readonly int answer;

            public kazuateMachine(int n)
            {
                this.answer = new Random().Next(1, n);
            }

            public Response IsAnswer(int x)
            {
                if (this.answer > x) return Response.Big;
                if (this.answer < x) return Response.Small;
                return Response.Right;
            }
        }
    }
}
