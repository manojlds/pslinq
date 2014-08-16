using System;
using System.Management.Automation;
using System.Management.Automation.Internal;
using System.Reflection;

namespace pslinq
{
    internal static class Error
    {
        private static readonly Type StopUpstreamCommandsExceptionType =
            Assembly.GetAssembly(typeof (PSCmdlet))
                .GetType("System.Management.Automation.StopUpstreamCommandsException");

        internal static InvalidOperationException NoMatch()
        {
            return new InvalidOperationException("No match found");
        }

        internal static Exception StopUpstreamCommandsException(Cmdlet cmdlet)
        {
            var stopUpstreamCommandsException = (Exception) Activator.CreateInstance(StopUpstreamCommandsExceptionType,
                BindingFlags.Default | BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.Public,
                null,
                new Object[] {(InternalCommand) cmdlet},
                null
                );
            throw stopUpstreamCommandsException;
        }
    }
}
