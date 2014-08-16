using System.Collections.Generic;
using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("Any", "List")]
    public class AnyList : Cmdlet
    {
        private bool _output;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public ScriptBlock ScriptBlock { get; set; }

        protected override void BeginProcessing()
        {
            _output = false;
        }

        protected override void ProcessRecord()
        {
            var output = ScriptBlock.InvokeWithContext(null, new List<PSVariable>
            {
                new PSVariable("input", Input),
            })[0];
            
            if (output.ToString() != "True") return;

            WriteObject(_output);
            throw Error.StopUpstreamCommandsException(this);
        }

        protected override void EndProcessing()
        {
            WriteObject(_output);
        }
    }
}