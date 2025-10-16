using System;

namespace BTTH1_Bai2
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

        static void Main(string[] args)
        {
            Console.Write("Nhap n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (Ngto(i)) sum += i;
            }
            Console.WriteLine("Tong cac so nguyen to nho hon " + n + " la " + sum);
        }
    }
}