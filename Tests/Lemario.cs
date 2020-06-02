using Andaluh;
using System;
using Tests.CSVUtils;
using Xunit;

namespace Tests
{
    public class Lemario
    {
        [Fact]
        public void LemarioCompleto()
        {
            var aciertos = 0;
            var fallos = 0;
            var listaDeFallos = string.Empty;

            var todasLasPalabras = ReadCSV.GetRows("..\\..\\..\\lemario.csv");

            foreach (var palabra in todasLasPalabras)
            {
                if (palabra.Andaluh == palabra.Castellano.ToAndaluh()) aciertos++;
                else
                {
                    fallos++;
                    listaDeFallos += $"Error: {palabra.Castellano} => {palabra.Castellano.ToAndaluh()} se esperaba {palabra.Andaluh}\r\n";
                }
            }

            if (fallos != 0) throw new Exception($"Aciertos {aciertos} | Fallos {fallos} => {aciertos * 100/(aciertos+fallos)}%\r\nLISTA DE ERRORES\r\n{listaDeFallos}");

            Assert.Equal(0, fallos);

        }
    }
}
