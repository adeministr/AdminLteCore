using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naitzel.Intranet.Domain.AdminLte.Extension
{
    public static class EnumerableExtension
    {
        public static async Task<IEnumerable<TSource>> AsEnumerableAsync<TSource>(this Task<List<TSource>> source)
        {
            return (await source).AsEnumerable();
        }
    }
}