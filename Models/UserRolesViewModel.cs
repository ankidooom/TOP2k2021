using System;
using System.Collections.Generic;

namespace testje_amk.Models
{
    public class UserRolesViewModel
    {
        public string RoleName { get; set; }

        public bool Selected { get; set; }
    }

    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }

        public IList<UserRolesViewModel> UserRoles { get; set; }
    }
}
