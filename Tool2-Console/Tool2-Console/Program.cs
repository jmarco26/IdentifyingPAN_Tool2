using System;
using System.Collections.Generic;
using System.IO;
using Tool2_Console.Models;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        string txtFilePath = "D:\\Tool2\\2010.txt";
        string datFilePath = "D:\\Tool2\\autoDCTitles.dat";

        List<TxtJournal> txtJournals = ReadTxtJournals(txtFilePath);
        List<DatJournal> datJournals = ReadDatJournals(datFilePath);

        List<OutJournal> outJournals = CompareJournals(txtJournals, datJournals);

        WriteOutputToFile(outJournals, "D:\\Tool2\\output.txt");

        Console.WriteLine("Output written to output.txt");
    }

    static List<TxtJournal> ReadTxtJournals(string filePath)
    {
        List<TxtJournal> txtJournals = new List<TxtJournal>();
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines.Skip(1))
        {
            string[] data = line.Split('\t');
            txtJournals.Add(new TxtJournal
            {
                PAN = data[0],
                Title = data[1],
                ISSN = data[2].Length >= 8 ? data[2] : " ",
                eISSN = data[3].Length >= 8 ? data[3] : " "
            });
        }
        return txtJournals;
    }

    static List<DatJournal> ReadDatJournals(string filePath)
    {
        List<DatJournal> datJournals = new List<DatJournal>();
        string[] lines = File.ReadAllLines(filePath);

        foreach(string line in lines.Skip(1))
        {
            lines[1] = Regex.Replace(line, @",\s", "|||"); 
        }

        foreach (string line in lines.Skip(1))
        {
            string[] data = line.Split(",");
            try
            {
                datJournals.Add(new DatJournal
                {
                    Title = data[1],
                    ISSN = data.Length >= 2 && data[2].Length >= 8 ? data[2] : "",
                    eISSN = data.Length >= 3 && data[3].Length >= 8 ? data[3] : ""
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.{ex.Message}");
            }
        }

        foreach (string line in lines.Skip(1))
        {
            lines[1] = Regex.Replace(line, @"\|\|\|", ", ");
        }
        return datJournals;
    }

    static List<OutJournal> CompareJournals(List<TxtJournal> txtJournals, List<DatJournal> datJournals)
    {
        List<OutJournal> outJournals = new List<OutJournal>();

        foreach (TxtJournal txtJournal in txtJournals)
        {
            bool found = false;
            foreach (DatJournal datJournal in datJournals)
            {
                if (txtJournal.Title == datJournal.Title || txtJournal.ISSN == datJournal.ISSN || txtJournal.eISSN == datJournal.eISSN)
                {
                    found = true;
                    string issnMatch = "", eissnMatch = "", titleMatch = "";
                    if (!string.IsNullOrWhiteSpace(txtJournal.ISSN) || !string.IsNullOrWhiteSpace(datJournal.ISSN))
                    {
                        if (string.IsNullOrWhiteSpace(txtJournal.ISSN) && string.IsNullOrWhiteSpace(datJournal.ISSN))
                        {
                            issnMatch = "matched";
                        }
                        else if (txtJournal.ISSN == " ")
                        {
                            issnMatch = "datonly";
                        }
                        else if(datJournal.ISSN == "")
                        {
                            issnMatch = "txtonly";
                        }
                        else
                        {
                            if(datJournal.ISSN == txtJournal.ISSN)
                            {
                                issnMatch = "matched";
                            }
                            else
                            {
                                issnMatch = "not matched";
                            }
                        }
                    }
                    else { issnMatch = "matched"; }
                    if (!string.IsNullOrWhiteSpace(txtJournal.eISSN) || !string.IsNullOrWhiteSpace(datJournal.eISSN))
                    {
                        if (string.IsNullOrWhiteSpace(txtJournal.eISSN) && string.IsNullOrWhiteSpace(datJournal.eISSN))
                        {
                            eissnMatch = "matched";
                        }
                        else if (txtJournal.eISSN == " ")
                        {
                            eissnMatch = "datonly";
                        }
                        else if (datJournal.eISSN == "")
                        {
                            eissnMatch = "txtonly";
                        }
                        else
                        {
                            if (datJournal.eISSN == txtJournal.eISSN)
                            {
                                eissnMatch = "matched";
                            }
                            else
                            {
                                eissnMatch = "not matched";
                            }
                        }
                    }
                    else { eissnMatch = "matched"; }
                    if (!string.IsNullOrWhiteSpace(txtJournal.Title) || !string.IsNullOrWhiteSpace(datJournal.Title))
                    {
                        if(string.IsNullOrWhiteSpace(txtJournal.Title) && string.IsNullOrWhiteSpace(datJournal.Title))
                        {
                            titleMatch = "matched";
                        }
                        else if (txtJournal.Title == " ")
                        {
                            titleMatch = "datonly";
                        }
                        else if (datJournal.Title == "")
                        {
                            titleMatch = "txtonly";
                        }
                        else
                        {
                            if (datJournal.Title == txtJournal.Title)
                            {
                                titleMatch = "matched";
                            }
                            else
                            {
                                titleMatch = "not matched";
                            }
                        }
                    }
                    else { titleMatch = "matched"; }

                    outJournals.Add(new OutJournal
                    {
                        PAN = txtJournal.PAN,
                        Title = titleMatch,
                        ISSN = issnMatch,
                        eISSN = eissnMatch
                    });
                    break;
                }
            }

            if (!found)
            {
                outJournals.Add(new OutJournal
                {
                    PAN = txtJournal.PAN,
                    Title = "txtonly",
                    ISSN = "txtonly",
                    eISSN = "txtonly"
                });
            }
        }
        return outJournals;
    }

    static void WriteOutputToFile(List<OutJournal> outJournals, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("PAN\tTitle\tISSN\teISSN");
            foreach (OutJournal outJournal in outJournals)
            {
                writer.WriteLine($"{outJournal.PAN}\t{outJournal.Title}\t{outJournal.ISSN}\t{outJournal.eISSN}");
            }
        }
    }
}