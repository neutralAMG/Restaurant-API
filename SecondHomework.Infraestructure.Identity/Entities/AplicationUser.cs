using Microsoft.AspNetCore.Identity;


namespace SecondHomework.Infraestructure.Identity.Entities
{
	public class AplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
