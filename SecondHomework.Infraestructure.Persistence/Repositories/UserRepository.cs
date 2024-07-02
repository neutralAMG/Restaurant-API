

using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;
using SecondHomework.Infraestructure.Persistence.Context;
using SecondHomework.Infraestructure.Persistence.Core;

namespace SecondHomework.Infraestructure.Persistence.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly SecondHomeworkContext _context;

		public UserRepository(SecondHomeworkContext context) : base(context)
		{
			_context = context;
		}
	}
}
