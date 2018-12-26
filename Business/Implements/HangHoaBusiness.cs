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
    public class HangHoaBusiness : IHangHoaBusiness
    {
        private QLWebDBEntities _dbContext;
        private readonly HangHoaReponsitory _hangHoaRepo;

        public HangHoaBusiness()
        {
            _dbContext = new QLWebDBEntities();
            _hangHoaRepo = new HangHoaReponsitory(_dbContext);
        }
    }
}
