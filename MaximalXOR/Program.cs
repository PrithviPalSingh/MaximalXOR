using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalXOR
{
    class Program
    {
        static void Main(String[] args)
        {
            //int res;
            //int _l;
            //_l = Convert.ToInt32(Console.ReadLine());

            //int _r;
            //_r = Convert.ToInt32(Console.ReadLine());

            //res = maxXor(_l, _r);
            //Console.WriteLine(res);
            #region -- HackerRank
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int m = Convert.ToInt32(Console.ReadLine());

            int[] queries = new int[m];
            for (int i = 0; i < m; i++)
            {
                int queriesItem = Convert.ToInt32(Console.ReadLine());
                queries[i] = queriesItem;
            }

            int[] result = maxXor(arr, queries);

            for (int i = 0; i < m; i++)
            {
                //result[i] = maxSubarrayXOR(arr, queries[i], n);
                Console.WriteLine(result[i]);
            }
            #endregion


            //int[] arr = { 8, 1, 2, 15, 10, 5 };
            //TrieNode head = new TrieNode();
            //for (int i = 0; i < 6; i++)
            //{
            //    Insert(arr[i], head);
            //}

            //Console.WriteLine(FindMaxXORPair(head, arr, 6));


            Console.Read();
        }

        static int[] maxXor(int[] arr, int[] queries)
        {
            TrieNode head = new TrieNode();
            for (int i = 0; i < arr.Length; i++)
            {
                Insert(arr[i], head);
            }

            return FindMaxXORPair(head, queries, queries.Length);
        }

        // A Trie Node 
        class TrieNode
        {
            public TrieNode left;
            public TrieNode right;         
        }
     
        static void Insert(int n, TrieNode head)
        {
            TrieNode curr = head;

            for (int i = 31; i >= 0; i--)
            {
                int b = (n >> i) & 1;
                if (b == 0)
                {
                    if (curr.left == null)
                    {
                        curr.left = new TrieNode();
                    }

                    curr = curr.left;
                }
                else
                {
                    if (curr.right == null)
                    {
                        curr.right = new TrieNode();
                    }

                    curr = curr.right;
                }
            }
        }

        static int[] FindMaxXORPair(TrieNode head, int[] arr, int n)
        {
            int[] a = new int[n];
            int max_xor = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int value = arr[i];
                TrieNode curr = head;
                int curr_xor = 0;
                for (int j = 31; j >= 0; j--)
                {
                    int b = (value >> j) & 1;

                    if (b == 0)
                    {
                        if (curr.right != null)
                        {
                            curr_xor += (int)Math.Pow(2, j);
                            curr = curr.right;
                        }
                        else
                        {
                            curr = curr.left;
                        }
                    }
                    else
                    {
                        if (curr.left != null)
                        {
                            curr_xor += (int)Math.Pow(2, j);
                            curr = curr.left;
                        }
                        else
                        {
                            curr = curr.right;
                        }
                    }
                }

                a[i] = curr_xor;
                if (curr_xor > max_xor) {
                    max_xor = curr_xor;
                }
            }

            return a;
        }
    }
}
