

namespace SecondHomework.Core.Application.Core
{
	public class Result<TData>
	{
        public Result()
        {
			IsSucces = true;
        }
        public bool IsSucces {  get; set; }
		public string? Message { get; set; }
		public TData? Data { get; set; }
	}
}
