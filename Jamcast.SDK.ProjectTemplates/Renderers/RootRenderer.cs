using System;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using Jamcast.Extensibility.ContentDirectory;

namespace $safeprojectname$.Renderers
{
    public class RootRenderer : RootContainerRenderer
    {                
        public override ObjectRenderInfo GetChildAt(int index)
        {
            throw new NotImplementedException();
        }

        public override int PrepareGetChildren(int startIndex, int count)
        {
            throw new NotImplementedException();
        }
    }
}