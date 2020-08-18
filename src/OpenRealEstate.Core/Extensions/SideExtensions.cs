using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenRealEstate.Core.Extensions
{
    public static class SideExtensions
    {
        public static Side Frontage(this IList<Side> sides)
        {
            if (sides is null)
            {
                throw new ArgumentNullException(nameof(sides));
            }

            return sides.FirstOrDefault(side => side.Name.Equals("frontage", StringComparison.OrdinalIgnoreCase));
        }

        public static Side Left(this IList<Side> sides)
        {
            if (sides is null)
            {
                throw new ArgumentNullException(nameof(sides));
            }

            return sides.FirstOrDefault(side => side.Name.Equals("left", StringComparison.OrdinalIgnoreCase));
        }

        public static Side Right(this IList<Side> sides)
        {
            if (sides is null)
            {
                throw new ArgumentNullException(nameof(sides));
            }

            return sides.FirstOrDefault(side => side.Name.Equals("Right", StringComparison.OrdinalIgnoreCase));
        }

        public static Side Rear(this IList<Side> sides)
        {
            if (sides is null)
            {
                throw new ArgumentNullException(nameof(sides));
            }

            return sides.FirstOrDefault(side => side.Name.Equals("rear", StringComparison.OrdinalIgnoreCase));
        }
    }
}
