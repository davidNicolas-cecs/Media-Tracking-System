using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.UserCollectionManagment
{
    public class UserCollectionService : IUserCollectionService
    {
        private readonly IUserCollectionRepository _collectionRepository;
        public UserCollectionService(IUserCollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<List<Domain.Model.UserMediaItems>> GetAllUserMediaItems(string userId)
        {
            return await _collectionRepository.GetAllUserMediaItems(userId);
        }
    }
}
