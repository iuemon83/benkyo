using System;
using System.Linq;

namespace AlgorithmCSharp
{
    /// <summary>
    /// 魔法陣
    /// </summary>
    class Q1
    {
        /// <summary>
        /// 全探索
        /// </summary>
        public class Zentansaku
        {
            private int count = 0;
            private int answer = 0;

            public void Start()
            {
                this.CreateJunretu(1, 9);
                Console.WriteLine("kotae:" + this.answer);
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
                if (!nokori.Any())
                {
                    if (this.IsValid(junretu))
                    {
                        this.answer++;
                        Console.WriteLine(string.Join(",", junretu));
                    }

                    return;
                }

                foreach (var x in nokori)
                {
                    CreateJunretu(nokori.Where(n => n != x).ToArray(), junretu.Concat(new[] { x }).ToArray());
                }
            }

            /// <summary>
            /// 魔法陣として正しい場合はTrue、そうでなければFalse
            /// </summary>
            /// <param name="junretu"></param>
            /// <returns></returns>
            private bool IsValid(int[] junretu)
            {
                var wa = junretu[0] + junretu[1] + junretu[2];

                // 各行、各列、対角線上の和が等しい(魔法陣として正しい)
                return junretu[3] + junretu[4] + junretu[5] == wa
                       && junretu[6] + junretu[7] + junretu[8] == wa
                        && junretu[0] + junretu[3] + junretu[6] == wa
                        && junretu[1] + junretu[4] + junretu[7] == wa
                        && junretu[2] + junretu[5] + junretu[8] == wa
                        && junretu[0] + junretu[4] + junretu[8] == wa
                        && junretu[2] + junretu[4] + junretu[6] == wa;
            }
        }

        /// <summary>
        /// バックトラック
        /// </summary>
        public class BackTrack
        {
            private int count = 0;
            private int answer = 0;

            public void Start()
            {
                this.CreateJunretu(1, 9);
                Console.WriteLine("kotae:" + this.answer);
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
                if (junretu.Length == 6)
                {
                    // 上から横2列
                    if (junretu[0] + junretu[1] + junretu[2]
                        != junretu[3] + junretu[4] + junretu[5])
                    {
                        return;
                    }
                }
                else if (junretu.Length == 7)
                {
                    // 左縦とななめ
                    var total = junretu[0] + junretu[1] + junretu[2];
                    if (total != junretu[0] + junretu[3] + junretu[6]
                        || total != junretu[2] + junretu[4] + junretu[6])
                    {
                        return;
                    }
                }
                else if (junretu.Length == 8)
                {
                    // 中央縦
                    if (junretu[0] + junretu[1] + junretu[2]
                        != junretu[1] + junretu[4] + junretu[7])
                    {
                        return;
                    }
                }
                else if (junretu.Length == 9)
                {
                    // 横3列目と右縦とななめ
                    var total = junretu[0] + junretu[1] + junretu[2];
                    if (total != junretu[6] + junretu[7] + junretu[8]
                        || total != junretu[2] + junretu[5] + junretu[8]
                        || total != junretu[0] + junretu[4] + junretu[8])
                    {
                        return;
                    }
                    else
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
        }
    }
}
