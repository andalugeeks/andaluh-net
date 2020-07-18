using Andaluh;
using Xunit;

namespace Tests
{
    public class Unit
    {
        [Fact]
        public void LLCambiaY()
        {
            var res = EPA.Transcribe("LL ll");

            Assert.Equal("Y y", res);
        }

        [Fact]
        public void CHCambiaX()
        {
            var res = EPA.Transcribe("CH ch Chan chan");

            Assert.Equal("X x Xan xan", res);
        }

        [Fact]
        public void Entendederas()
        {
            var res = EPA.Transcribe("absolvederas entendederas");

            Assert.Equal("âççorbeérâ entendeérâ", res);
        }

        [Fact]
        public void Alhurreca()
        {
            var res = EPA.Transcribe("alhurreca");

            Assert.Equal("alhurreca", res);
        }

        [Fact]
        public void Ahuehue()
        {
            var res = EPA.Transcribe("ahuehué");

            Assert.Equal("aguegué", res);
        }

        [Fact]
        public void ElQueAcanala()
        {
            var res = EPA.Transcribe("acanalador");

            Assert.Equal("acanalaôh", res);
        }
        
        [Fact]
        public void D_Intervocalica()
        {
            var res = EPA.Transcribe("Oido un ruido");

            Assert.Equal("Oío un ruío", res);
        }

        [Fact]
        public void HaberA_ver()
        {
            var res = EPA.Transcribe("A ver [haber]");

            Assert.Equal("A bêh [abêh]", res);
        }

        [Fact]
        public void Envidia()
        {
            var res = EPA.Transcribe("ENVIDIA");

            Assert.Equal("EMBIDIA", res);
        }

        [Fact]
        public void Around()
        {
            var res = EPA.Transcribe("Alrededor");

            Assert.Equal("Arrededôh", res);
        }

        [Fact]
        public void Acetamida()
        {
            var res = EPA.Transcribe("acetamida");

            Assert.Equal("açetamida", res);
        }

        [Fact]
        public void Aljarafe()
        {
            var res = EPA.Transcribe("aljarafe algébrico");

            Assert.Equal("arharafe arhébrico", res);
        }

        [Fact]
        public void El()
        {
            var res = EPA.Transcribe("el agua, el Manuel, el agua del Manuel");

            Assert.Equal("el agua, er Manuêh, el agua der Manuêh", res);
        }

        [Fact]
        public void AFortiori()
        {
            var res = EPA.Transcribe("a fortiori");

            Assert.Equal("afortiori", res);
        }

        [Fact]
        public void Apegaderas()
        {
            var res = EPA.Transcribe("apegaderas");

            Assert.Equal("apegaérâ", res);
        }

        [Fact]
        public void Del()
        {
            var res = EPA.Transcribe("del abstracto");

            Assert.Equal("del âttrâtto", res);
        }
        [Fact]
        public void Desposeido()
        {
            var res = EPA.Transcribe("desposeído");

            Assert.Equal("dêppoçeío", res);
        }
        

        [Fact]
        public void Dulce()
        {
            var res = EPA.Transcribe("almíbar");

            Assert.Equal("armíbâ", res);
        }

        [Fact]
        public void Tonto()
        {
            var res = EPA.Transcribe("estúpido");

            Assert.Equal("êttúpido", res);
        }

        [Fact]
        public void Manuel()
        {
            var res = EPA.Transcribe("el Manuel");

            Assert.Equal("er Manuêh", res);
        }

        [Fact]
        public void Nicolas()
        {
            var res = EPA.Transcribe("maduro");

            Assert.Equal("maúro", res);
        }

        [Fact]
        public void Escuchar()
        {
            var res = EPA.Transcribe("oír");

            Assert.Equal("oîh", res);
        }

        [Fact]
        public void Silvar()
        {
            var res = EPA.Transcribe("sILBAR");

            Assert.Equal("çIRBÂH", res);
        }

        [Fact]
        public void Traslado()
        {
            var res = EPA.Transcribe("translados");

            Assert.Equal("trâl-láô", res);
        }

        [Fact]
        public void Triceps()
        {
            var res = EPA.Transcribe("tríceps");

            Assert.Equal("tríçê", res);
        }

        [Fact]
        public void Bebedero()
        {
            var res = EPA.Transcribe("aljibe aljuba");

            Assert.Equal("arhibe arhuba", res);
        }
        

        [Fact]
        public void Cai()
        {
            var res = EPA.Transcribe("Cádiz");

            Assert.Equal("Cádî", res);
        }

