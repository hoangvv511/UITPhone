using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGenericReponsitory <Entities>
    {
        Task EditAscync(Entities entities);
        Task InsertAscync(Entities entities);
        Task DeleteAscync(Entities entities);
        
    }
}
