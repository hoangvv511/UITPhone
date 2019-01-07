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
        private readonly BaoCaoPhieuChiReponsitory _baoCaoPhieuChiRepo;

        public BaoCaoPhieuChiBusiness()
        {
            dbContext = new QLWebDBEntities();
            _PhieuChiRepo = new PhieuChiReponsitory(dbContext);
            _baoCaoPhieuChiRepo = new BaoCaoPhieuChiReponsitory(dbContext);
        }
        public IList<BaoCaoPhieuChiViewModel> GetListBaoCao(DateTime dateFrom, DateTime dateTo)
        {
            
            IQueryable<BaoCaoPhieuChi> danhSachBaoCaoPhieuChi = _baoCaoPhieuChiRepo.GetAll();
            IQueryable<PhieuChi> danhSachPhieuChi = _PhieuChiRepo.GetAll();

            List<BaoCaoPhieuChiViewModel> allForManager = new List<BaoCaoPhieuChiViewModel>();

            if ((!(dateFrom == default(DateTime))) && (!(dateTo == default(DateTime))))
            {

                allForManager = (from phieuchi in danhSachPhieuChi                        
                                 where (phieuchi.NgayChi >= dateFrom.Date && phieuchi.NgayChi <= dateTo.Date)
                                 group phieuchi by phieuchi.NgayChi into pgroup
                                 select new
                                 {
                                        NgayChi = pgroup.Key,
                                     SoPhieuChi = pgroup.Count(),
                                     TongTien = pgroup.Sum(phieuchi => phieuchi.TongTienChi)

                                 }).AsEnumerable().Select(x => new BaoCaoPhieuChiViewModel()
                                 {
                                     ngayChi = x.NgayChi,
                                     soPhieuChi=x.SoPhieuChi,
                                     tongTien = x.TongTien

                                 }).OrderByDescending(x => x.tongTien).ToList();

            }

            return allForManager;



        }

    }
}
