using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ConversorMoedas
{
    public partial class MainWindow : Window
    {
        
        private readonly Dictionary<string, double> taxasDeCambio = new Dictionary<string, double>
        {
            { "Dólar (USD)", 5.25 },
            { "Euro (EUR)", 5.70 },
            { "Libra Esterlina (GBP)", 6.65 },
            { "Iene Japonês (JPY)", 0.037 },
            { "Franco Suíço (CHF)", 5.90 },
            { "Dólar Canadense (CAD)", 3.85 },
            { "Peso Argentino (ARS)", 0.025 }
        };

        public MainWindow()
        {
            InitializeComponent();
            CarregarMoedas();
        }

        
        private void CarregarMoedas()
        {
            foreach (var moeda in taxasDeCambio.Keys)
            {
                MoedaComboBox.Items.Add(moeda);
            }
            
            MoedaComboBox.SelectedIndex = 0;
        }

         
        private void ConverterButton_Click(object sender, RoutedEventArgs e)
        {
            //  Validando 
            
            if (!double.TryParse(ValorReaisTextBox.Text, out double valorEmReais) || valorEmReais <= 0)
            {
                MessageBox.Show("Digite um valor válido em reais.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            //  Extraindo os dados
           
            string moedaSelecionada = MoedaComboBox.SelectedItem.ToString();
            
           
            double taxa = taxasDeCambio[moedaSelecionada];
            
           
            int inicioCodigo = moedaSelecionada.IndexOf('(') + 1;
            int fimCodigo = moedaSelecionada.IndexOf(')');
            string codigoMoeda = moedaSelecionada.Substring(inicioCodigo, fimCodigo - inicioCodigo);

            //  Convertendo
            
            double valorConvertido = valorEmReais / taxa;

            //  Exibindo Texto 
            
            ResultadoTextBlock.Text = $"Valor convertido: R$ {valorEmReais:F2} = {valorConvertido:F2} {codigoMoeda}";
        }
    }
}