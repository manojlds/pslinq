using System;

namespace pslinq
{
    internal static class Error
    {
        internal static Exception NoMatch()
        {
            return (Exception) new InvalidOperationException("No match found");
        }
    }
}