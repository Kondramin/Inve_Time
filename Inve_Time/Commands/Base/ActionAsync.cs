using System.Threading.Tasks;

namespace Inve_Time.Commands.Base
{
    /// <summary>Helpful delegate to async commadns</summary>
    internal delegate Task ActionAsync();

    /// <summary>Helpful delegate to async commadns</summary>
    /// <typeparam name="T">Dynamic type</typeparam>
    /// <param name="parameter">Dynamic type</param>
    internal delegate Task ActionAsync<in T>(T parameter);
}
