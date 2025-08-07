using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace miniZapier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            String userText= ScriptBox.Text;
            char[] chars = userText.ToCharArray();
            Tokens obj1= new Tokens(chars);
            List<Lexer> allDaTokens =  obj1.tokenExtracter();
            foreach (Lexer tokens in allDaTokens)
            {
                Debug.WriteLine(tokens.type);
            }
        }
    }
}