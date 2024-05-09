using System.Diagnostics;
using System.Formats.Tar;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tool2_Console.Models;

namespace IdentifyingPAN_Tool2
{
    public partial class PAN_Tool2 : Form
    {
        public PAN_Tool2()
        {
            InitializeComponent();
        }

        private void btn_browseDAT_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string datFile = "";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                datFile = fileDialog.FileName;
                if (!Path.GetExtension(datFile).Equals(".dat", StringComparison.OrdinalIgnoreCase)) { MessageBox.Show("Please select a .dat file"); }
                else
                {
                    tbx_dat.Text = datFile;
                    btn_PreviewDAT.Enabled = true;
                }
            }
        }

        private void btn_browseTXT_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string txtFile = "";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile = fileDialog.FileName;
                if (!Path.GetExtension(txtFile).Equals(".txt", StringComparison.OrdinalIgnoreCase)) { MessageBox.Show("Please select a .txt file"); }
                else
                {
                    tbx_txt.Text = txtFile;
                    btn_PreviewTXT.Enabled = true;
                }
            }
        }

        private void btn_browseOUT_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string folderPath = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = dialog.SelectedPath;
                tbx_out.Text = folderPath;
                btn_clearOut.Enabled = true;
            }
        }

        private void btn_PreviewDAT_Click(object sender, EventArgs e)
        {
            previewFile(tbx_dat.Text);
        }

        private void btn_PreviewTXT_Click(object sender, EventArgs e)
        {
            previewFile(tbx_txt.Text);
        }

        private void btn_clearOut_Click(object sender, EventArgs e)
        {
            tbx_out.Text = "";
        }

        private void tbx_dat_TextChanged(object sender, EventArgs e)
        {
            if (tbx_dat.Text == "") { btn_PreviewDAT.Enabled = btn_Identify.Enabled = false; }
            else { btn_Identify.Enabled = (tbx_out.Text != "" && tbx_txt.Text != "") ? true : false; }
        }

        private void tbx_txt_TextChanged(object sender, EventArgs e)
        {
            if (tbx_txt.Text == "") { btn_PreviewTXT.Enabled = btn_Identify.Enabled = false; }
            else { btn_Identify.Enabled = (tbx_dat.Text != "" && tbx_out.Text != "") ? true : false; }
        }

        private void tbx_out_TextChanged(object sender, EventArgs e)
        {
            if (tbx_out.Text == "") { btn_clearOut.Enabled = btn_Identify.Enabled = false; }
            else { btn_Identify.Enabled = (tbx_dat.Text != "" && tbx_txt.Text != "") ? true : false; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { tbx_outputName.Enabled = true; }
            else { tbx_outputName.Enabled = false; tbx_outputName.Text = "output.txt"; }
        }

        private void previewFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try { Process.Start("notepad.exe", filePath); }
                catch (Exception ex) { MessageBox.Show("Error opening file: " + ex.Message); }
            }
            else { MessageBox.Show("File not found: " + filePath); }
        }

        private void btn_Identify_Click(object sender, EventArgs e)
        {
            string txtFilePath = tbx_txt.Text;
            string datFilePath = tbx_dat.Text;
            string outputPath = Path.Combine(tbx_out.Text, tbx_outputName.Text + ".txt");

            List<TxtJournal> txtJournals = ReadTxtJournals(txtFilePath);
            List<DatJournal> datJournals = ReadDatJournals(datFilePath);
            List<OutJournal> outJournals = CompareJournals(txtJournals, datJournals);

            if (WriteOutputToFile(outJournals, outputPath)) { MessageBox.Show($"Output written successfully to: {outputPath}"); }
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

            foreach (string line in lines.Skip(1))
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
                        string issn = "", eissn = "", title = "";
                        string issnMatch = "", eissnMatch = "", titleMatch = "";
                        if (!string.IsNullOrWhiteSpace(txtJournal.ISSN) || !string.IsNullOrWhiteSpace(datJournal.ISSN))
                        {
                            if (txtJournal.ISSN == " ")
                            {
                                issnMatch = "datonly";
                                issn = datJournal.ISSN;
                            }
                            else if (datJournal.ISSN == "")
                            {
                                issnMatch = "txtonly";
                                issn = txtJournal.ISSN;
                            }
                            else
                            {
                                if (datJournal.ISSN == txtJournal.ISSN)
                                {
                                    issnMatch = "match";
                                    issn = txtJournal.ISSN;
                                }
                                else
                                {
                                    issnMatch = "not match";
                                    issn = "";
                                }
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(txtJournal.eISSN) || !string.IsNullOrWhiteSpace(datJournal.eISSN))
                        {
                            if (txtJournal.eISSN == " ")
                            {
                                eissnMatch = "datonly";
                                eissn = datJournal.eISSN;
                            }
                            else if (datJournal.eISSN == "")
                            {
                                eissnMatch = "txtonly";
                                eissn = txtJournal.eISSN;
                            }
                            else
                            {
                                if (datJournal.eISSN == txtJournal.eISSN)
                                {
                                    eissnMatch = "match";
                                    eissn = txtJournal.eISSN;
                                }
                                else
                                {
                                    eissnMatch = "not match";
                                    eissn = "";
                                }
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(txtJournal.Title) || !string.IsNullOrWhiteSpace(datJournal.Title))
                        {
                            if (txtJournal.Title == " ")
                            {
                                titleMatch = "datonly";
                                title = datJournal.Title;
                            }
                            else if (datJournal.Title == "")
                            {
                                titleMatch = "txtonly";
                                title = txtJournal.Title;
                            }
                            else
                            {
                                if (datJournal.Title == txtJournal.Title)
                                {
                                    titleMatch = "match";
                                    title = txtJournal.Title;
                                }
                                else
                                {
                                    titleMatch = "not match";
                                    title = "";
                                }
                            }
                        }
                        outJournals.Add(new OutJournal
                        {
                            PAN = txtJournal.PAN,
                            ISSN = issn,
                            eISSN = eissn,
                            Title = title,
                            matchISSN = issnMatch,
                            matcheISSN = eissnMatch,
                            matchTitle = titleMatch
                        });
                        break;
                    }
                }
            }
            return outJournals;
        }

        static List<OutJournal> RemoveDuplicates(List<OutJournal> outJournals)
        {
            var distinctJournals = new List<OutJournal>();

            foreach (var journal in outJournals)
            {
                if (!distinctJournals.Any(j =>
                    j.Title == journal.Title &&
                    j.ISSN == journal.ISSN &&
                    j.eISSN == journal.eISSN &&
                    j.PAN != journal.PAN))
                {
                    distinctJournals.Add(journal);
                }
            }

            return distinctJournals;
        }

        static bool WriteOutputToFile(List<OutJournal> outJournals, string filePath)
        {
            try
            {
                outJournals = RemoveDuplicates(outJournals);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("PAN\tTitle\tISSN\teISSN");
                    foreach (OutJournal outJournal in outJournals)
                    {
                        writer.WriteLine($"{outJournal.PAN}\t{outJournal.matchTitle}\t{outJournal.matchISSN}\t{outJournal.matcheISSN}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
                return false;
            }
            return true;
        }
    }
}