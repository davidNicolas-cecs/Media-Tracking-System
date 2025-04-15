using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.UserCollectionManagment
{
    public interface IUserCollectionRepository
    {
        Task <List<Domain.Model.UserCollectionItems>> GetAllUserMediaItems(string userId);
    }
}
