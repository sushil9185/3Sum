namespace _3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public IList<IList<int>> ThreeSumBrute(int[] nums)
        {
            int n = nums.Length;
            List<IList<int>> result = new List<IList<int>>();
            HashSet<string> seenTriplets = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            int[] triplet = new int[] { nums[i], nums[j], nums[k] };
                            Array.Sort(triplet);
                            string tripletKey = $"{triplet[0]},{triplet[1]},{triplet[2]}";
                            if (!seenTriplets.Contains(tripletKey))
                            {
                                seenTriplets.Add(tripletKey);
                                result.Add(new List<int>(triplet));
                            }
                        }
                    }
                }
            }


            return result;
        }

        public IList<IList<int>> ThreeSumBetter(int[] nums)
        {
            int n = nums.Length;
            List<IList<int>> result = new List<IList<int>>();
            HashSet<string> seenTriplets = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var hashSet = new HashSet<int>();

                for (int j = i + 1; j < n; j++)
                {
                    int third = -(nums[i] + nums[j]);
                    if (hashSet.Contains(third))
                    {
                        int[] triplet = new int[] { nums[i], nums[j], third };
                        Array.Sort(triplet);
                        string tripletKey = $"{triplet[0]},{triplet[1]},{triplet[2]}";
                        if (!seenTriplets.Contains(tripletKey))
                        {
                            seenTriplets.Add(tripletKey);
                            result.Add(new List<int>(triplet));
                        }
                    }
                    hashSet.Add(nums[j]);
                }
            }
            return result;
        }

        public IList<IList<int>> ThreeSumOptimal(int[] nums)
        {
            int n = nums.Length;
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                int j = i + 1;
                int k = n - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum < 0)
                    {
                        j++;
                    }
                    else if (sum > 0)
                    {
                        k--;
                    }
                    else
                    {
                        int[] temp = new int[] { nums[i], nums[j], nums[k] };
                        result.Add(temp);
                        j++;
                        k--;
                        while (j < k && nums[j] == nums[j - 1])
                        {
                            j++;
                        }
                        while (j < k && nums[k] == nums[k + 1])
                        {
                            k--;
                        }
                    }

                }
            }
            return result;
        }
    }
}
