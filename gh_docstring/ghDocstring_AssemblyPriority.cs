using Grasshopper;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DocStringWindowLibrary;

namespace ghDocstring
{
    public class ghDOC_AssemblyPriority : GH_AssemblyPriority
    {
        private ToolStripMenuItem toolStripMenuItem; // New ToolStripMenuItem to be added to the menu
        private bool isSubMenuAdded = false; // A flag to track if the sub-menu items are already added
        public override GH_LoadingInstruction PriorityLoad()
        {
            Instances.CanvasCreated += new Instances.CanvasCreatedEventHandler(this.RegisterNewMenuItems);
            return (GH_LoadingInstruction)0;
        }

        private void RegisterNewMenuItems(GH_Canvas canvas)
        {
            Instances.CanvasCreated -= new Instances.CanvasCreatedEventHandler(this.RegisterNewMenuItems);
            GH_DocumentEditor documentEditor = Instances.DocumentEditor;
            if (documentEditor == null)
                return;
            this.SetupMenu(documentEditor);
        }

        private void SetupMenu(GH_DocumentEditor docEditor)
        {
            toolStripMenuItem = new ToolStripMenuItem("ghDOC");
            toolStripMenuItem.Name = "ghDOC";
            toolStripMenuItem.DropDownOpening += ghDOCMenuItem_DropDownOpening;
            ((Form)docEditor).MainMenuStrip.SuspendLayout();
            ((Form)docEditor).MainMenuStrip.Items.Add(toolStripMenuItem);
            ((Form)docEditor).MainMenuStrip.ResumeLayout(false);
            ((Form)docEditor).MainMenuStrip.PerformLayout();
        }

        private void ghDOCMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (!isSubMenuAdded)
            {
                ToolStripMenuItem subMenuItem1 = new ToolStripMenuItem("OpenViewer");
                subMenuItem1.Click += OpenViewer_Click;
                toolStripMenuItem.DropDownItems.Add(subMenuItem1);

                ToolStripMenuItem subMenuItem2 = new ToolStripMenuItem("Clear");
                subMenuItem2.Click += Clear_Click;
                toolStripMenuItem.DropDownItems.Add(subMenuItem2);

                isSubMenuAdded = true;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            // Handle the click event of the sub-menu item here
            // For example:
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            ghDocstring_Data.metaData.Clear();
        }

        private void OpenViewer_Click(object sender, EventArgs e)
        {
            GH_Document doc = Instances.ActiveCanvas.Document;

            // Check if datacarrier already exists
            bool exists = doc.Objects.OfType<IGH_Component>()
                .Any(comp => comp.GetType() == typeof(ghDocstring_DataCarrier));

            if (!exists)
            {
                ghDocstring_DataCarrier dataCarrier = new ghDocstring_DataCarrier();
                dataCarrier.Attributes.Pivot = new PointF(100, 100);
                dataCarrier.Hidden = true;

                doc.AddObject(dataCarrier, true);
            }

            if (doc.SelectedObjects().Count == 1)
            {
                var obj = doc.SelectedObjects().First();
                Guid guid = obj.InstanceGuid;
                RemarkWindow remarkWindow = new RemarkWindow(ghDocstring_Data.metaData, true);
                remarkWindow.ShowDialog();
                ghDocstring_Data.userInput = remarkWindow.InputRemark;
                if (!string.IsNullOrEmpty(ghDocstring_Data.userInput))
                {
                    ghDocstring_Data.metaData[guid.ToString()] = ghDocstring_Data.userInput;
                }
            }
            else
            {
                RemarkWindow remarkWindow = new RemarkWindow(ghDocstring_Data.metaData, false);
                remarkWindow.ShowDialog();
            }
        }
    }
}
