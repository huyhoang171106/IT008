using System;

namespace BTTH1_BT1
{
    class Program
    {
        static bool Ngto(int x)
        {
            if (x < 2) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;
            int l = (int)Math.Sqrt(x);
            for (int i = 3; i <= l; i += 2)
                if (x % i == 0) return false;
            return true;
        }

        static bool Socp(int x)
        {
            if (x < 0) return false;
            int r = (int)Math.Sqrt(x);
            return r * r == x;
        }

        static long Tongle(int[] arr)
        {
            long sum = 0;
            foreach (int v in arr)
                if (v % 2 != 0) sum += v;
            return sum;
        }

        static int Demngto(int[] arr)
        {
            int cnt = 0;
            foreach (int v in arr)
                if (Ngto(v)) cnt++;
            return cnt;
        }

        static int Socpnhonhat(int[] arr)
        {
            int min = -1;
            foreach (int v in arr)
            {
                if (Socp(v))
                {
                    if (min == -1 || v < min)
                        min = v;
                }
            }
            return min;
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0)
            {
                Console.WriteLine("Gia tri n khong hop le");
                return;
            }

            var random = new Random(); // phần này tham khảo từ LLM
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = random.Next(0, 101);

            Console.WriteLine("Mang sinh ngau nhien:");
            Console.WriteLine(string.Join(" ", arr));

            long tong = Tongle(arr);
            int countngto = Demngto(arr);
            int min = Socpnhonhat(arr);

            Console.WriteLine("Tong cac so le: " + tong);
            Console.WriteLine("So luong so nguyen to: " + countngto);
            Console.WriteLine("So chinh phuong nho nhat: " + min);
        }
    }
}
