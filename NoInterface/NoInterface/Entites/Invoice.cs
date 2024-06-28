using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoInterface.Entites
{
     class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            this.Tax = tax;
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "Pagamento do Aluguel: "
                + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\nImpostos: "
                + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\nPagamento Total: "
                + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);

        }
    }
}
