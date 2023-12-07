using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Security
{
    public class AuthorizeAttribute : Attribute
    {

        public AuthorizeAttribute() { }

        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
        /// </summary>
        public string Roles { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the policy name that determines access to the resource.
        /// </summary>
        public string Policy { get; set; } = string.Empty;
    }
}
