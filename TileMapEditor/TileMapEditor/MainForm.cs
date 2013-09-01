using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TileMapEditor
{
    public partial class MainForm : Form
    {
        private TileMap tileMap;
        private const int TH = 20;
        private const int MH = 32;
        private string fileName = null;

        public MainForm()
        {
            InitializeComponent();
            tsmiLayer.SelectedIndex = 0;
            tileMap = new TileMap((pCanvas as XNACanvas));
        }

        private void LoadTileset_Click(object sender, EventArgs e)
        {
            if (openTilesetDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openTilesetDialog.FileName;
                tileMap.Initialize(fileName);
                DrawTileset();
                pCanvas.Invalidate();
            }
        }

        private bool tileMouseDown = false;

        private void DrawTileset()
        {
            Bitmap tileset = tileMap.GetTilset();
            int width = pbTilesets.Width;
            int height = width * tileset.Height / tileset.Width;
            pbTilesets.Height = height;
            tileset = new Bitmap(tileset, width, height);
            if (pbTilesets.Image != null) pbTilesets.Image.Dispose();
            pbTilesets.Image = tileset;
        }

        private void pbTilesets_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / TH;
            int y = e.Y / TH;
            tileMap.SetTilePoint1(x, y);
            tileMap.SetTilePoint2(x, y);
            tileMouseDown = true;
            DrawTileset();
        }

        private void pbTilesets_MouseMove(object sender, MouseEventArgs e)
        {
            if (tileMouseDown)
            {
                int x = e.X / TH;
                int y = e.Y / TH;
                tileMap.SetTilePoint2(x, y);
                DrawTileset();
            }
        }

        private void pbTilesets_MouseUp(object sender, MouseEventArgs e)
        {
            tileMouseDown = false;
        }

        private bool mapMouseDown = false;

        private void pCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / MH;
            int y = e.Y / MH;
            if (e.Button == MouseButtons.Left)
            {
                tileMap.SetTile(x, y, 1);
                mapMouseDown = true;
            }
            if (e.Button == MouseButtons.Middle)
            {
                tileMap.FillArea(x, y);
            }
            if (e.Button == MouseButtons.Right)
            {
                tileMap.SetTile(x, y, 0);
                mapMouseDown = true;
            }
            pCanvas.Invalidate();
        }

        private void pCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mapMouseDown)
            {
                int x = e.X / MH;
                int y = e.Y / MH;
                if (e.Button == MouseButtons.Left)
                {
                    tileMap.SetTile(x, y, 1);
                }
                if (e.Button == MouseButtons.Right)
                {
                    tileMap.SetTile(x, y, 0);
                }
                pCanvas.Invalidate();
            }
        }

        private void pCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            mapMouseDown = false;
        }

        private void MapSize_Click(object sender, EventArgs e)
        {
            MapSizeForm form = new MapSizeForm(tileMap);
            form.ShowDialog();
            pCanvas.Invalidate();
        }

        private void ShowGrid_Click(object sender, EventArgs e)
        {
            tsbShowGrid.Checked = tsmiShowGrid.Checked = !tsbShowGrid.Checked;
            tileMap.SetShowGrid(tsbShowGrid.Checked);
            pCanvas.Invalidate();
        }

        private void tsmiToolBar_Click(object sender, EventArgs e)
        {
            tsmiToolBar.Checked = !tsmiToolBar.Checked;
            toolStrip.Visible = tsmiToolBar.Checked;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            tileMap.Clear();
            pCanvas.Invalidate();
        }

        private void rbPassability_CheckedChanged(object sender, EventArgs e)
        {
            pCanvas.Tag = "1";
            tileMap.SetTag(1);
            pCanvas.Invalidate();
        }

        private void rbGraphics_CheckedChanged(object sender, EventArgs e)
        {
            pCanvas.Tag = "0";
            tileMap.SetTag(0);
            pCanvas.Invalidate();
        }

        private void bViewBGImage_Click(object sender, EventArgs e)
        {
            if (openBGImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openBGImageDialog.FileName;
                tbBGImagePath.Text = fileName;
            }
        }

        private void bLoadBGImage_Click(object sender, EventArgs e)
        {
            tileMap.LoadBgImage(tbBGImagePath.Text);
            pCanvas.Invalidate();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tileMap.SaveToFile(saveFileDialog.FileName);
                fileName = saveFileDialog.FileName;
                Text = "TileMap Editor 2D [" + fileName + "]";
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tileMap.LoadFromFile(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
                Text = "TileMap Editor 2D [" + fileName + "]";
                pCanvas.Invalidate();
                DrawTileset();
            }
        }

        private void tsmiLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tileMap != null)
            {
                tileMap.SetLayer(tsmiLayer.SelectedIndex + 1);
                pCanvas.Invalidate();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                tileMap.SaveToFile(fileName);
            }
            else tsmiSaveAs_Click(null, null);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
