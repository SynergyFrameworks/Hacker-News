using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerService.DAL.Contract
{
    public interface IRepositoryManager
    {

        IHackerNewsRepository News { get; }
    
        Task SaveAsync();

    }
}
