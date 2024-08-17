using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization_Code_Flow.Infrastructure.Identity
{
    public interface IKeyCloakClient
    {
        Task<IdpSettings> GetIdpSettings();
        Task<string> RegisterUserAsync(
        UserRepresentation user,
        CancellationToken cancellationToken = default);
    }
}
