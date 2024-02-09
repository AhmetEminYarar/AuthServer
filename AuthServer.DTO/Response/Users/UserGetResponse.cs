namespace AuthServer.DTO.Response.Users
{
    public class UserGetResponse
    {
        public long id { get; set; }
        public string? userImageURL { get; set; }
        public string? tckn { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public int age { get; set; }
        public string? password { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public long roleId { get; set; }
    }
}
