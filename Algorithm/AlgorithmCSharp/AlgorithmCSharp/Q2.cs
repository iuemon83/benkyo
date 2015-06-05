using System;
using System.Linq;

namespace AlgorithmCSharp
{
    /// <summary>
    /// n クイーン問題
    /// </summary>
    class Q2
    {
        /// <summary>
        /// 全探索
        /// </summary>
        public class Zentansaku
        {
            private int count = 0;

            public void Start(int n)
            {
                // 生成した順列の配列の番号を行、値を列の番号とする
                var validPatternList = this.CreateJunretu(1, 9)
                    .Where(junretu => this.IsValid(junretu))
                    .ToArray();

                foreach (var validPattern in validPatternList)
                {
                    Console.WriteLine(string.Join(",", validPattern));
                }

                Console.WriteLine("パターン数:" + validPatternList.Length);
                Console.WriteLine("計算回数:" + this.count);
            }

            /// <summary>
            /// 指定した値の範囲内のすべてのパターンの順列を生成します。
            /// </summary>
            /// <param name="start"></param>
            /// <param name="last"></param>
            private int[][] CreateJunretu(int start, int last)
            {
                return this.CreateJunretu(Enumerable.Range(start, last - start + 1).ToArray(), new int[0]);
            }

            /// <summary>
            /// すべてのパターンの順列を生成します
            /// </summary>
            /// <param name="nokori"></param>
            /// <param name="junretu"></param>
            private int[][] CreateJunretu(int[] nokori, int[] junretu)
            {
                this.count++;
                if (!nokori.Any()) return new[] { junretu };

                return nokori.SelectMany(x =>
                {
                    var nn = nokori.Where(n => n != x).ToArray();
                    var jj = junretu.Concat(new[] { x }).ToArray();

                    return CreateJunretu(nn, jj);
                })
                .ToArray();
            }

            /// <summary>
            /// クイーンの位置が条件を満たしていればTrue、そうでなければFalse
            /// </summary>
            /// <param name="junretu"></param>
            /// <returns></returns>
            private bool IsValid(int[] junretu)
            {
                for (var i = 0; i < junretu.Length - 1; i++)
                {
                    for (var j = i + 1; j < junretu.Length; j++)
                    {
                        if (Math.Abs(i - j) == Math.Abs(junretu[i] - junretu[j])) return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// バックトラック
        /// </summary>
        public class BackTrack
        {
            private int count = 0;
            private int answer = 0;

            public void Start(int n)
            {
                // 生成した順列の配列の番号を行、値を列の番号とする
                this.CreateJunretu(1, n);
                Console.WriteLine("pata-nsuu:" + this.answer);
                Console.WriteLine("kaisuu:" + this.count);
            }

            /// <summary>
            /// 指定した値の範囲内のすべてのパターンの順列を生成します。
            /// </summary>
            /// <param name="start"></param>
            /// <param name="last"></param>
            private void CreateJunretu(int start, int last)
            {
                this.CreateJunretu(Enumerable.Range(start, last - start + 1).ToArray(), new int[0]);
            }

            /// <summary>
            /// すべてのパターンの順列を生成します
            /// </summary>
            /// <param name="nokori"></param>
            /// <param name="junretu"></param>
            private void CreateJunretu(int[] nokori, int[] junretu)
            {
                this.count++;
                if (junretu.Length >= 2)
                {
                    if (!this.IsValid(junretu)) return;

                    if (!nokori.Any())
                    {
                        this.answer++;
                        Console.WriteLine(string.Join(",", junretu));
                    }
                }

                foreach (var x in nokori)
                {
                    CreateJunretu(nokori.Where(n => n != x).ToArray(), junretu.Concat(new[] { x }).ToArray());
                }
            }

            /// <summary>
            /// クイーンの位置が条件を満たしていればTrue、そうでなければFalse
            /// </summary>
            /// <param name="junretu"></param>
            /// <returns></returns>
            private bool IsValid(int[] junretu)
            {
                for (var i = 0; i < junretu.Length - 1; i++)
                {
                    for (var j = i + 1; j < junretu.Length; j++)
                    {
                        if (Math.Abs(i - j) == Math.Abs(junretu[i] - junretu[j])) return false;
                    }
                }

                return true;
            }
        }
    }
}
