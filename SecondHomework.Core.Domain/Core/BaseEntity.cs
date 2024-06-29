using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecondHomework.Core.Domain.Core
{
	public class BaseEntity<TID> 
	{
		public TID Id { get; set; }
	}

	public class BaseNameEntity<TID> : BaseEntity<TID> 
	{
		public string Name { get; set; }
	}
}
