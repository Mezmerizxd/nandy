namespace Controller
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void LogToConsole(string message)
        {
            ConsoleOutput.Text = ConsoleOutput.Text + "\n" + message;
            return;
        }
    }
}