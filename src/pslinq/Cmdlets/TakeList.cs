using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("Take", "List")]
    public class TakeList : Cmdlet
    {
        private int _noOfItemsProcessed;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public int Number { get; set; }

        protected override void BeginProcessing()
        {
            _noOfItemsProcessed = 0;
        }

        protected override void ProcessRecord()
        {
            WriteObject(Input);
            
            _noOfItemsProcessed++;
            if (_noOfItemsProcessed == Number) throw Error.StopUpstreamCommandsException(this);
        }
    }
}