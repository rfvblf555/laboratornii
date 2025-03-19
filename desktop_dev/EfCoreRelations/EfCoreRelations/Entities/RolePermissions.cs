using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreRelations.Entities;
public class RolePermissions
{
    public int Roleid { get; set; }
    public int Permissionid { get; set; }
    public Role Role { get; set; }
    public Permission Permission { get; set; }
}
