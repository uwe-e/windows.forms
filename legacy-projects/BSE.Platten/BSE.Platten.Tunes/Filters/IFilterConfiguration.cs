using System;
using System.Collections.Generic;
using System.Text;

using BSE.Platten.BO;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Tunes.Filters
{
    public interface IFilterConfiguration
    {
        string FilterName { get;}
        FilterSettings.FilterMode FilterMode { get;}
        FilterConfiguration GetFilterConfiguration(BSE.Platten.BO.Environment environment);
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SafeFilterConfiguration(BSE.Platten.BO.Environment environment, bool bUsedFilter);
        void SetFilterValues(BSE.Platten.BO.Environment environment);
    }
}
