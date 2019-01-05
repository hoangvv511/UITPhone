using Common.Model;
using Common.ViewModels;
using Data.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class BaoCaoPhieuChiBusiness
    {
        QLWebDBEntities dbContext;
        private readonly PhieuChiReponsitory _PhieuChiRepo;

        public BaoCaoPhieuChiBusiness()
        {
            _PhieuChiRepo = new PhieuChiReponsitory(dbContext);
        }

        public List<BaoCaoPhieuChiViewModel> GetList(DateTime? date)
        {
            var phieuchi = _PhieuChiRepo.GetAll();
            if (date.HasValue) phieuchi = phieuchi.Where(t => t.NgayChi == date);
            var models = phieuchi.AsEnumerable().Select(x => new BaoCaoPhieuChiViewModel()
            {
                maBaoCaoPhieuChi = x.SoPhieuChi,
                ngayChi = x.NgayChi,
                tongTien = x.TongTienChi,
                ghiChu = x.GhiChu,
            }).OrderByDescending(x => x.maBaoCaoPhieuChi).ToList();
            return models;
        }
    }
}
