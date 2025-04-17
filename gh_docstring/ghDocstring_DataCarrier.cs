using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using GH_IO.Serialization;
using System.Text.Json;

namespace ghDocstring
{
    public class ghDocstring_DataCarrier : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public ghDocstring_DataCarrier()
          : base("Data Carrier", "dataCarrier",
            "Description",
            "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }



        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }

        public override bool Write(GH_IWriter writer)
        {
            var meta = writer.CreateChunk("PluginMetadata");
            meta.SetString("DocStringInfo", JsonSerializer.Serialize(ghDocstring_Data.metaData));
            return base.Write(writer);
        }

        public override bool Read(GH_IReader reader)
        {
            var meta = reader.FindChunk("PluginMetadata");
            if (meta != null)
            {
                Dictionary<string, string> data = JsonSerializer.Deserialize<Dictionary<string, string>>(meta.GetString("DocStringInfo"));
                ghDocstring_Data.metaData = data;
            }
            return base.Read(reader);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => null;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("a7eddb70-09c0-4e12-bb76-6e4b2b1d54c0");
    }
}