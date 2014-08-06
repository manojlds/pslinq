using System.ComponentModel;
using System.Management.Automation;

namespace pslinq
{
    [RunInstaller(true)]
    public class PsLinq : PSSnapIn
    {
        public override string Name
        {
            get { return "pslinq"; }
        }

        public override string Vendor
        {
            get { return "StackToHeap"; }
        }

        public override string Description
        {
            get { return "LINQ for Powershell"; }
        }
    }
}
