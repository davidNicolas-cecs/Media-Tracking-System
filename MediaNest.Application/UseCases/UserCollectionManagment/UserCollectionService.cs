using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.UserCollectionManagment
{
    public class UserCollectionService : IUserCollectionService
    {
        // Implementation of the INterface UserCollectionService
        // DJ of the INterface UserCollectionRepository that is responsible with communicating with the DB 
        private readonly IUserCollectionRepository _collectionRepository;
        public UserCollectionService(IUserCollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<List<Domain.Model.UserMediaItems>> GetAllUserMediaItems(string userId)
        {
            return await _collectionRepository.GetAllUserMediaItems(userId);
        }

        public async Task AddToUserCollection(int mediaId, string userId)
        {
            await _collectionRepository.AddToUserCollection(mediaId, userId);
        }
    }
}
