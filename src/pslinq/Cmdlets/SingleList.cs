using System.Collections.Generic;
using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("Single", "List")]
    public class SingleList : Cmdlet
    {
        private bool _matched;
        private object _output;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public ScriptBlock ScriptBlock { get; set; }

        protected override void BeginProcessing()
        {
            _matched = false;
        }

        protected override void ProcessRecord()
        {
            var output = ScriptBlock.InvokeWithContext(null, new List<PSVariable>
            {
                new PSVariable("input", Input),
            })[0];

            if (output.ToString() != "True") return;
            
            if (_matched) throw Error.MoreThanOneMatch();

            _matched = true;
            _output = Input;
        }

        protected override void EndProcessing()
        {
            if(!_matched) throw Error.NoMatch();

            WriteObject(_output);
        }
    }
}