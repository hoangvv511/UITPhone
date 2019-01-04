using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Common.Functions;
using Data.Functions;
using Data.Implements;
using System.Data.Entity.Core.Objects;
using Business.Interfaces;
using System.Web.Mvc;
using Common.ViewModels;
using PagedList;
using System.Web.WebPages.Html;

namespace Business.Implements
{
    public class BaoCaoTonKhoBusiness
    {
        QLWebDBEntities _dbContext;
        private readonly BaoCaoTonKhoReponsitory _baoCaoTonKhoRepo;

        public BaoCaoTonKhoBusiness()
        {
            _dbContext = new QLWebDBEntities();
            _baoCaoTonKhoRepo = new BaoCaoTonKhoReponsitory(_dbContext);
        }
    }
}
