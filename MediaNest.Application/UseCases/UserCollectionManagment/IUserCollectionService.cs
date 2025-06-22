using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.UserCollectionManagment
{
    public interface IUserCollectionService
    {
        // Interface for implementation of UserCollection Service
        Task<List<Domain.Model.UserMediaItems>> GetAllUserMediaItems(string userId);

        Task AddToUserCollection(int mediaId, string userId);

    }
}
