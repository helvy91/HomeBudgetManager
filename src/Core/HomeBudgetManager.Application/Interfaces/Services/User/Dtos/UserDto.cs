using HomeBudgetManager.Application.Services.Base;
using System;

namespace HomeBudgetManager.Application.Interfaces.Services.User.Dtos
{
    public class UserDto : EntityDto<int>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public string CreatedAtFormatted
            => CreatedAt.ToString("dd-MM-yyyy hh:mm:ss");

        public string ModifiedAtFormatted
            => ModifiedAt.ToString("dd-MM-yyyy hh:mm:ss");
    }
}
