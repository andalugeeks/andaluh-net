using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Data;

namespace Tests.CSVUtils
{
    public static class ReadCSV
    {
        public static IEnumerable<(string Castellano, string Andaluh)> GetRows(string path)
        {
            DataTable table = GetDataTableFromCSVFile(path);

            var castellano = table.Columns["cas"];
            var andaluh = table.Columns["and"];

            foreach (DataRow row in table.Rows)
                yield return (row[castellano].ToString(), row[andaluh].ToString());

        }

        private static DataTable GetDataTableFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                            if (fieldData[i] == "")
                                fieldData[i] = null;

                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch { }

            return csvData;
        }
    }
}
