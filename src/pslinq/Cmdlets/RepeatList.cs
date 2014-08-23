using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("Repeat", "List")]
    public class RepeatList : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public int Count { get; set; }

        protected override void ProcessRecord()
        {
            for (var i = 0; i < Count; i++)
            {
                WriteObject(Input);
            }
        }
    }
}