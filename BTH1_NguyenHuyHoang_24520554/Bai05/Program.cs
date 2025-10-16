using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1_Bai5
{
    class Program
    {
        static bool nhuan(int nam)
        {
            return (nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0);
        }

        static bool hople(int ngay, int thang, int nam)
        {
            if (nam < 1 || thang < 1 || thang > 12 || ngay < 1) return false;
            int[] songay = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (nhuan(nam)) songay[1] = 29;
            if (ngay > songay[thang - 1]) return false;
            return true;
        }

        static void Main()
        {
            Console.Write("Nhap ngay thang nam: ");
            string[] date = Console.ReadLine().Split(' ');
            int ngay = Convert.ToInt32(date[0]);
            int thang = Convert.ToInt32(date[1]);
            int nam = Convert.ToInt32(date[2]);

            if (hople(ngay, thang, nam))
            {
                DateTime thu = new DateTime(nam,thang,ngay);            
                Console.WriteLine(thu.DayOfWeek);
            }
            else
                Console.WriteLine("Ngay thang nam khong hop le");
        }
    }
}