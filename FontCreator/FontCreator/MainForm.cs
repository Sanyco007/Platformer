using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace FontCreator
{
    public partial class MainForm : Form
    {
        private GraphicFont gFont = null;
        private string fileName = null;

        public MainForm()
        {
            InitializeComponent();
            InstalledFontCollection ifc = new InstalledFontCollection();
            FontFamily[] ff = ifc.Families;
            foreach (FontFamily f in ff)
            {
                cbFontList.Items.Add(f.Name);
                cbFontList.AutoCompleteCustomSource.Add(f.Name);
            }
            cbFontList.SelectedIndex = 7;
        }

        public void CreateFontObject()
        {
            gFont = new GraphicFont();
        }

        private void bDraw_Click(object sender, EventArgs e)
        {
            FontStyle style = FontStyle.Regular;
            if (cbB.Checked) style = style | FontStyle.Bold;
            if (cbI.Checked) style = style | FontStyle.Italic;
            try
            {
                gFont.SetFont(cbFontList.Text, Int32.Parse(tbFontSize.Text), style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Bitmap res = gFont.GetBitmap(tbPreviewText.Text);
            if (pbFont.Image != null) pbFont.Image.Dispose();
            pbFont.Width = res.Width;
            pbFont.Height = res.Height;
            pbFont.Image = res;
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                gFont.LoadFromFile(openFileDialog.FileName);
                tbFontSize.Text = gFont.GetWidth().ToString();
                cbFontList.Text = gFont.GetFontFamily();
                FontStyle fs = gFont.GetStyle();
                if ((fs & FontStyle.Bold) == FontStyle.Bold) cbB.Checked = true;
                else cbB.Checked = false;
                if ((fs & FontStyle.Italic) == FontStyle.Italic) cbI.Checked = true;
                else cbI.Checked = false;
                fileName = openFileDialog.FileName;
                Text = "Редактор шрифтов [" + fileName + "]";
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                tsmiSaveAs_Click(null, null);
            }
            else gFont.SaveToFile(fileName);
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                gFont.SaveToFile(saveFileDialog.FileName);
                fileName = saveFileDialog.FileName;
                Text = "Редактор шрифтов [" + fileName + "]";
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
