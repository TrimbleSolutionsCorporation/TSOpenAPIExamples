using System;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Filtering;
using Tekla.Structures.Filtering.Categories;
using Tekla.Structures.Model;

namespace FilterExmple
{
    public partial class Form1 : Form
    {
        //BinaryFilterExpression filterExpression1 { get; set; }
        //BinaryFilterExpression filterExpression2 { get; set; }
        //BinaryFilterExpression filterExpression3 { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filterDefinition = new BinaryFilterExpressionCollection();
            if (this.checkBox_pourNumber.Checked && this.textBox_pourNumber != null &&
                !string.IsNullOrEmpty(this.textBox_pourNumber.Text))
            {
                var filterExpression1 = new BinaryFilterExpression(
                    new PourObjectFilterExpressions.PourNumber(), StringOperatorType.IS_EQUAL,
                    new StringConstantFilterExpression(this.textBox_pourNumber.Text));
                filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression1, BinaryFilterOperatorType.BOOLEAN_AND));
            }

            if (this.checkBox_pourType.Checked && this.textBox_pourType != null && !string.IsNullOrEmpty(this.textBox_pourType.Text))
            {
                var filterExpression2 = new BinaryFilterExpression(
                    new PourObjectFilterExpressions.PourType(), StringOperatorType.IS_EQUAL,
                    new StringConstantFilterExpression(this.textBox_pourType.Text));
                filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression2, BinaryFilterOperatorType.BOOLEAN_AND));
            }

            if (this.checkBox_pourCM.Checked && this.textBox_CM != null && !string.IsNullOrEmpty(this.textBox_CM.Text))
            {
                var filterExpression3 = new BinaryFilterExpression(
                    new PourObjectFilterExpressions.ConcreteMixture(), StringOperatorType.IS_EQUAL,
                    new StringConstantFilterExpression(this.textBox_CM.Text));
                filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression3, BinaryFilterOperatorType.BOOLEAN_AND));
            }

            var filterExpression4 = new BinaryFilterExpression(new ObjectFilterExpressions.Type(),
                NumericOperatorType.IS_EQUAL, new NumericConstantFilterExpression(TeklaStructuresDatabaseTypeEnum.DB_POUR_OBJECT));
            filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression4));

            var model = new Model();
            var selector = model.GetModelObjectSelector();
            var enumerator = selector.GetObjectsByFilter(filterDefinition);
            if (enumerator != null)
                this.filteredPours.Text = enumerator.GetSize().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filterDefinition = new BinaryFilterExpressionCollection();
            if (this.checkBox_PUName.Checked && this.textBox_PUName != null &&
                !string.IsNullOrEmpty(this.textBox_PUName.Text))
            {
                var filterExpression1 = new BinaryFilterExpression(
                    new PourUnitFilterExpressions.Name(), StringOperatorType.IS_EQUAL,
                    new StringConstantFilterExpression(this.textBox_PUName.Text));
                filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression1, BinaryFilterOperatorType.BOOLEAN_AND));
            }

            var filterExpression2 = new BinaryFilterExpression(new ObjectFilterExpressions.Type(),
                NumericOperatorType.IS_EQUAL, new NumericConstantFilterExpression(TeklaStructuresDatabaseTypeEnum.DB_POUR_UNIT));
            filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression2));

            var model = new Model();
            var selector = model.GetModelObjectSelector();
            var enumerator = selector.GetObjectsByFilter(filterDefinition);
            if (enumerator != null)
                this.filteredPU.Text = enumerator.GetSize().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filterDefinition = new BinaryFilterExpressionCollection();
            if (this.checkBox_surfaceName.Checked && this.textBox_surfaceName != null &&
                !string.IsNullOrEmpty(this.textBox_surfaceName.Text))
            {
                var filterExpression1 = new BinaryFilterExpression(
                    new SurfaceFilterExpressions.Name(), StringOperatorType.IS_EQUAL,
                    new StringConstantFilterExpression(this.textBox_surfaceName.Text));
                filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression1, BinaryFilterOperatorType.BOOLEAN_AND));
            }

            if (this.checkBox_surfaceType.Checked && this.textBox_surfaceType != null &&
                !string.IsNullOrEmpty(this.textBox_surfaceType.Text))
            {
                var filterExpression2 = new BinaryFilterExpression(
                    new SurfaceFilterExpressions.Type(), StringOperatorType.IS_EQUAL,
                    new StringConstantFilterExpression(this.textBox_surfaceType.Text));
                filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression2, BinaryFilterOperatorType.BOOLEAN_AND));
            }

            if (this.checkBox_surfaceClass.Checked && this.textBox_surfaceClass != null &&
                !string.IsNullOrEmpty(this.textBox_surfaceClass.Text))
            {
                var filterExpression3 = new BinaryFilterExpression(
                    new SurfaceFilterExpressions.Class(), NumericOperatorType.IS_EQUAL,
                    new NumericConstantFilterExpression(Int32.Parse(this.textBox_surfaceClass.Text)));
                filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression3, BinaryFilterOperatorType.BOOLEAN_AND));
            }

            var filterExpression4 = new BinaryFilterExpression(new ObjectFilterExpressions.Type(),
                NumericOperatorType.IS_EQUAL, new NumericConstantFilterExpression(TeklaStructuresDatabaseTypeEnum.SURFACE_OBJECT));
            filterDefinition.Add(new BinaryFilterExpressionItem(filterExpression4));

            var model = new Model();
            var selector = model.GetModelObjectSelector();
            var enumerator = selector.GetObjectsByFilter(filterDefinition);
            if (enumerator != null)
                this.filteredSurfaces.Text = enumerator.GetSize().ToString();
        }
    }
}
