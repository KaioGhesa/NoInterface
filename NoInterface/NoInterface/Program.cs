using System.Globalization;
using NoInterface.Services;
using NoInterface.Entites;

namespace NoInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Entre com os dados do aluguel ");
            Console.WriteLine();

            Console.Write("Modelo do Carro: ");
            string model = Console.ReadLine();
            Console.Write("Retirada do Carro: (dd/MM/yyyy HH:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            
            Console.Write("Devolução do Carro: (dd/MM/yyyy HH:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);


            Console.Write("Entre com o preço por Hora: ");
            double hour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.Write("Entre com o preço por dia: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));


            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessInovice(carRental);

            Console.WriteLine();
            Console.WriteLine("Nota Fiscal: ");
            Console.WriteLine();
            Console.WriteLine(carRental.Invoice);

        }
    }
}
