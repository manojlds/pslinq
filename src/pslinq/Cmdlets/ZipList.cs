using System.Collections.Generic;
using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("Zip", "List")]
    public class ZipList : Cmdlet
    {
        private IEnumerator<object> _secondEnumerator;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public IEnumerable<object> Second { get; set; }
        
        [Parameter(Position = 1, Mandatory = true)]
        public ScriptBlock ScriptBlock { get; set; }

        protected override void BeginProcessing()
        {
            _secondEnumerator = Second.GetEnumerator();
        }

        protected override void ProcessRecord()
        {
            if (!_secondEnumerator.MoveNext()) throw Error.StopUpstreamCommandsException(this);

            var output = ScriptBlock.InvokeWithContext(null, new List<PSVariable>
            {
                new PSVariable("first", Input),
                new PSVariable("second", _secondEnumerator.Current),
            })[0];

            WriteObject(output);
        }
    }
}
