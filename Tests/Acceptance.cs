using Andaluh;
using Xunit;

namespace Tests
{
    public class Acceptance
    {
        [Fact]
        public void Test01() =>
            Assert.Equal("Er belôh murçiélago indú comía felîh cardiyo y kiwi. La çigueña tocaba er çâççofón detrâh der palenque de paha.", EPA.Transcribe("El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña tocaba el saxofón detrás del palenque de paja."));
        [Fact]
        public void Test02() =>
            Assert.Equal("Arrededôh de la Arpaca abía un ARfabeto ARTIBO de barkiriâ mânnaçidâ", EPA.Transcribe("Alrededor de la Alpaca había un ALfabeto ALTIVO de valkirias malnacidas"));
        [Fact]
        public void Test03() =>
                Assert.Equal("Tó Çenomorfo diçe: [abêh], que el Éççito y el éttaçî âffîççian, çi no erê un çilófono Xungo.", EPA.Transcribe("Todo Xenomorfo dice: [haber], que el Éxito y el éxtasis asfixian, si no eres un xilófono Chungo."));
        [Fact]
        public void Test04() =>
            Assert.Equal("Yeba un Giharrito el AGuelo, ¡Qué Gueno! ¡pa la BERGUENÇA!", EPA.Transcribe("Lleva un Guijarrito el ABuelo, ¡Qué Bueno! ¡para la VERGÜENZA!"));
        [Fact]
        public void Test05() =>
            Assert.Equal("BAYA baya, çi bâ toa de EMBIDIA", EPA.Transcribe("VALLA valla, si vas toda de ENVIDIA"));
        [Fact]
        public void Test06() =>
            Assert.Equal("En la Çaragoça y er Hapón açêççuâh çe Çabía ÇÉriamente çIRBÂH con er CÔççî", EPA.Transcribe("En la Zaragoza y el Japón asexual se Sabía SÉriamente sILBAR con el COxis"));
        [Fact]
        public void Test07() =>
        Assert.Equal("Trâpportandonô a la cônnotaçión perppicâh del âttrâtto çorttiçio de Alâkka, el aîl-lante pláttico âççorbente âffîççió al ânnéçico çeudoêccritôh granadino de côttituçionê, pa CôMMemorâh broncâ âccritâ", EPA.Transcribe("Transportandonos a la connotación perspicaz del abstracto solsticio de Alaska, el aislante plástico adsorvente asfixió al aMnésico pseudoescritor granadino de constituciones, para ConMemorar broncas adscritas"));
        [Fact]
        public void Test08() =>
            Assert.Equal("En la pômmodênnidá, er trâccurço de lô trâpportê y trâl-láô en pôttoperatoriô trâççienden a la pôttre unâ pôttiyâ pôppalatalê apôttiyâh çe trâffieren", EPA.Transcribe("En la postmodernidad, el transcurso de los transportes y translados en postoperatorios transcienden a la postre unas postillas postpalatales apostilladas se transfieren"));
        [Fact]
        public void Test09() =>
            Assert.Equal("Benîh tôh a corrêh en anorâh de biçón a Cádî con âttitûh y mardá, pa êccuxâh er tríçê de Arbénî tocâh ápû con birtûh de laûh.", EPA.Transcribe("Venid todos a correr en anorak de visón a Cádiz con actitud y maldad, para escuchar el tríceps de Albéniz tocar ápud con virtud de laúd."));
        [Fact]
        public void Test10() =>
            Assert.Equal("Una comida fabada con fado, y çin dêccuido çerá caçá y amarrá al acorxao roío.", EPA.Transcribe("Una comida fabada con fado, y sin descuido será casada y amarrada al acolchado roido."));
        [Fact]
        public void Test11() =>
            Assert.Equal("Lô ÇAGueçô XiGuaGUA comían cacaGuETê, FramBuEÇâ y Eno, ¡y ABLAN con álito de ÊPPANGLÎ!", EPA.Transcribe("Los SABuesos ChiHuaHUA comían cacaHuETes, FramBuESas y Heno, ¡y HABLAN con hálito de ESPANGLISH!"));

        //[Fact]
        //public void Test12() =>
        //Assert.Equal(EPA.Transcribe("Oye sexy @miguel, la web HTTPS://andaluh.es no sale en google.es pero si en http://google.com #porqueseñor", escape_links = True), "Oye çêççy @miguel, la wêh HTTPS://andaluh.es no çale en google.es pero çi en http://google.com #porqueseñor");
    }
}
