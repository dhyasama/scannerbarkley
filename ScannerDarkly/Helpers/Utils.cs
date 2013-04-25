using System;
using AppfailReporting;

namespace ScannerDarkly.Helpers
{
    public static class Utils
    {
        public static void LogException(Exception ex)
        {
            Appfail.SendToAppfail(ex);
        }
    }
}