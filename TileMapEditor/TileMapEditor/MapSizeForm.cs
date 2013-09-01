using System;
using System.Globalization;
using System.Windows.Forms;

namespace TileMapEditor
{
    public partial class MapSizeForm : Form
    {
        private readonly TileMap _tileMap;

        public MapSizeForm(TileMap tileMap)
        {
            _tileMap = tileMap;
            InitializeComponent();
            tbWidth.Text = tileMap.GetSize().Width.ToString(CultureInfo.InvariantCulture);
            tbHeight.Text = tileMap.GetSize().Height.ToString(CultureInfo.InvariantCulture);
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            try
            {
                width = Int32.Parse(tbWidth.Text);
                height = Int32.Parse(tbHeight.Text);
            }
            catch { return; }
            _tileMap.Resize(width, height);
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
