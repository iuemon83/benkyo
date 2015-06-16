using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmCSharp
{
    /// <summary>
    /// アナグラム発見
    /// </summary>
    class Q4
    {
        public void Start(string filePath)
        {
            var wordList = File.ReadLines(filePath);
            var anagramGroupList = this.ComputeAnagramGroupList(wordList);

            foreach (var group in anagramGroupList)
            {
                Console.WriteLine(group.Key + "：" + "{" + string.Join(", ", group) + "}");
            }
        }

        /// <summary>
        /// 単語の一覧をアナグラム別にまとめます。
        /// </summary>
        /// <param name="wordList"></param>
        /// <returns></returns>
        private IGrouping<string, string>[] ComputeAnagramGroupList(IEnumerable<string> wordList)
        {
            return wordList
                .GroupBy(
                    word => new string(word.OrderBy(c => c).ToArray()),
                    word => word
                )
                .ToArray();
        }
    }
}
