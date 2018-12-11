using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Data.Interfaces;
using Business.Interfaces;
using Data.Implements;

namespace Business.Implements
{
    public class NhanVienBusiness : INhanVienBusiness
    {
        private QLWebDBEntities _dbContext;
        private readonly ChucVuReponsitory _chucVuRepo;
        private readonly NhanVienReponsitory _nhanVienRepo;
        private readonly NhanVien_QuyenReponsitory _nhanVienQuyenRepo;

        public NhanVienBusiness()
        {
            _dbContext = new QLWebDBEntities();
            _chucVuRepo = new ChucVuReponsitory(_dbContext);
            _nhanVienRepo = new NhanVienReponsitory(_dbContext);
            _nhanVienQuyenRepo = new NhanVien_QuyenReponsitory(_dbContext);
        }

        

    }
}
