using System;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using Jamcast.Extensibility.ContentDirectory;
using Jamcast.Extensibility.Metadata;

namespace $rootnamespace$
{
    public class $safeitemrootname$ : ContainerRenderer
    {
        public override ObjectRenderInfo GetChildAt(int index)
        {
            throw new NotImplementedException();
        }

        public override int PrepareGetChildren(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public override ServerObject GetMetadata()
        {
            return new GenericContainer("$safeitemrootname$");
        }
    }
}