using System.Collections.Generic;

namespace Andaluh.SentenceMethods
{
    public static class SentenceExceptions
    {
        private static string[] TradeMarks = new string[]
        { 
            "google", "twitter", "facebook", "outlook"
        };

        private static Dictionary<string, string> Exceptions = new Dictionary<string, string>
        {
            { "et", "et" },
            { "a capela","a capela"},
            { "a contráriis","a contrárî"},
            { "a contrario sensu","a contrario çençu"},
            { "a divinis","adibinî"},
            { "a fortiori","afortiori"},
            { "a látere","a látere"},
            { "a nativitate","a natibitate"},
            { "a pari","a pari"},
            { "a posteriori","a pôtteriori"},
            { "a priori","a priori"},
            { "a quo","a quo"},
            { "a rádice","a rádiçe"},
            { "a sensu contrario","a çençu contrario"},
            { "a símili","a çímili"},
            { "ab aeterno","abetênno"},
            { "ab initio","abinitio"},
            { "ab intestato","ab intêttato"},
            { "ab irato","ab irato"},
            { "ab ovo","ab obo"},
            { "ad calendas graecas","âccalendâhgrecâ"},
            { "ad cautélam","âccautelam"},
            { "ad efesios","âhefeçióh"},
            { "ad hoc","adôh"},
            { "ad hóminem","adóminem"},
            { "ad honórem","adonorem"},
            { "ad infinítum","adinfinitum"},
            { "ad ínterim","adínterim"},
            { "ad líbitum","âl-líbitum"},
            { "ad límina","âl-límina"},
            { "ad lítteram","âl-líteram"},
            { "ad náuseam","ânnáuçeam"},
            { "ad nútum","ânnútum"},
            { "ad pédem lítterae","âppedem líterae"},
            { "ad perpétuam","âpperpétuam"},
            { "ad persónam","âpperçónam"},
            { "ad quem","âqquem"},
            { "ad referéndum","ârreferendum"},
            { "ad tempus","âttempû"},
            { "ad valórem","âbbalórem"},
            { "álter ego", "árterego" },
            { "ex abrupto","ehabrûtto" },
            { "ex aequo","ehaecuo" },
            { "ex cáthedra","êccátedra" },
            { "ex libris","êl-librî" },
            { "ex profeso","êpprofeço" },
            { "ut retro","ut retro" },
            { "ut supra","ut çupra" },
            { "vox pópuli", "bôppópuli" }
        };

        public static Dictionary<string, string> allExceptions;

        public static Dictionary<string, string> AllExceptions
        {
            get
            {
                if (allExceptions == null)
                    allExceptions = CreateAllExceptions();

                return allExceptions;
            }
        }
        private static Dictionary<string, string> CreateAllExceptions()
        {
            var allExceptions = new Dictionary<string, string>();

            foreach (var exception in Exceptions)
                allExceptions.Add(exception.Key, exception.Value);
            
            foreach (var tradeMark in TradeMarks)
                allExceptions.Add(tradeMark, tradeMark);
            

            return allExceptions;
        }
    }
}
