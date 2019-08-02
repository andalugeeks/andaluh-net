using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var res = Andaluh.EPA.Transcribe("VALLA valla, si vas toda de ENVIDIA");

            Assert.Equal("BAYA baya, çi bâ toa de EMBIDIA",res);
        }

        [Fact]
        public void Test2()
        {
            var res2 = Andaluh.EPA.Transcribe("Lleva un Guijarrito el ABuelo, ¡Qué Bueno! ¡para la VERGÜENZA!");

            Assert.Equal("Yeba un Giharrito el AGuelo, ¡Qué Gueno! ¡pa la BERGUENÇA!", res2);
        }

        [Fact]
        public void Test3()
        {
            var res3 = Andaluh.EPA.Transcribe("Los SABuesos ChiHuaHUA comían cacaHuETes, FramBuESas y Heno, ¡y HABLAN con hálito de ESPANGLISH!");

            Assert.Equal("Lô ÇAGueçô XiGuaGUA comían cacaGuETê, FramBuEÇâ y Eno, ¡y ABLAN con álito de ÊPPANGLÎ!", res3);
        }

        [Fact]
        public void Test4()
        {
            var res4 = Andaluh.EPA.Transcribe("'Una comida fabada con fado, y sin descuido será casada y amarrada al acolchado roido.");

            Assert.Equal("Una comida fabada con fado, y çin dêccuido çerá caçá y amarrá al acorxao roío.", res4);
        }
    }
}
