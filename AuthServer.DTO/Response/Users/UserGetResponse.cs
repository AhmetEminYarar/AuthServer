using AuthServer.Data.Entity;

namespace AuthServer.DTO.Response.Users
{
    public class UserGetResponse
    {
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public long roleId { get; set; }
        public List<UserGetResponse> Map(List<User> users)
        {
            List<UserGetResponse> response = new List<UserGetResponse>();
            foreach (User user in users)
            {
                UserGetResponse personGetAll = new UserGetResponse()
                {
                    roleId = user.RoleId,
                    userName = user.UserName,
                    email = user.Email,
                    phoneNumber = user.PhoneNumber,

                };
                response.Add(personGetAll);
            }
            return response;

        }
    }
}