        [Fact]
        public void Transportandonos()
        {
            var res = EPA.Transcribe("Transportandonos a la connotación perspicaz del abstracto solsticio de Alaska, el aislante plástico adsorvente asfixió");

            Assert.Equal("Trâpportandonô a la cônnotaçión perppicâh del âttrâtto çorttiçio de Alâkka, el aîl-lante pláttico âççorbente âffîççió", res);
        }

        
        [Fact]
        public void Absorvente()
        {
            var res = EPA.Transcribe("adsorvente absorvente");

            Assert.Equal("âççorbente âççorbente", res);
        }
       

        [Fact]
        public void Sexy()
        {
            var res = EPA.Transcribe("sexy");

            Assert.Equal("çêççy", res);
        }

        [Fact]
        public void Cacahue()
        {
            var res = EPA.Transcribe("cacaHuETes");

            Assert.Equal("cacaGuETê", res);
        }

        [Fact]
        public void Cicahue()
        {
            var res = EPA.Transcribe("cicahuite");

            Assert.Equal("çicaguite", res);
        }

        [Fact]
        public void Spanglish()
        {
            var res = EPA.Transcribe("ESPANGLISH");

            Assert.Equal("ÊPPANGLÎ", res);
        }

        [Fact]
        public void Escapes()
        {
            var res = EPA.Transcribe("@miguel http://google.com #Hashtag");

            Assert.Equal("@miguel http://google.com #Hashtag", res);
        }

        [Fact]
        public void MasEscapes()
        {
            var res = EPA.Transcribe("Mi correo es todito@outlook.com es de Outlook. También tengo cuenta en twitter");

            Assert.Equal("Mi correo ê todito@outlook.com ê de Outlook. También tengo cuenta en twitter", res);
        }

        [Fact]
        public void Casada()
        {
            var res = EPA.Transcribe("Casada");

            Assert.Equal("Caçá", res);
        }

        [Fact]
        public void Cazabombardero()
        {
            var res = EPA.Transcribe("cazabombardero");

            Assert.Equal("caçabombardero", res);
        }

        [Fact]
        public void Cual()
        {
            var res = EPA.Transcribe("cual");

            Assert.Equal("cuâh", res);
        }

        [Fact]
        public void Acar()
        {
            var res = EPA.Transcribe("ahotado");

            Assert.Equal("ahotao", res);
        }
        

        [Fact]
        public void Pseudoescritor()
        {
            var res = EPA.Transcribe("pseudoescritor");

            Assert.Equal("çeudoêccritôh", res);
        }

        [Fact]
        public void Extasis()
        {
            var res = EPA.Transcribe("éxtasis");

            Assert.Equal("éttaçî", res);
        }

        [Fact]
        public void Asfixian()
        {
            var res = EPA.Transcribe("asfixian");

            Assert.Equal("âffîççian", res);
        }

        [Fact]
        public void AbdicanAsfixian()
        {
            var res = EPA.Transcribe("asfixian y éxtasis");

            Assert.Equal("âffîççian y éttaçî", res);
        }

        [Fact]
        public void ExtasisAsfixian()
        {
            var res = EPA.Transcribe("éxtasis y asfixian");

            Assert.Equal("éttaçî y âffîççian", res);
        }

        [Fact]
        public void Saxo()
        {
            var res = EPA.Transcribe("saxofón");

            Assert.Equal("çâççofón", res);
        }

        [Fact]
        public void Valkiria()
        {
            var res = EPA.Transcribe("valkirias");

            Assert.Equal("barkiriâ", res);
        }

        [Fact]
        public void Viandero()
        {
            var res = EPA.Transcribe("viandero");

            Assert.Equal("biandero", res);
        }

        [Fact]
        public void Bueno()
        {
            var res = EPA.Transcribe("Qué Bueno, qué buena");

            Assert.Equal("Qué Gueno, qué guena", res);
        }

        [Fact]
        public void Coger()
        {
            var res = EPA.Transcribe("aprehender");

            Assert.Equal("aprehendêh", res);
        }

        [Fact]
        public void TodasLasCosas()
        {
            var res = EPA.Transcribe("Todo Todito todo");

            Assert.Equal("Tó Toito tó", res);
        }

        [Fact]
        public void QuieroAgua()
        {
            var res = EPA.Transcribe("Tengo sed. Sed!");

            Assert.Equal("Tengo çêh. Çêh!", res);
        }
    }
}
