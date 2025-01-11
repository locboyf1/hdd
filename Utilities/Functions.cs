using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Company.Utilities
{
    public class Functions
    {

        public static int _MaNV = 0;

        public static string _HotenNV = string.Empty;

        public static string _Email = string.Empty;

        public static string _Message = string.Empty;

        //Khach hang
        public static int _MaDG = 0;
        public static string _DGHoTen = string.Empty;
        public static string _DGEmail = string.Empty;

        public static string TitleSlugGeneration(string type, string? title, long id)
        {
            return type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuider = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
                strBuider.Append(result[i].ToString("x2"));
            return strBuider.ToString();
        }

        public static string MD5Matkhau(string text)
        {
            string str = MD5Hash(text);
            for (int i = 0; i <= 5; i++)
                str = MD5Hash(str + str);
            return str;
        }

        public static bool IsDangnhap()
        {
            if((Functions._MaNV <= 0) || string.IsNullOrEmpty(Functions._HotenNV) || string.IsNullOrEmpty(Functions._Email))
                return false;
            return true;
        }

        public static bool DGIsDangnhap()
        {
            if((Functions._MaDG <= 0) || string.IsNullOrEmpty(Functions._DGHoTen) || string.IsNullOrEmpty(Functions._DGEmail))
                return false;
            return true;
        }
    }
}