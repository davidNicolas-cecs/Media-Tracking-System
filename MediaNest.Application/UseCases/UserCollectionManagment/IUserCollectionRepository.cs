using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.UserCollectionManagment
{
    public interface IUserCollectionRepository
    {
        // Interface of UserCollection Repository
        // Get all user media items from user id

        Task <List<Domain.Model.UserMediaItems>> GetAllUserMediaItems(string userId);

        Task AddToUserCollection(int mediaId, string userId);

    }
}
