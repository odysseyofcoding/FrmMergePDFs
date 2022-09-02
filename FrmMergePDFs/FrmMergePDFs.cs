using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrmMergePDFs
{
    public partial class FrmMergePDFs : Form
    {
        private List<string> pathsToFiles;
        private List<string> fileNames;
        private BindingSource bsFileNames;
        public FrmMergePDFs()
        {
            InitializeComponent();
        }
        private void FrmMergePDFs_Load(object sender, EventArgs e)
        {
            bsFileNames = new BindingSource();
            pathsToFiles = new List<string>();
            fileNames = new List<string>();
            bsFileNames.DataSource = fileNames;
            lbxPaths.DataSource = bsFileNames;
        }
        private void BtnAddPDF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdAddPDFs = new OpenFileDialog())
            {
                ofdAddPDFs.Filter = "(*.pdf)|*.pdf";
                ofdAddPDFs.RestoreDirectory = true;
                ofdAddPDFs.Multiselect = true;
                if (ofdAddPDFs.ShowDialog() == DialogResult.OK)
                {
                    ofdAddPDFs.FileNames.ToList().ForEach(filePath => pathsToFiles.Add(filePath));
                    ofdAddPDFs.SafeFileNames.ToList().ForEach(fileName => fileNames.Add(fileName));

                    bsFileNames.ResetBindings(false);
                }
            }
        }
        private void BtnMoveItemUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }
        private void BtnMoveItemDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }
        private void BtnMergePDFs_Click(object sender, EventArgs e)
        {
            if (fileNames.Count == 0)
            {
                MessageBox.Show("No files to merge, please select at least one file");
                return;
            }
            using (SaveFileDialog sfdSavePDF = new SaveFileDialog())
            {
                sfdSavePDF.Filter = "(*.pdf)|*.pdf";
                sfdSavePDF.RestoreDirectory = true;
                if (sfdSavePDF.ShowDialog() == DialogResult.OK)
                {
                    PdfDocument outpdf = new PdfDocument();
                    pathsToFiles.ForEach(path => CopyPages(PdfReader.Open(path, PdfDocumentOpenMode.Import), outpdf));

                    outpdf.Save(sfdSavePDF.FileName);

                    pathsToFiles.Clear();
                    fileNames.Clear();

                    bsFileNames.ResetBindings(false);
                    MessageBox.Show("Successfully merged");
                }
            }
        }
        private void MoveItem(int direction)
        {
            if (lbxPaths.SelectedItem == null || lbxPaths.SelectedIndex < 0) return;
            int newIndex = lbxPaths.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= lbxPaths.Items.Count) return;

            string selectedItem = lbxPaths.SelectedItem.ToString();
            fileNames.Remove(selectedItem);
            fileNames.Insert(newIndex, selectedItem);

            string temporary = pathsToFiles[lbxPaths.SelectedIndex];
            pathsToFiles.RemoveAt(lbxPaths.SelectedIndex);
            pathsToFiles.Insert(newIndex, temporary);

            lbxPaths.SetSelected(newIndex, true);
            bsFileNames.ResetBindings(false);
        }
        private void CopyPages(PdfDocument sourcePDF, PdfDocument toNewPDF)
        {
            for (int i = 0; i < sourcePDF.PageCount; i++)
            {
                toNewPDF.AddPage(sourcePDF.Pages[i]);
            }
        }
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lbxPaths.Items.Count == 0) return;
            if (QuestionAction($"Do You really want to delete {lbxPaths.SelectedItem}", "Delete") == DialogResult.No) return;
            fileNames.Remove(lbxPaths.SelectedItem.ToString());
            pathsToFiles.RemoveAt(lbxPaths.SelectedIndex);
            bsFileNames.ResetBindings(false);
        }
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            if (lbxPaths.Items.Count == 0) return;
            if (QuestionAction("Do You really want to delete all", "Delete") == DialogResult.No) return;
            fileNames.Clear();
            pathsToFiles.Clear();
            bsFileNames.ResetBindings(false);
        }
        private void FrmMergePDFs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lbxPaths.Items.Count == 0) return;
            if (QuestionAction("Do You really want to Quit and loose your collection?", "Quit") == DialogResult.No) e.Cancel = true;
        }
        private DialogResult QuestionAction(string question, string caption)
        {
            DialogResult result = MessageBox.Show(question, caption, MessageBoxButtons.YesNo);
            return result;
        }
    }
}