using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace _MvcResimEkleme.Ayar
{
    public class Dosya
    {
        public string resimYukle(HttpPostedFileBase resim)
        {        
            //1- uzantı kontrol
            string uzanti = Path.GetExtension(resim.FileName).ToLower();
            if(uzanti==".png" || uzanti == ".jpg")
            {
                if(resim.ContentLength>10000000)
                {
                    return "boyut";
                }
                else
                {
                    Image orjinalResim = Image.FromStream(resim.InputStream);
                    string resimAd = Guid.NewGuid().ToString() + uzanti;
                    Bitmap res = new Bitmap(orjinalResim);
                    res.Save(HttpContext.Current.Server.MapPath("/Content/Resim/Kullanici/" + resimAd));
                    return resimAd;

                }
            }
            else
            {
                //izin verilmeyen uzantılar ise;
                return "uzanti";
            }
        }

        public string resimYukle(HttpPostedFileBase resim, string yol)
        {
            //1- uzantı kontrol
            string uzanti = Path.GetExtension(resim.FileName).ToLower();
            if (uzanti == ".png" || uzanti == ".jpg")
            {
                if (resim.ContentLength > 10000000)
                {
                    return "boyut";
                }
                else
                {
                    Image orjinalResim = Image.FromStream(resim.InputStream);
                    string resimAd = Guid.NewGuid().ToString() + uzanti;
                    Bitmap res = new Bitmap(orjinalResim);
                    res.Save(HttpContext.Current.Server.MapPath(yol + resimAd));
                    return resimAd;

                }
            }
            else
            {
                //izin verilmeyen uzantılar ise;
                return "uzanti";
            }
        }
    }
}