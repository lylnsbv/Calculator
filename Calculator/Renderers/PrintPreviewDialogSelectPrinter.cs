using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Renderers
{
    class PrintPreviewDialogSelectPrinter : PrintPreviewDialog
    {
        public PrintPreviewDialogSelectPrinter()

        {

            Shown += myPrintPreview_Shown;

        }
        private void myPrintPreview_Shown(object sender, System.EventArgs e)
        {
            // Get the toolstrip from the base control
            ToolStrip ts = (ToolStrip)this.Controls[1];
            // Get the print button from the toolstrip
            ToolStripItem printItem = ts.Items[0]; //("printToolStripButton");

            // Add a new button 
            {
                var withBlock = printItem;
                ToolStripItem myPrintItem;
                myPrintItem = ts.Items.Add(withBlock.Text, withBlock.Image, new EventHandler(MyPrintItemClicked));

                myPrintItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
                // Relocate the item to the beginning of the toolstrip
                ts.Items.Insert(0, myPrintItem);
            }

            // Remove the orginal button
            ts.Items.Remove(printItem);
        }
        private void MyPrintItemClicked(object sender, EventArgs e)
        {
            PrintDialog dlgPrint = new PrintDialog();
            try
            {
                {
                    var withBlock = dlgPrint;
                    withBlock.AllowSelection = true;
                    withBlock.ShowNetwork = true;
                    withBlock.Document = this.Document;
                }
                if (dlgPrint.ShowDialog() == DialogResult.OK)
                    this.Document.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error: " + ex.Message);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPreviewDialogSelectPrinter));
            this.SuspendLayout();
            // 
            // PrintPreviewDialogSelectPrinter
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "PrintPreviewDialogSelectPrinter";
            this.ResumeLayout(false);

        }
    }
}
