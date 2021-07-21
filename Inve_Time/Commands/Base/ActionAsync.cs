using System.Threading.Tasks;

namespace Inve_Time.Commands.Base
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<in T>(T parameter);
}
