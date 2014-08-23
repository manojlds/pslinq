using System.Management.Automation;

namespace pslinq.MoreLinqCmdlets
{
    [Cmdlet("TakeEvery", "List")]
    public class TakeEveryList : Cmdlet
    {
        private int _noOfItemsProcessed;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public int Step { get; set; }

        protected override void BeginProcessing()
        {
            _noOfItemsProcessed = 0;
        }

        protected override void ProcessRecord()
        {
            _noOfItemsProcessed++;
            if (_noOfItemsProcessed < Step) return;

            WriteObject(Input);
            _noOfItemsProcessed = 0;
        }
    }
}