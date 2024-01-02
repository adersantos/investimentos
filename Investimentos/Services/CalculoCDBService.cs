
using Investimentos.Domain;

namespace Investimentos.Services
{
    public class CalculoCDBService
    {
        internal object CalcularCDB(InvestimentoCDBDTO investimentoCDBDTO)
        {
            return CalcularCDBService(investimentoCDBDTO.Periodo, 
                                      investimentoCDBDTO.VI, 
                                      investimentoCDBDTO.CDI, 
                                      investimentoCDBDTO.TB);       
        }

        public double CalcularCDBService(int periodo, double VI, double CDI, double TB)
        {
            var CDB = VI * (1 + (CDI * TB));

            return CalcularImposto(periodo, CDB);
        }

        public double CalcularImposto(int periodo, double CDB)
        {
            switch (periodo)
            {
                case <= 6: return Aliquota225(CDB); break;
                case <= 12: return Aliquota2(CDB); break;
                case <= 24: return Aliquota175(CDB); break;
                default: return Aliquota15(CDB); break;
            }
        }

        # region METODOS AUXILIARES
        private static double Aliquota15(double CDB)
        {
            return CDB * 0.15;
        }

        private static double Aliquota175(double CDB)
        {
            return CDB * 0.175;
        }

        private static double Aliquota2(double CDB)
        {
            return CDB * 0.2;
        }

        private static double Aliquota225(double CDB)
        {
            return CDB * 0.225;
        }
        #endregion

    }
}
