using System;

namespace BTTH1_Bai4
{
    class Program
    {
        static bool nhuan(int nam)
        {
            return (nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0);
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap thang va nam: ");
            string[] input = Console.ReadLine().Split(' ');
            int thang = Convert.ToInt32(input[0]);
            int nam = Convert.ToInt32(input[1]);
            int songay;
            
            switch (thang)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    songay = 31;
                    break;
                case 4: case 6: case 9: case 11:
                    songay = 30;
                    break;
                case 2:
                    songay = nhuan(nam) ? 29 : 28;
                    break;
                default:
                    Console.WriteLine("Thang khong hop le");
                    return;
            }

            Console.WriteLine("Thang " + thang + " nam " + nam + " co " + songay + " ngay");
        }
    }
}