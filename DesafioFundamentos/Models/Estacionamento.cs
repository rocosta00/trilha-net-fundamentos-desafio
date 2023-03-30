using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            // Validar o formato da placa digitada pelo usuario -> AAA-0000 (tres letras - quatro numeros)
            Regex regex = new Regex(@"^[A-Za-z]{3}-\d{4}$");
            bool isMatch = regex.IsMatch(placa);
            if (!isMatch) {
                Console.WriteLine("Entrada inválida. Digite uma placa no formato AAA-0000.");
            }
            else {
                veiculos.Add(placa);
            }
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string valorHora = Console.ReadLine();

                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado
                int horas = 0;
                horas = Convert.ToInt32(valorHora);
                decimal valorTotal = 0;

                // Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                valorTotal = precoInicial + (precoPorHora * horas);

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // Realizar um laço de repetição na lista "veiculos", exibindo os veículos estacionados e escreve cada placa armazenada
                foreach(string item in veiculos) {
                Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}