using System.Collections.Generic;
using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("All", "List")]
    public class AllList : Cmdlet
    {
        private bool _output;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public ScriptBlock ScriptBlock { get; set; }

        protected override void BeginProcessing()
        {
            _output = true;
        }

        protected override void ProcessRecord()
        {
            if (!_output) return;

            var output = ScriptBlock.InvokeWithContext(null, new List<PSVariable>
            {
                new PSVariable("input", Input),
            })[0];
            
            if (output.ToString() == "True") return;
            
            _output = false;
            WriteObject(_output);
            Error.StopUpstreamCommandsException(this);
        }

        protected override void EndProcessing()
        {
            WriteObject(_output);
        }
    }
}