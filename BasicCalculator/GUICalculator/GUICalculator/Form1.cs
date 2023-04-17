namespace GUICalculator
{
    public partial class Calculator : Form
    {
        Solver calc;

        // Constructor for Calculator to create new Solver Object and align text to right
        public Calculator()
        {
            InitializeComponent();
            calc = new Solver();
            CalcTextBox.SelectAll();
            CalcTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        // Update Input box by setting text to the equation string array and align to right
        void UpdateInputBox()
        {
            CalcTextBox.Lines = calc.equation;
            CalcTextBox.SelectAll();
            CalcTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }


        // Function for each button to add their own operator or number to the 1st line of the string
        private void button1_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("1");
            UpdateInputBox();
        }

        private void button2_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("2");
            UpdateInputBox();
        }

        private void button3_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("3");
            UpdateInputBox();
        }

        private void button4_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("4");
            UpdateInputBox();
        }

        private void button5_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("5");
            UpdateInputBox();
        }

        private void button6_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("6");
            UpdateInputBox();
        }

        private void button7_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("7");
            UpdateInputBox();
        }

        private void button8_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("8");
            UpdateInputBox();
        }

        private void button9_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("9");
            UpdateInputBox();
        }

        private void button0_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("0");
            UpdateInputBox();
        }

        private void ClearButton_Click(object sender, EventArgs e) 
        { 
            calc.Clear();
            UpdateInputBox();
        }

        private void DivideButton_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("/");
            UpdateInputBox();
        }

        private void PlusButton_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("+");
            UpdateInputBox();
        }

        private void MinusButton_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("-");
            UpdateInputBox();
        }

        private void MultiplyButton_Click(object sender, EventArgs e) 
        { 
            calc.Accumulate("*");
            UpdateInputBox();
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            double result = calc.Solve();
            if (calc.error) calc.equation[2] = "ERROR";
            else calc.equation[2] = result.ToString();
            UpdateInputBox();
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            calc.Accumulate(".");
            UpdateInputBox();
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            calc.Accumulate("-");
            UpdateInputBox();
        }

        private void ModButton_Click(object sender, EventArgs e)
        {
            calc.Accumulate("%");
            UpdateInputBox();
        }
    }
}