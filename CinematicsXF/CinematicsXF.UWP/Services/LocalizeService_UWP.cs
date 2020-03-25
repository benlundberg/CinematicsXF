﻿using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CinematicsXF.UWP.Helpers
{
    public class LocalizeService_UWP : ILocalizeService
    {
        public string GetCurrentCountry()
        {
            var geographicRegion = new Windows.Globalization.GeographicRegion();
            var code = geographicRegion?.CodeTwoLetter;

            if (!string.IsNullOrEmpty(code))
            {
                return code;
            }
            else
            {
                return "US";
            }
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentCulture;
        }

        public void SetLocale()
        {
        }

        public IComparer<string> CreateStringComparer(CultureInfo cultureInfo = null)
        {
            StringComparer comparer;
            if (cultureInfo != null)
            {
                comparer = StringComparer.Create(cultureInfo, true);
            }
            else
            {
                comparer = StringComparer.CurrentCultureIgnoreCase;
            }
            return comparer;
        }
    }
}
