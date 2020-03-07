using System;
namespace Cs.Functional.Basics.Helpers
{
    public static class MayBe
    {
        public static T GetOrElse<T>(this T? option, T defaultValue) where T : struct
        {
            return option ?? defaultValue;
        }

        public static T GetOrElse<T>(this T option, T defaultValue) where T : class
        {
            return option ?? defaultValue;
        }
    }
}
