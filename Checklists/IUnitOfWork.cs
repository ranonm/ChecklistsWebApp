using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checklists
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}