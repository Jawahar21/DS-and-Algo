using System.Collections.Generic;

namespace problems
{
    public static class PowerSet
    {
        public static List<List<int>> GetPowerSet(int[] nums) {
            List<List<int>> powerSet = new List<List<int>>();
            powerSet.Add(new List<int>());
            foreach (int num in nums) {
                int size = powerSet.Count;
                for (int i = 0; i < size; i++) {
                    List<int> subSet = new List<int>(powerSet[i]);
                    subSet.Add(num);
                    powerSet.Add(subSet);
                }
            }
            return powerSet;
        }
    }
}
