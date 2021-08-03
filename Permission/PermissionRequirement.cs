using System;
using Microsoft.AspNetCore.Authorization;

namespace testje_amk.Permission
{
    internal class PermissionRequirement:IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
