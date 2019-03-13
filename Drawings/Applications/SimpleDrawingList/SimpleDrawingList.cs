using System;
using System.Windows.Forms;
// Classes to needed to access Tekla Structures drawings.
using Tekla.Structures.Drawing;

namespace SimpleDrawingList
{
    /// <summary>
    /// An example application to go through the drawings
    /// </summary>
    public partial class SimpleDrawingList : Form
    {
        public SimpleDrawingList()
        {
            InitializeComponent();
        }

        private DrawingHandler DrawingHandler = new DrawingHandler();

        /// <summary>
        /// Refresh drawing list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshDrawingList_click(object sender, EventArgs e)
        {
            // Check if we have connection to Tekla Structures drawings.
            if(!DrawingHandler.GetConnectionStatus())
                return;

            AddDrawingInformationToDrawingListTreeView();
        }

        /// <summary>
        /// Get all drawings and get the objects of the drawing
        /// </summary>
        private void AddDrawingInformationToDrawingListTreeView()
        {
            drawingListTreeView.Nodes.Clear();
            DrawingEnumerator drawingListEnumerator = DrawingHandler.GetDrawings(); // Get drawing list

            while(drawingListEnumerator.MoveNext())
            {
                Drawing myDrawing = drawingListEnumerator.Current;

                // Add drawing name to UI tree
                TreeNode drawingNode = new TreeNode();
                drawingNode.Tag = myDrawing;
                drawingNode.Text = myDrawing.GetType().ToString();

                // Checks if views should be added to tree (Checkbox in UI)
                if(ShowViews.Checked)
                    AddChildDrawingObjectsToTreeNode(drawingNode, myDrawing.GetSheet()); // Add all objects placed to the sheet to the UI tree

                drawingListTreeView.Nodes.Add(drawingNode);
            }
        }     

        /// <summary>
        /// Adds recursively all children of the given parent object to given node.
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentObject"></param>
        private void AddChildDrawingObjectsToTreeNode(TreeNode parentNode, Tekla.Structures.Drawing.IHasChildren parentObject)
        {
            DrawingObjectEnumerator objectEnumerator = parentObject.GetObjects(); // Gets the objects that are placed directly to the current container object
            objectEnumerator.SelectInstances = false; // We don't want to automatically select the instances, we just need to know if the object exists (we're not using objects properties at all)

            while(objectEnumerator.MoveNext()) 
            {
                // Checks if all child objects should be added to tree (Checkbox in UI) or current object is view.
                if(ShowObjectsInViews.Checked || objectEnumerator.Current is ViewBase)
                {
                    TreeNode objectNode = new TreeNode();

                    objectNode.Tag = objectEnumerator.Current;
                    objectNode.Text = objectEnumerator.Current.GetType().ToString();
                    
                    // Adds recursively children to the node tree.
                    if(objectEnumerator.Current is Tekla.Structures.Drawing.IHasChildren)
                        AddChildDrawingObjectsToTreeNode(objectNode, objectEnumerator.Current as IHasChildren);                    
                    
                    parentNode.Nodes.Add(objectNode);
                }
            }
        }

        /// <summary>
        /// Open currently selected drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDrawing_Click(object sender, EventArgs e)
        {
            if (!DrawingHandler.GetConnectionStatus())
                return;
            
            if(drawingListTreeView.SelectedNode != null && drawingListTreeView.SelectedNode.Tag != null && drawingListTreeView.SelectedNode.Tag is Drawing)            
                DrawingHandler.SetActiveDrawing(drawingListTreeView.SelectedNode.Tag as Drawing); // Opens selected drawing in editor window.
            else
                MessageBox.Show("Cannot open drawing. Selected object is not a drawing.");
        }
        
        /// <summary>
        /// Deletes selected object
        /// Deletes both drawings and drawing objects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteObject_Click(object sender, EventArgs e)
        {
            if (!DrawingHandler.GetConnectionStatus())
                return;

            if(drawingListTreeView.SelectedNode != null && drawingListTreeView.SelectedNode.Tag != null && drawingListTreeView.SelectedNode.Tag is DatabaseObject)
            {
                if((drawingListTreeView.SelectedNode.Tag as DatabaseObject).Delete())
                    drawingListTreeView.SelectedNode.Remove();
            }
        }

        /// <summary>
        /// Handle checkbox graying
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowViews_CheckedChanged(object sender, EventArgs e)
        {
            if(!(sender as System.Windows.Forms.CheckBox).Checked)
            {
                ShowObjectsInViews.Enabled = false;
                ShowObjectsInViews.Checked = false;
            }
            else
            {
                ShowObjectsInViews.Enabled = true;
            }
        }
    }
}