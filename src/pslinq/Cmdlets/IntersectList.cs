using System.Collections.Generic;
using System.Management.Automation;

namespace pslinq.Cmdlets
{
    [Cmdlet("Intersect", "List")]
    public class IntersectList : Cmdlet
    {
        private HashSet<object> _set;

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public object Input { get; set; }

        [Parameter(Position = 0, Mandatory = true)]
        public IEnumerable<object> Second { get; set; }

        protected override void BeginProcessing()
        {
            _set = new HashSet<object>();
        }

        protected override void ProcessRecord()
        {
            _set.Add(Input);
        }

        protected override void EndProcessing()
        {
            _set.IntersectWith(Second);

            foreach (var o in _set)
            {
                WriteObject(o);
            }

        }
    }
}