using AuthServer.Data.Entity;

namespace AuthServer.DTO.Response.Roles
{
    public class RoleGetAllResponse
    {
        public long id { get; set; }
        public string roleName { get; set; } = string.Empty;

        public List<RoleGetAllResponse> Map(List<Role> roles)
        {
            List<RoleGetAllResponse> response = new List<RoleGetAllResponse>();
            foreach (Role role in roles)
            {
                RoleGetAllResponse personGetAll = new RoleGetAllResponse()
                {
                    id = role.Id,
                    roleName = role.RoleName
                };
                response.Add(personGetAll);
            }
            return response;

        }
    }
}
