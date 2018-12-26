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

namespace Business.Implements
{
    public class LoaiHangHoaBusiness : ILoaiHangHoaBusiness
    {
        private QLWebDBEntities _dbContext;
        private readonly LoaiHangHoaReponsitory _loaiHangHoaRepo;

        public LoaiHangHoaBusiness()
        {
            _dbContext = new QLWebDBEntities();
            _loaiHangHoaRepo = new LoaiHangHoaReponsitory(_dbContext);
        }
    }
}
