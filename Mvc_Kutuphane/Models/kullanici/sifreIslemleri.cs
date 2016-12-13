using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace Mvc_Kutuphane.Models
{
    public class sifreIslemleri
    {
        public static string convertMd5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //md5 nesnesi türettik.
            byte[] bsifre = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
            //texti(girilen parolayı) Encoding.UTF8 in GetBytes() methodu ile bir byte dizisine çevirdik.
            StringBuilder sb = new StringBuilder();
            // string builder sınıfından bir nesne türetip , byte dizimizdeki değerleri 
            // Append methodu yardımıyla bir string ifadeye çevirdik.
            foreach (var by in bsifre)
            {
                //x2 burda string'e çevirirken vermesini istediğimiz format.
                //çıktısında göreceğimiz gibi sayılar ve harflerden oluşucaktır.
                sb.Append(by.ToString("x2").ToLower());
            }
            //oluşturduğumuz string ifadeyi geri döndürdük.
            return sb.ToString();
        }

        public static bool EslestiMi(string girilen, string Sifreli)
        {
            //Sifreli daha önce sifrelemiş olduğumuz parola. Burda veritabanı kullanacak olursanız
            //Sifreli değeri veritabanından çekeceğiniz kullanıcı parolası olacak.
            string girileniSifrele = convertMd5(girilen);
            // Kullanıcının giriş yapmak için girdiği parolayı biraz önce yazdığımız method ile
            // Hash haline getirdik.
            StringComparer sc = StringComparer.OrdinalIgnoreCase;
            // StringComparer adından da anlaşıldığı gibi string karşılaştırması yapan bir sınıftır.
            // OrdinalIgnoreCase ile eşitse 0 değilse 1 döndürsün dedik .
            //sc.Compare() methodu ile iki ifadeyi karşılaştırdık. 
            if (0 == sc.Compare(girileniSifrele, Sifreli))
            { //ifadeler uyuşuyorsa burası
                return true;
            }
            else
            {//ifadeler uyuşmuyorsa burası
                return false;
            }
        }
    }
}