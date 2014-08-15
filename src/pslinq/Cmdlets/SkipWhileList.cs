using System.Collections.Generic;
using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("SkipWhile", "List")]
    public class SkipWhileList : Cmdlet
    {
        private bool _skipped;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public ScriptBlock ScriptBlock { get; set; }

        protected override void BeginProcessing()
        {
            _skipped = false;
        }

        protected override void ProcessRecord()
        {
            if (!_skipped)
            {
                var output = ScriptBlock.InvokeWithContext(null, new List<PSVariable>
                {
                    new PSVariable("input", Input),
                })[0];

                if (output.ToString() == "True") return;
                
                _skipped = true;
            }

            WriteObject(Input);
        }
    }
}