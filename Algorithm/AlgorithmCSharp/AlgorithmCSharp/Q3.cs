using System;

namespace AlgorithmCSharp
{
    /// <summary>
    /// トロミノパズル
    /// </summary>
    class Q3
    {
        private int trominoCount = 0;

        // マスの状態(0: 何もない、-1: 欠けているマス、それ以外: トロミノ。同じ数字のマスが一つのトロミノを表す) [x][y]
        private int[][] masuList;

        public void Start(int n)
        {
            var nn = (int)Math.Pow(2, n);

            this.masuList = new int[nn][];
            for (var i = 0; i < nn; i++)
            {
                this.masuList[i] = new int[nn];
            }

            // ランダムに壊れているマスを作成する
            var ran = new Random();
            var breakX = ran.Next(0, nn - 1);
            var breakY = ran.Next(0, nn - 1);
            this.masuList[breakX][breakY] = -1;

            this.SetTromino(0, nn - 1, 0, nn - 1);
            foreach (var row in this.masuList)
            {
                foreach (var masu in row)
                {
                    Console.Write(masu);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// すべてのマスが埋まるまで、再帰的にトロミノをセットします。
        /// </summary>
        /// <param name="startX">セットするxの範囲の最小値</param>
        /// <param name="endX">セットするxの範囲の最大値</param>
        /// <param name="startY">セットするyの範囲の最小値</param>
        /// <param name="endY">セットするyの範囲の最大値</param>
        private void SetTromino(int startX, int endX, int startY, int endY)
        {
            this.trominoCount++;

            var length = endY - startY + 1;
            var half = length / 2;

            // 中心4マス
            var centerLX = startX + half - 1;
            var centerRX = startX + half;
            var centerTY = startY + half - 1;
            var centerBY = startY + half;

            // すでに埋まっているマス
            int breakX = 0;
            int breakY = 0;
            for (var i = startX; i <= endX; i++)
            {
                for (var j = startY; j <= endY; j++)
                {
                    if (this.masuList[i][j] != 0)
                    {
                        breakX = i;
                        breakY = j;
                        break;
                    }
                }
            }

            // トロミノをセットするマス(3マス)
            if (((centerLX < breakX) || (centerTY < breakY))
                && this.masuList[centerLX][centerTY] == 0)
            {
                this.masuList[centerLX][centerTY] = this.trominoCount;
            }

            if (((centerLX < breakX) || (centerBY > breakY))
                && this.masuList[centerLX][centerBY] == 0)
            {
                this.masuList[centerLX][centerBY] = this.trominoCount;
            }

            if (((centerRX > breakX) || (centerTY < breakY))
                && this.masuList[centerRX][centerTY] == 0)
            {
                this.masuList[centerRX][centerTY] = this.trominoCount;
            }

            if (((centerRX > breakX) || (centerBY > breakY))
                && this.masuList[centerRX][centerBY] == 0)
            {
                this.masuList[centerRX][centerBY] = this.trominoCount;
            }

            if (length == 2) return;

            // 4分割して再帰
            this.SetTromino(startX, startX + half - 1, startY, startY + half - 1);
            this.SetTromino(startX, startX + half - 1, startY + half, endY);
            this.SetTromino(startX + half, endX, startY, startY + half - 1);
            this.SetTromino(startX + half, endX, startY + half, endY);
        }
    }
}
