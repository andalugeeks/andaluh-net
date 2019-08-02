namespace Andaluh
{
    public static class EPA
    {
        public static string Transcribe(
            string text,
            string vaf = "VAF",
            string vvf = "VVF",
            bool debug = false)
        {
            //Do not start transcription if the input is empty
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }


            var resH = EPARules.HRules(text);

            var resX = EPARules.XRules(resH);

            var resCH = EPARules.CHRules(resX);

            var resV = EPARules.VRules(resCH);

            var resLL = EPARules.LLRules(resV);

            var resL = EPARules.LRules(resLL);


            return resL;
        }

        public static string ToAndaluh(
            this string text,
            bool debug = false)
        {
            //Do not start transcription if the input is empty
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            var resH = EPARules.HRules(text);

            var resX = EPARules.XRules(resH);

            var resCH = EPARules.CHRules(resX);

            var resV = EPARules.VRules(resCH);

            var resLL = EPARules.LLRules(resV);

            var resL = EPARules.LRules(resLL);


            return resL;
        }
    }
}
