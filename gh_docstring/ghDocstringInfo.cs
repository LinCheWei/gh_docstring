using System;
using System.Drawing;
using Grasshopper;
using Grasshopper.Kernel;

namespace ghDocstring
{
    public class ghDocstringInfo : GH_AssemblyInfo
    {
        public override string Name => "gh_docstring";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("f45227d5-8691-476e-afc7-771803702892");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";

        //Return a string representing the version.  This returns the same version as the assembly.
        public override string AssemblyVersion => GetType().Assembly.GetName().Version.ToString();
    }
}