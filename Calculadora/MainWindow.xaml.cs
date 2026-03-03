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
using System.Windows.Media;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }


        double numero1;
        string operacao;
        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            Button botao = sender as Button;
            txtDisplay.Text += botao.Content.ToString();
        }

        private void Operador_Click(object sender, RoutedEventArgs e)
        {
            Button botao = sender as Button;

            numero1 = Convert.ToDouble(txtDisplay.Text);
            operacao = botao.Content.ToString();
            txtDisplay.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            TocarSom("igualAudio.mpeg");

            double resultado = 0;

            if (operacao == "√")
            {
                resultado = Math.Sqrt(numero1);
            }
            else
            {
                double numero2 = Convert.ToDouble(txtDisplay.Text);

                switch (operacao)
                {
                    case "%":
                        resultado = numero1 % numero2;
                        break;
                    case "+":
                        resultado = numero1 + numero2;
                        break;
                    case "-":
                        resultado = numero1 - numero2;
                        break;
                    case "×":
                        resultado = numero1 * numero2;
                        break;
                    case "÷":
                        resultado = numero1 / numero2;
                        break;
                }
            }

            txtDisplay.Text = resultado.ToString();
        }

        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            TocarSom("limparAudio.mpeg");
            txtDisplay.Text = "";
        }

        private void TocarSom(string nomeArquivo)
        {
            MediaPlayer novoPlayer = new MediaPlayer();

            string caminho = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Audios",
                nomeArquivo);

            novoPlayer.Open(new Uri(caminho, UriKind.Absolute));
            novoPlayer.Play();
        }
    }
}