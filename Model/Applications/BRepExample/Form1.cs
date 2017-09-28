using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Tekla.Structures.Catalogs;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace BRepExample
{
    public partial class Form1 : Form
    {
        const string ShapeName = "SimpleBoxShape";
        double Length { get; set; }

        public Form1()
        {
            InitializeComponent();
            Length = 500.0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // remove possibly pre-existing shape called ShapeName and then insert a cube
            // with that name into the catalog
            if(this.shapeSize != null && !string.IsNullOrEmpty(this.shapeSize.Text))
                Length = double.Parse(this.shapeSize.Text);

            var polymesh = CreateBrepCube(Length);

            var shapeItem = new ShapeItem
            {
                Name = ShapeName,
                ShapeFacetedBrep = polymesh,
                UpAxis = ShapeUpAxis.Z_Axis
            };

            shapeItem.Delete();

            var result = shapeItem.Insert();
            this.button3.Enabled = true;
            this.button4.Enabled = true;

            this.shapeTypeBox.Text = "Cube";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cubeBRep = CreateBrepCube(500.0);

            var invalidInfo = new List<KeyValuePair<int, Polymesh.PolymeshHealthCheckEnum>>();
            var result = Polymesh.Validate(cubeBRep, Polymesh.PolymeshCheckerFlags.All, ref invalidInfo);

            if (result)
            {
                this.validateResult.Text = "The cube has valid geometry";
            }
            else
            {
                this.validateResult.Text = "The cube has invalid geometry";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.shapeSize != null && !string.IsNullOrEmpty(this.shapeSize.Text))
                Length = double.Parse(this.shapeSize.Text);

            var pyramidBrep = CreateBrepPyramid(Length);

            var modifyShapeItem = new ShapeItem
            {
                Name = ShapeName,
                ShapeFacetedBrep = pyramidBrep,
                UpAxis = ShapeUpAxis.Z_Axis
            };

            var resultOfModify = modifyShapeItem.Modify();
            this.shapeTypeBox.Text = "Pyramid";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var xPos = 0.0;
            if (this.xPos != null && !string.IsNullOrEmpty(this.xPos.Text))
                xPos = double.Parse(this.xPos.Text);

            var yPos = 0.0;
            if (this.yPos != null && !string.IsNullOrEmpty(this.yPos.Text))
                yPos = double.Parse(this.yPos.Text);

            var brep = new Brep();
            brep.StartPoint = new Tekla.Structures.Geometry3d.Point(xPos, yPos, 0);
            brep.EndPoint = new Tekla.Structures.Geometry3d.Point(xPos + Length, yPos, 0);
            brep.Profile.ProfileString = ShapeName;
            brep.Insert();

            var model = new Model();
            model.CommitChanges();
        }


        private FacetedBrep CreateBrepCube(double length)
        {
            var vertices = new[]
            {
                new Vector(0.0,     0.0,    0.0), // 0
                new Vector(length,  0.0,    0.0), // 1
                new Vector(length,  length, 0.0), // 2
                new Vector(0.0,     length, 0.0), // 3
                new Vector(0.0,     0.0,    length), // 4
                new Vector(length,  0.0,    length), // 5
                new Vector(length,  length, length), // 6
                new Vector(0.0,     length, length), // 7
            };
            var outloop = new[] { new[] { 0, 3, 2, 1 }, 
                                  new[] { 0, 1, 5, 4 }, 
                                  new[] { 1, 2, 6, 5 }, 
                                  new[] { 2, 3, 7, 6 },
                                  new[] { 3, 0, 4, 7 }, 
                                  new[] { 4, 5, 6, 7 }};

            var innerLoop = new Dictionary<int, int[][]>
            {
            };

            return new FacetedBrep(vertices, outloop, innerLoop);
        }

        private FacetedBrep CreateBrepPyramid(double length)
        {
            var vertices = new[]
            {
                new Vector(0.0,     0.0,    0.0), // 0
                new Vector(length,  0.0,    0.0), // 1
                new Vector(length,  length, 0.0), // 2
                new Vector(0.0,     length, 0.0), // 3
                new Vector(length/2,     length/2,    length) // 4
            };
            var outloop = new[] { new[] { 0, 3, 2, 1 }, 
                                  new[] { 0, 3, 4 }, 
                                  new[] { 3, 2, 4 }, 
                                  new[] { 2, 1, 4 },
                                  new[] { 1, 0, 4 }};

            var innerLoop = new Dictionary<int, int[][]>
            {
            };

            return new FacetedBrep(vertices, outloop, innerLoop);
        }
    }
}
