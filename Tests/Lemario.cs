using Andaluh;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tests.CSVUtils;
using Xunit;

namespace Tests
{
    public class Lemario
    {
        [Fact]
        public void LemarioCompleto()
        {
            var aciertosLock = new object();
            var fallosLock = new object();
            var aciertos = 0;
            var fallos = 0;
            var listaDeFallos = string.Empty;

            var todasLasPalabras = ReadCSV.GetRows("..\\..\\..\\lemario.csv");

            Parallel.ForEach(todasLasPalabras, palabra =>
            {
                if (palabra.Andaluh == palabra.Castellano.ToAndaluh()) sumaAcierto();
                else
                {
                    sumaFallo();
                    listaDeFallos += $"Error: {palabra.Castellano} => {palabra.Castellano.ToAndaluh()} se esperaba {palabra.Andaluh}\r\n";
                }
            });

            if (fallos != 0) throw new Exception($"Aciertos {aciertos} | Fallos {fallos} => {aciertos * 100/ todasLasPalabras.Count() }%\r\nLISTA DE ERRORES\r\n{listaDeFallos}");

            Assert.Equal(0, fallos);

            void sumaAcierto() { lock (aciertosLock) aciertos++; }
            void sumaFallo() { lock (fallosLock) fallos++; }
        }
    }
}
