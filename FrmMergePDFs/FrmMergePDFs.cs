using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FrmMergePDFs
{
    public partial class FrmMergePDFs : Form
    {
        private List<FileInfo> pathsToFiles;
        private BindingSource bsPathsToFiles;
        public FrmMergePDFs()
        {
            InitializeComponent();
        }
        private void FrmMergePDFs_Load(object sender, EventArgs e)
        {
            pathsToFiles = new List<FileInfo>();
            bsPathsToFiles = new BindingSource { DataSource = pathsToFiles };
            lbxPaths.DataSource = bsPathsToFiles;
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
                    ofdAddPDFs.FileNames.ToList().ForEach(fileName => pathsToFiles.Add(new FileInfo(fileName)));
                    bsPathsToFiles.ResetBindings(false);
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
            if (pathsToFiles.Count == 0)
            {
                MessageBox.Show("No files to merge, please select at least one file!", "Error!");
                return;
            }
            using (SaveFileDialog sfdSavePDF = new SaveFileDialog())
            {
                sfdSavePDF.Filter = "(*.pdf)|*.pdf";
                sfdSavePDF.RestoreDirectory = true;
                if (sfdSavePDF.ShowDialog() == DialogResult.OK)
                {
                    PdfDocument outpdf = new PdfDocument();

                    pathsToFiles.ForEach(path => CopyPages(PdfReader.Open(path.FullName, PdfDocumentOpenMode.Import), outpdf));

                    outpdf.Save(sfdSavePDF.FileName);

                    if (QuestionAction("Successfully merged!\n\nDo You want to keep the selection?", "Result") == DialogResult.Yes) return;

                    pathsToFiles.Clear();

                    bsPathsToFiles.ResetBindings(false);
                }
            }
        }
        private void MoveItem(int direction)
        {
            if (lbxPaths.SelectedItem == null || lbxPaths.SelectedIndex < 0) return;
            int newIndex = lbxPaths.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= lbxPaths.Items.Count) return;

            FileInfo temporary = pathsToFiles[lbxPaths.SelectedIndex];
            pathsToFiles.RemoveAt(lbxPaths.SelectedIndex);
            pathsToFiles.Insert(newIndex, temporary);

            lbxPaths.SetSelected(newIndex, true);
            bsPathsToFiles.ResetBindings(false);
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
            if (QuestionAction($"Do You really want to delete {Path.GetFileName(lbxPaths.SelectedItem.ToString())} ?", "Delete") == DialogResult.No) return;
            pathsToFiles.RemoveAt(lbxPaths.SelectedIndex);
            bsPathsToFiles.ResetBindings(false);
        }
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            if (lbxPaths.Items.Count == 0) return;
            if (QuestionAction("Do You really want to delete all?", "Delete") == DialogResult.No) return;
            pathsToFiles.Clear();
            bsPathsToFiles.ResetBindings(false);
        }
        private void FrmMergePDFs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lbxPaths.Items.Count == 0) return;
            if (QuestionAction("Do You really want to Quit and loose your collection?", "Quit") == DialogResult.No) e.Cancel = true;
        }
        private DialogResult QuestionAction(string question, string caption)
        {
            return MessageBox.Show(question, caption, MessageBoxButtons.YesNo);
        }
    }
}