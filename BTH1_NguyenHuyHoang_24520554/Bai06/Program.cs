using System;

namespace BTTH1_Bai6_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so dong n: ");
            int n = nhap();
            Console.Write("Nhap so cot m: ");
            int m = nhap();

            int[,] a = sinhmatran(n, m, 1, 99);

            int choice;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. In ma tran");
                Console.WriteLine("2. Tim phan tu lon nhat va nho nhat");
                Console.WriteLine("3. Tim dong co tong lon nhat");
                Console.WriteLine("4. Tinh tong cac phan tu khong phai so nguyen to");
                Console.WriteLine("5. Xoa mot dong theo chi so");
                Console.WriteLine("6. Xoa cot chua phan tu lon nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Ma tran hien tai:");
                        xuatmt(a, n, m);
                        break;

                    case 2:
                        Console.WriteLine("Phan tu lon nhat: " + findmax(a, n, m));
                        Console.WriteLine("Phan tu nho nhat: " + findmin(a, n, m));
                        break;

                    case 3:
                        Console.WriteLine("Dong co tong lon nhat: " + maxdong(a, n, m));
                        break;

                    case 4:
                        Console.WriteLine("Tong cac phan tu khong phai so nguyen to: " + tong(a, n, m));
                        break;

                    case 5:
                        Console.Write("Nhap chi so dong muon xoa: ");
                        int k = Convert.ToInt32(Console.ReadLine());
                        a = xoadong(a, ref n, m, k);
                        Console.WriteLine("Ma tran sau khi xoa dong " + k + ":");
                        xuatmt(a, n, m);
                        break;

                    case 6:
                        a = xoacotmax(a, ref m, n);
                        Console.WriteLine("Ma tran sau khi xoa cot chua phan tu lon nhat:");
                        xuatmt(a, n, m);
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (choice != 0);
        }
        
        //Hàm nhập
        static int nhap()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                Console.Write("Nhap lai (so nguyen duong): ");
            return n;
        }

        //hàm sinh ma trận ngau nhien
        static int[,] sinhmatran(int n, int m, int minVal, int maxVal)
        {
            Random rand = new Random();
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = rand.Next(minVal, maxVal + 1);
            return a;
        }

        //Hàm in ra ma trận
        static void xuatmt(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j].ToString().PadLeft(4));
                Console.WriteLine();
            }
        }

        //ham tim so lon nhat trong ma tran
        static int findmax(int[,] a, int n, int m)
        {
            int max = a[0, 0];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] > max)
                        max = a[i, j];
            return max;
        }

        //ham tim so nho nhat trong ma tran
        static int findmin(int[,] a, int n, int m)
        {
            int min = a[0, 0];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] < min)
                        min = a[i, j];
            return min;
        }

        //ham tim dong lon nhat trong ma tran
        static int maxdong(int[,] a, int n, int m)
        {
            int dong = 0, tongmax = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int tong = 0;
                for (int j = 0; j < m; j++)
                    tong += a[i, j];
                if (tong > tongmax)
                {
                    tongmax = tong;
                    dong = i;
                }
            }
            return dong;
        }

        //ham kiem tra xem phai so nguyen to khong
        static bool ngto(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        //ham tinh tong
        static int tong(int[,] a, int n, int m)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (!ngto(a[i, j]))
                        tong += a[i, j];
            return tong;
        }

        //ham xoa dong theo yeu cau
        static int[,] xoadong(int[,] a, ref int n, int m, int k)
        {
            if (k < 0 || k >= n)
            {
                Console.WriteLine("Chi so dong khong hop le!");
                return a;
            }

            int[,] b = new int[n - 1, m];
            int row = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                    b[row, j] = a[i, j];
                row++;
            }
            n--;
            return b;
        }

        //ham xoa cot lon nhat
        static int[,] xoacotmax(int[,] a, ref int m, int n)
        {
            int max = findmax(a, n, m);
            int cotxoa = -1;

            for (int i = 0; i < n && cotxoa == -1; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] == max)
                    {
                        cotxoa = j;
                        break;
                    }

            if (cotxoa == -1)
            {
                Console.WriteLine("Khong tim thay phan tu lon nhat de xoa cot.");
                return a;
            }

            int[,] b = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                int col = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == cotxoa) continue;
                    b[i, col++] = a[i, j];
                }
            }
            m--;
            return b;
        }
    }
}
