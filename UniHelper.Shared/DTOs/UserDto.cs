using System;

namespace UniHelper.Shared.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Registration { get; set; }
        public DateTime LastLogin { get; set; }
    }
}