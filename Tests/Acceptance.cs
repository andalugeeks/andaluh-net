using Andaluh;
using Xunit;

namespace Tests
{
    public class Acceptance
    {
        [Fact]
        public void Test01() =>
            Assert.Equal("Er bel�h mur�i�lago ind� com�a fel�h cardiyo y kiwi. La �igue�a tocaba er ����of�n detr�h der palenque de paha.", EPA.Transcribe("El veloz murci�lago hind� com�a feliz cardillo y kiwi. La cig�e�a tocaba el saxof�n detr�s del palenque de paja."));
        [Fact]
        public void Test02() =>
            Assert.Equal("Arreded�h de la Arpaca ab�a un ARfabeto ARTIBO de barkiri� m�nna�id�", EPA.Transcribe("Alrededor de la Alpaca hab�a un ALfabeto ALTIVO de valkirias malnacidas"));
        [Fact]
        public void Test03() =>
                Assert.Equal("T� �enomorfo di�e: [ab�h], que el ���ito y el �tta�� �ff���ian, �i no er� un �il�fono Xungo.", EPA.Transcribe("Todo Xenomorfo dice: [haber], que el �xito y el �xtasis asfixian, si no eres un xil�fono Chungo."));
        [Fact]
        public void Test04() =>
            Assert.Equal("Yeba un Giharrito el AGuelo, �Qu� Gueno! �pa la BERGUEN�A!", EPA.Transcribe("Lleva un Guijarrito el ABuelo, �Qu� Bueno! �para la VERG�ENZA!"));
        [Fact]
        public void Test05() =>
            Assert.Equal("BAYA baya, �i b� toa de EMBIDIA", EPA.Transcribe("VALLA valla, si vas toda de ENVIDIA"));
        [Fact]
        public void Test06() =>
            Assert.Equal("En la �arago�a y er Hap�n a����u�h �e �ab�a ��riamente �IRB�H con er C����", EPA.Transcribe("En la Zaragoza y el Jap�n asexual se Sab�a S�riamente sILBAR con el COxis"));
        [Fact]
        public void Test07() =>
        Assert.Equal("Tr�pportandon� a la c�nnota�i�n perppic�h del �ttr�tto �ortti�io de Al�kka, el a�l-lante pl�ttico ���orbente �ff���i� al �nn��ico �eudo�ccrit�h granadino de c�ttitu�ion�, pa C�MMemor�h bronc� �ccrit�", EPA.Transcribe("Transportandonos a la connotaci�n perspicaz del abstracto solsticio de Alaska, el aislante pl�stico adsorvente asfixi� al aMn�sico pseudoescritor granadino de constituciones, para ConMemorar broncas adscritas"));
        [Fact]
        public void Test08() =>
            Assert.Equal("En la p�mmod�nnid�, er tr�ccur�o de l� tr�pport� y tr�l-l�� en p�ttoperatori� tr���ienden a la p�ttre un� p�ttiy� p�ppalatal� ap�ttiy�h �e tr�ffieren", EPA.Transcribe("En la postmodernidad, el transcurso de los transportes y translados en postoperatorios transcienden a la postre unas postillas postpalatales apostilladas se transfieren"));
        [Fact]
        public void Test09() =>
            Assert.Equal("Ben�h t�h a corr�h en anor�h de bi��n a C�d� con �ttit�h y mard�, pa �ccux�h er tr��� de Arb�n� toc�h �p� con birt�h de la�h.", EPA.Transcribe("Venid todos a correr en anorak de vis�n a C�diz con actitud y maldad, para escuchar el tr�ceps de Alb�niz tocar �pud con virtud de la�d."));
        [Fact]
        public void Test10() =>
            Assert.Equal("Una comida fabada con fado, y �in d�ccuido �er� ca�� y amarr� al acorxao ro�o.", EPA.Transcribe("Una comida fabada con fado, y sin descuido ser� casada y amarrada al acolchado roido."));
        [Fact]
        public void Test11() =>
            Assert.Equal("L� �AGue�� XiGuaGUA com�an cacaGuET�, FramBuE�� y Eno, �y ABLAN con �lito de �PPANGL�!", EPA.Transcribe("Los SABuesos ChiHuaHUA com�an cacaHuETes, FramBuESas y Heno, �y HABLAN con h�lito de ESPANGLISH!"));

        //[Fact]
        //public void Test12() =>
        //Assert.Equal(EPA.Transcribe("Oye sexy @miguel, la web HTTPS://andaluh.es no sale en google.es pero si en http://google.com #porquese�or", escape_links = True), "Oye ����y @miguel, la w�h HTTPS://andaluh.es no �ale en google.es pero �i en http://google.com #porquese�or");
    }
}
