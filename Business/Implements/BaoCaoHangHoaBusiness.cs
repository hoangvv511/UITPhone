using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class BaoCaoHangHoaBusiness
    {
        private QLWebDBEntities _dbContext;

        public BaoCaoHangHoaBusiness()
        {
            _dbContext = new QLWebDBEntities();
        }

        //public object GetData(DateTime fromDate, DateTime toDate)
        //{
        //    var nhapDauKy = _dbContext.PhieuNhaps.Where(x => x.NgayNhap < fromDate).Select(x => x.ChiTietPhieuNhaps)
        //        .ToList();
            
        //    var xuatDauKy = _dbContext.PhieuXuatKhos
        //        .Where(x => x.NgayXuat < fromDate)
        //        .Select(x => x.)

    }
}
