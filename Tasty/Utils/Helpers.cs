using System;
using System.Collections.Generic;
using System.Linq;
using Tasty.Interfaces;

namespace Tasty.Utils
{
    public static class Helpers
    {
        public static int GenerateId<T>(List<T> list) where T: IEntity => list.Any() ? list.Max(x => x.Id) + 1 : 1;
    }
}
