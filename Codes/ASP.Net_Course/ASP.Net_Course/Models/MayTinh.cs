using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Course.Models
{
    public class MayTinh
    {
        public string maMay { get; set; }
        public string dongMay { get; set; }
        public double giaBan { get; set; }
        public DateTime ngaySX { get; set; }
        public string hangSX { get; set; }

        public List<MayTinh> khoiTao5May()
        {
            List<MayTinh> dsMayTinh = new List<MayTinh>();
            dsMayTinh.Add(new MayTinh()
            {
                maMay = "1234567890",
                dongMay = "Asus 5515",
                giaBan = 7000000,
                ngaySX = new DateTime(2020, 4, 1),
                hangSX = "Asus"
            });

            dsMayTinh.Add(new MayTinh()
            {
                maMay = "1234567891",
                dongMay = "Asus 5513",
                giaBan = 8000000,
                ngaySX = new DateTime(2020, 4, 6),
                hangSX = "Asus"
            });

            dsMayTinh.Add(new MayTinh()
            {
                maMay = "1234567892",
                dongMay = "Asus 5515",
                giaBan = 7000000,
                ngaySX = new DateTime(2020, 4, 1),
                hangSX = "Asus"
            });

            dsMayTinh.Add(new MayTinh()
            {
                maMay = "1234567893",
                dongMay = "Asus 5515",
                giaBan = 7000000,
                ngaySX = new DateTime(2020, 4, 1),
                hangSX = "Asus"
            });

            dsMayTinh.Add(new MayTinh()
            {
                maMay = "1234567894",
                dongMay = "Asus 5515",
                giaBan = 7000000,
                ngaySX = new DateTime(2020, 4, 1),
                hangSX = "Asus"
            });

            dsMayTinh.Add(new MayTinh()
            {
                maMay = "1234567895",
                dongMay = "Asus 5515",
                giaBan = 7000000,
                ngaySX = new DateTime(2020, 4, 1),
                hangSX = "Asus"
            });
            
            return dsMayTinh;
        }
    }
}