using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Validations
{
    public class DomainExceptionValidation : Exception // ve se o erro tem na base de dados do exception
    {
        public DomainExceptionValidation(string error) : base(error) // explicando o atributo que vai vir erro o resto pega do exception
        { }

        public static void When(bool haseError, string error)// when - quando da erro executa o when 
        {
            if (haseError)
            {
                throw new DomainExceptionValidation(error);// tratamento executa o erro 
            }
        }
    }
}
