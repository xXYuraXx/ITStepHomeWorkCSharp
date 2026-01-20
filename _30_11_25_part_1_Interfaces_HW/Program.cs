namespace _30_11_25_part_1_Interfaces_HW
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }
    interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }

    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }

    class Array : IOutput, IMath, ISort
    {
        int[] arr;

        public Array()
        {
            arr = new int[0];
        }

        public float Avg()
        {
            if (arr.Length == 0) throw new Exception("Arr is empty");

            float sum = 0f;
            foreach (var el in arr)
            {
                sum += el;
            }
            return sum / arr.Length;
        }

        public int Max()
        {
            if (arr.Length == 0) throw new Exception("Arr is empty");

            int max = arr[0];
            foreach (var el in arr)
            {
                max = Math.Max(max, el);
            }
            return max;
        }

        public int Min()
        {
            if (arr.Length == 0) throw new Exception("Arr is empty");

            int min = arr[0];
            foreach (var el in arr)
            {
                min = Math.Min(min, el);
            }
            return min;
        }

        public bool Search(int valueToSearch)
        {
            bool isFounded = false;
            foreach (var el in arr)
            {
                if (el == valueToSearch)
                {
                    isFounded = true;
                }
            }
            return isFounded;
        }

        public void Show()
        {
            Console.WriteLine(this.ToString());
        }

        public void Show(string info)
        {
            Console.WriteLine($"{info} - {this.ToString()}");
        }

        public void Test()
        {
            SetByArr(new int[] { 1, 2, 11, 4, 5, 3 });
            Show();
            Show("My info");

            Console.WriteLine($"Max {this.Max()}");
            Console.WriteLine($"Min {this.Min()}");
            Console.WriteLine($"Avg {this.Avg()}");
            Console.WriteLine($"Search 2 {this.Search(2)}");
            Console.WriteLine($"Search 7 {this.Search(7)}");

            SortAsc();
            Show("Asc");
            SortDesc();
            Show("Desc");
            SortByParam(true);
            Show("By param (true)");

        }

        public void SetByArr(int[] arr)
        {
            this.arr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                this.arr[i] = arr[i];
            }
        }

        public override string ToString()
        {
            return string.Join(" ", arr);
        }

        public void SortAsc()
        {
            arr.Sort();
        }

        public void SortDesc()
        {
            arr.Sort((a, b) => b.CompareTo(a));
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc) SortAsc();
            else SortDesc();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Array arr = new Array();
            arr.Test();
        }
    }
}
