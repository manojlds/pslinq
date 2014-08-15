using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("Skip", "List")]
    public class SkipList : Cmdlet
    {
        private int _noOfItemsSkipped;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public int Number { get; set; }

        protected override void BeginProcessing()
        {
            _noOfItemsSkipped = 0;
        }

        protected override void ProcessRecord()
        {
            _noOfItemsSkipped++;
            if (_noOfItemsSkipped <= Number) return;

            WriteObject(Input);
        }
    }
}