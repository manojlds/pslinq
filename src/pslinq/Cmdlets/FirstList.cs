using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Internal;
using System.Reflection;

namespace pslinq.Cmdlets
{
    [Cmdlet("First", "List")]
    public class FirstList : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public ScriptBlock ScriptBlock { get; set; }

        protected override void ProcessRecord()
        {
            var output = ScriptBlock.InvokeWithContext(null, new List<PSVariable>
            {
                new PSVariable("input", Input),
            })[0];

            if (output.ToString() != "True") return;

            WriteObject(Input);

            Error.StopUpstreamCommandsException(this);
        }

        protected override void EndProcessing()
        {
            throw Error.NoMatch();
        }
    }
}