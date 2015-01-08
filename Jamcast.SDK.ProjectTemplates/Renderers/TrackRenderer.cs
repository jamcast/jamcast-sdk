using System;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using Jamcast.Extensibility.ContentDirectory;
using Jamcast.Extensibility.Metadata;

namespace $safeprojectname$.Renderers
{
    public class TrackRenderer : ObjectRenderer
    {
        public override ServerObject GetMetadata()
        {
            throw new NotImplementedException();
        }
    }
}