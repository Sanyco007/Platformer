namespace TileMapEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMapSize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadTileset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnimation = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMapSize = new System.Windows.Forms.ToolStripButton();
            this.tsnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadTileset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLayer = new System.Windows.Forms.ToolStripComboBox();
            this.pTilesField = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPassability = new System.Windows.Forms.RadioButton();
            this.rbGraphics = new System.Windows.Forms.RadioButton();
            this.pTilesScroll = new System.Windows.Forms.Panel();
            this.pbTilesets = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pEditField = new System.Windows.Forms.Panel();
            this.pCanvas = new TileMapEditor.XNACanvas();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMap = new System.Windows.Forms.TabPage();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.bLoadBGImage = new System.Windows.Forms.Button();
            this.bViewBGImage = new System.Windows.Forms.Button();
            this.tbBGImagePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openTilesetDialog = new System.Windows.Forms.OpenFileDialog();
            this.openBGImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.pTilesField.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pTilesScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTilesets)).BeginInit();
            this.pEditField.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpMap.SuspendLayout();
            this.tpOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit,
            this.tsmiView,
            this.tsmiGraphics});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(714, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiSeparator1,
            this.tsmiSave,
            this.tsmiSaveAs,
            this.tsmiSeparator2,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(162, 22);
            this.tsmiOpen.Text = "Открыть";
            this.tsmiOpen.Click += new System.EventHandler(this.Open_Click);
            // 
            // tsmiSeparator1
            // 
            this.tsmiSeparator1.Name = "tsmiSeparator1";
            this.tsmiSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(162, 22);
            this.tsmiSave.Text = "Сохранить";
            this.tsmiSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Size = new System.Drawing.Size(162, 22);
            this.tsmiSaveAs.Text = "Сохранить как...";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
            // 
            // tsmiSeparator2
            // 
            this.tsmiSeparator2.Name = "tsmiSeparator2";
            this.tsmiSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(162, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClear,
            this.tsmiSeparator3,
            this.tsmiMapSize});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(59, 20);
            this.tsmiEdit.Text = "Правка";
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(150, 22);
            this.tsmiClear.Text = "Очистить";
            this.tsmiClear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // tsmiSeparator3
            // 
            this.tsmiSeparator3.Name = "tsmiSeparator3";
            this.tsmiSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // tsmiMapSize
            // 
            this.tsmiMapSize.Name = "tsmiMapSize";
            this.tsmiMapSize.Size = new System.Drawing.Size(150, 22);
            this.tsmiMapSize.Text = "Размер карты";
            this.tsmiMapSize.Click += new System.EventHandler(this.MapSize_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowGrid,
            this.tsmiSeparator4,
            this.tsmiToolBar});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(39, 20);
            this.tsmiView.Text = "Вид";
            // 
            // tsmiShowGrid
            // 
            this.tsmiShowGrid.Checked = true;
            this.tsmiShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiShowGrid.Name = "tsmiShowGrid";
            this.tsmiShowGrid.Size = new System.Drawing.Size(196, 22);
            this.tsmiShowGrid.Text = "Отображать сетку";
            this.tsmiShowGrid.Click += new System.EventHandler(this.ShowGrid_Click);
            // 
            // tsmiSeparator4
            // 
            this.tsmiSeparator4.Name = "tsmiSeparator4";
            this.tsmiSeparator4.Size = new System.Drawing.Size(193, 6);
            // 
            // tsmiToolBar
            // 
            this.tsmiToolBar.Checked = true;
            this.tsmiToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiToolBar.Name = "tsmiToolBar";
            this.tsmiToolBar.Size = new System.Drawing.Size(196, 22);
            this.tsmiToolBar.Text = "Панель инструментов";
            this.tsmiToolBar.Click += new System.EventHandler(this.tsmiToolBar_Click);
            // 
            // tsmiGraphics
            // 
            this.tsmiGraphics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadTileset,
            this.tsmiAnimation});
            this.tsmiGraphics.Name = "tsmiGraphics";
            this.tsmiGraphics.Size = new System.Drawing.Size(66, 20);
            this.tsmiGraphics.Text = "Графика";
            // 
            // tsmiLoadTileset
            // 
            this.tsmiLoadTileset.Name = "tsmiLoadTileset";
            this.tsmiLoadTileset.Size = new System.Drawing.Size(165, 22);
            this.tsmiLoadTileset.Text = "Загрузить блоки";
            this.tsmiLoadTileset.Click += new System.EventHandler(this.LoadTileset_Click);
            // 
            // tsmiAnimation
            // 
            this.tsmiAnimation.Name = "tsmiAnimation";
            this.tsmiAnimation.Size = new System.Drawing.Size(165, 22);
            this.tsmiAnimation.Text = "Анимация";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(714, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbMapSize,
            this.tsnClear,
            this.toolStripSeparator2,
            this.tsbShowGrid,
            this.toolStripSeparator3,
            this.tsbLoadTileset,
            this.toolStripSeparator4,
            this.tsmiLayer});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(714, 25);
            this.toolStrip.TabIndex = 2;
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Margin = new System.Windows.Forms.Padding(3, 1, 2, 2);
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "Открыть";
            this.tsbOpen.Click += new System.EventHandler(this.Open_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Margin = new System.Windows.Forms.Padding(3, 1, 2, 2);
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Сохранить";
            this.tsbSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMapSize
            // 
            this.tsbMapSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMapSize.Image = ((System.Drawing.Image)(resources.GetObject("tsbMapSize.Image")));
            this.tsbMapSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMapSize.Margin = new System.Windows.Forms.Padding(3, 1, 2, 2);
            this.tsbMapSize.Name = "tsbMapSize";
            this.tsbMapSize.Size = new System.Drawing.Size(23, 22);
            this.tsbMapSize.Text = "Размер карты";
            this.tsbMapSize.Click += new System.EventHandler(this.MapSize_Click);
            // 
            // tsnClear
            // 
            this.tsnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsnClear.Image")));
            this.tsnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsnClear.Margin = new System.Windows.Forms.Padding(3, 1, 2, 2);
            this.tsnClear.Name = "tsnClear";
            this.tsnClear.Size = new System.Drawing.Size(23, 22);
            this.tsnClear.Text = "Очистить";
            this.tsnClear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbShowGrid
            // 
            this.tsbShowGrid.Checked = true;
            this.tsbShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowGrid.Image")));
            this.tsbShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowGrid.Margin = new System.Windows.Forms.Padding(3, 1, 2, 2);
            this.tsbShowGrid.Name = "tsbShowGrid";
            this.tsbShowGrid.Size = new System.Drawing.Size(23, 22);
            this.tsbShowGrid.Text = "Отображать сетку";
            this.tsbShowGrid.Click += new System.EventHandler(this.ShowGrid_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLoadTileset
            // 
            this.tsbLoadTileset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadTileset.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadTileset.Image")));
            this.tsbLoadTileset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadTileset.Margin = new System.Windows.Forms.Padding(3, 1, 2, 2);
            this.tsbLoadTileset.Name = "tsbLoadTileset";
            this.tsbLoadTileset.Size = new System.Drawing.Size(23, 22);
            this.tsbLoadTileset.Text = "Загрузка блоков";
            this.tsbLoadTileset.Click += new System.EventHandler(this.LoadTileset_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsmiLayer
            // 
            this.tsmiLayer.AutoCompleteCustomSource.AddRange(new string[] {
            "Слой 1",
            "Слой 2"});
            this.tsmiLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsmiLayer.Items.AddRange(new object[] {
            "Слой 1",
            "Слой 2"});
            this.tsmiLayer.MergeIndex = 0;
            this.tsmiLayer.Name = "tsmiLayer";
            this.tsmiLayer.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsmiLayer.Size = new System.Drawing.Size(121, 25);
            this.tsmiLayer.SelectedIndexChanged += new System.EventHandler(this.tsmiLayer_SelectedIndexChanged);
            // 
            // pTilesField
            // 
            this.pTilesField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTilesField.Controls.Add(this.groupBox1);
            this.pTilesField.Controls.Add(this.pTilesScroll);
            this.pTilesField.Controls.Add(this.label1);
            this.pTilesField.Dock = System.Windows.Forms.DockStyle.Left;
            this.pTilesField.Location = new System.Drawing.Point(0, 49);
            this.pTilesField.Name = "pTilesField";
            this.pTilesField.Size = new System.Drawing.Size(196, 390);
            this.pTilesField.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rbPassability);
            this.groupBox1.Controls.Add(this.rbGraphics);
            this.groupBox1.Location = new System.Drawing.Point(8, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование";
            // 
            // rbPassability
            // 
            this.rbPassability.AutoSize = true;
            this.rbPassability.Location = new System.Drawing.Point(15, 42);
            this.rbPassability.Name = "rbPassability";
            this.rbPassability.Size = new System.Drawing.Size(132, 17);
            this.rbPassability.TabIndex = 1;
            this.rbPassability.Text = "Проходимые участки";
            this.rbPassability.UseVisualStyleBackColor = true;
            this.rbPassability.CheckedChanged += new System.EventHandler(this.rbPassability_CheckedChanged);
            // 
            // rbGraphics
            // 
            this.rbGraphics.AutoSize = true;
            this.rbGraphics.Checked = true;
            this.rbGraphics.Location = new System.Drawing.Point(15, 19);
            this.rbGraphics.Name = "rbGraphics";
            this.rbGraphics.Size = new System.Drawing.Size(107, 17);
            this.rbGraphics.TabIndex = 0;
            this.rbGraphics.TabStop = true;
            this.rbGraphics.Text = "Графика уровня";
            this.rbGraphics.UseVisualStyleBackColor = true;
            this.rbGraphics.CheckedChanged += new System.EventHandler(this.rbGraphics_CheckedChanged);
            // 
            // pTilesScroll
            // 
            this.pTilesScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pTilesScroll.AutoScroll = true;
            this.pTilesScroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTilesScroll.Controls.Add(this.pbTilesets);
            this.pTilesScroll.Location = new System.Drawing.Point(8, 31);
            this.pTilesScroll.Name = "pTilesScroll";
            this.pTilesScroll.Size = new System.Drawing.Size(181, 269);
            this.pTilesScroll.TabIndex = 1;
            // 
            // pbTilesets
            // 
            this.pbTilesets.Location = new System.Drawing.Point(0, 0);
            this.pbTilesets.Margin = new System.Windows.Forms.Padding(0);
            this.pbTilesets.Name = "pbTilesets";
            this.pbTilesets.Size = new System.Drawing.Size(160, 0);
            this.pbTilesets.TabIndex = 0;
            this.pbTilesets.TabStop = false;
            this.pbTilesets.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTilesets_MouseDown);
            this.pbTilesets.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbTilesets_MouseMove);
            this.pbTilesets.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbTilesets_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Блоки:";
            // 
            // pEditField
            // 
            this.pEditField.AutoScroll = true;
            this.pEditField.BackColor = System.Drawing.Color.Transparent;
            this.pEditField.Controls.Add(this.pCanvas);
            this.pEditField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEditField.Location = new System.Drawing.Point(0, 0);
            this.pEditField.Margin = new System.Windows.Forms.Padding(0);
            this.pEditField.Name = "pEditField";
            this.pEditField.Size = new System.Drawing.Size(510, 364);
            this.pEditField.TabIndex = 4;
            // 
            // pCanvas
            // 
            this.pCanvas.Location = new System.Drawing.Point(0, 0);
            this.pCanvas.Name = "pCanvas";
            this.pCanvas.Size = new System.Drawing.Size(160, 160);
            this.pCanvas.TabIndex = 0;
            this.pCanvas.Tag = "0";
            this.pCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pCanvas_MouseDown);
            this.pCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pCanvas_MouseMove);
            this.pCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pCanvas_MouseUp);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMap);
            this.tabControl.Controls.Add(this.tpOther);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(196, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(518, 390);
            this.tabControl.TabIndex = 5;
            // 
            // tpMap
            // 
            this.tpMap.Controls.Add(this.pEditField);
            this.tpMap.Location = new System.Drawing.Point(4, 22);
            this.tpMap.Margin = new System.Windows.Forms.Padding(0);
            this.tpMap.Name = "tpMap";
            this.tpMap.Size = new System.Drawing.Size(510, 364);
            this.tpMap.TabIndex = 0;
            this.tpMap.Text = "Графика";
            this.tpMap.UseVisualStyleBackColor = true;
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.bLoadBGImage);
            this.tpOther.Controls.Add(this.bViewBGImage);
            this.tpOther.Controls.Add(this.tbBGImagePath);
            this.tpOther.Controls.Add(this.label2);
            this.tpOther.Location = new System.Drawing.Point(4, 22);
            this.tpOther.Margin = new System.Windows.Forms.Padding(0);
            this.tpOther.Name = "tpOther";
            this.tpOther.Size = new System.Drawing.Size(510, 364);
            this.tpOther.TabIndex = 1;
            this.tpOther.Text = "Дополнительно";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // bLoadBGImage
            // 
            this.bLoadBGImage.Location = new System.Drawing.Point(19, 51);
            this.bLoadBGImage.Name = "bLoadBGImage";
            this.bLoadBGImage.Size = new System.Drawing.Size(104, 23);
            this.bLoadBGImage.TabIndex = 3;
            this.bLoadBGImage.Text = "Применить";
            this.bLoadBGImage.UseVisualStyleBackColor = true;
            this.bLoadBGImage.Click += new System.EventHandler(this.bLoadBGImage_Click);
            // 
            // bViewBGImage
            // 
            this.bViewBGImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bViewBGImage.Location = new System.Drawing.Point(435, 17);
            this.bViewBGImage.Name = "bViewBGImage";
            this.bViewBGImage.Size = new System.Drawing.Size(50, 23);
            this.bViewBGImage.TabIndex = 2;
            this.bViewBGImage.Text = "...";
            this.bViewBGImage.UseVisualStyleBackColor = true;
            this.bViewBGImage.Click += new System.EventHandler(this.bViewBGImage_Click);
            // 
            // tbBGImagePath
            // 
            this.tbBGImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBGImagePath.Location = new System.Drawing.Point(129, 19);
            this.tbBGImagePath.Name = "tbBGImagePath";
            this.tbBGImagePath.Size = new System.Drawing.Size(295, 20);
            this.tbBGImagePath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Фоновая картинка:";
            // 
            // openTilesetDialog
            // 
            this.openTilesetDialog.DefaultExt = "*.png";
            this.openTilesetDialog.Filter = "Файл изображения|*.png";
            // 
            // openBGImageDialog
            // 
            this.openBGImageDialog.DefaultExt = "png";
            this.openBGImageDialog.Filter = "Файл изображения|*.png";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "tls";
            this.saveFileDialog.Filter = "Файл уровня (*.tls)|*.tls";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "tls";
            this.openFileDialog.Filter = "Файл уровня (*.tls)|*.tls";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 461);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pTilesField);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TileMap Editor 2D";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pTilesField.ResumeLayout(false);
            this.pTilesField.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pTilesScroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTilesets)).EndInit();
            this.pEditField.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpMap.ResumeLayout(false);
            this.tpOther.ResumeLayout(false);
            this.tpOther.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel pTilesField;
        private System.Windows.Forms.Panel pEditField;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator tsmiSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripSeparator tsmiSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.ToolStripSeparator tsmiSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapSize;
        private System.Windows.Forms.ToolStripMenuItem tsmiGraphics;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadTileset;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowGrid;
        private System.Windows.Forms.ToolStripSeparator tsmiSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolBar;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsnClear;
        private System.Windows.Forms.ToolStripButton tsbMapSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbLoadTileset;
        private System.Windows.Forms.ToolStripButton tsbShowGrid;
        private System.Windows.Forms.Panel pTilesScroll;
        private System.Windows.Forms.PictureBox pbTilesets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMap;
        private System.Windows.Forms.OpenFileDialog openTilesetDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPassability;
        private System.Windows.Forms.RadioButton rbGraphics;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.Button bViewBGImage;
        private System.Windows.Forms.TextBox tbBGImagePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bLoadBGImage;
        private System.Windows.Forms.OpenFileDialog openBGImageDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnimation;
        private System.Windows.Forms.ToolStripComboBox tsmiLayer;
        private XNACanvas pCanvas;
 
    }
}

