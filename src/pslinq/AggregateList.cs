using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace pslinq
{
    [Cmdlet("Aggregate", "List")]
    public class AggregateList : Cmdlet
    {
        private object _output;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }
        
        [Parameter(Position = 0, Mandatory = true)]
        public ScriptBlock ScriptBlock { get; set; }
        
        [Parameter(Position = 1, Mandatory = false)]
        public object Seed { get; set; }

        protected override void BeginProcessing()
        {
            _output = Seed;
        }

        protected override void ProcessRecord()
        {
            _output = ScriptBlock.InvokeWithContext(null, new List<PSVariable>
            {
                new PSVariable("input", Input),
                new PSVariable("acc", _output, ScopedItemOptions.AllScope)
            })[0];
        }

        protected override void EndProcessing()
        {
            WriteObject(_output);
        }
    }
}