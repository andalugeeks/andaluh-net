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

            Assert.Equal("BAYA baya, �i b� toa de EMBIDIA",res);
        }

        [Fact]
        public void Test2()
        {
            var res2 = Andaluh.EPA.Transcribe("Lleva un Guijarrito el ABuelo, �Qu� Bueno! �para la VERG�ENZA!");

            Assert.Equal("Yeba un Giharrito el AGuelo, �Qu� Gueno! �pa la BERGUEN�A!", res2);
        }

        [Fact]
        public void Test3()
        {
            var res3 = Andaluh.EPA.Transcribe("Los SABuesos ChiHuaHUA com�an cacaHuETes, FramBuESas y Heno, �y HABLAN con h�lito de ESPANGLISH!");

            Assert.Equal("L� �AGue�� XiGuaGUA com�an cacaGuET�, FramBuE�� y Eno, �y ABLAN con �lito de �PPANGL�!", res3);
        }

        [Fact]
        public void Test4()
        {
            var res4 = Andaluh.EPA.Transcribe("'Una comida fabada con fado, y sin descuido ser� casada y amarrada al acolchado roido.");

            Assert.Equal("Una comida fabada con fado, y �in d�ccuido �er� ca�� y amarr� al acorxao ro�o.", res4);
        }
    }
}
