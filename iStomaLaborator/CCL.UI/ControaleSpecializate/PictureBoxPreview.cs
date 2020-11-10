using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI.ControaleSpecializate
{
    [DefaultEvent("Afiseaza")]
    public sealed class PictureBoxPreview : UserControl
    {
        private PictureBoxPersonalizat picPreview;
        private IContainer components;
        private bool lEsteSelectat = false;

        public event ImagineDelegate Afiseaza;
        public delegate void ImagineDelegate(PictureBoxPreview pSender, Image pImagine);

        public Image Image
        {
            get { return this.picPreview.Image; }
            set { this.picPreview.Image = value; }
        }

        public PictureBoxSizeMode SizeMode
        {
            get { return this.picPreview.SizeMode; }
            set { this.picPreview.SizeMode = value; }
        }

        public bool Selectat
        {
            get { return this.lEsteSelectat; }
        }

        public PictureBoxPreview()
        {
            InitializeComponent();

            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColor = Color.Black;
            this.picPreview.BackColor = Color.Black;
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        public void EsteSelectata(bool pSelectat)
        {
            this.lEsteSelectat = pSelectat;

            if (pSelectat)
                this.BackColor = Color.Yellow;
            else
                this.BackColor = Color.Black;
        }

        private void picPreview_Click(object sender, EventArgs e)
        {
            if (this.Afiseaza != null)
                Afiseaza(this, this.picPreview.Image);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picPreview = new CCL.UI.PictureBoxPersonalizat(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.BackColor = System.Drawing.Color.Black;
            this.picPreview.ContinutToolTip = null;
            this.picPreview.IcoanaToolTip = System.Windows.Forms.ToolTipIcon.Info;
            this.picPreview.Location = new System.Drawing.Point(1, 1);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(148, 148);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.TitluToolTip = "";
            this.picPreview.UtilizamToolTip = false;
            this.picPreview.Click += new System.EventHandler(this.picPreview_Click);
            // 
            // PictureBoxPreview
            // 
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.picPreview);
            this.Name = "PictureBoxPreview";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

        }

        public void Initializeaza(Image pImagineOriginala)
        {
            this.picPreview.BackColor = Color.Black;
            this.picPreview.SizeMode = PictureBoxSizeMode.CenterImage;
            this.picPreview.Image = CCL.UI.Imagini.GetThumbnailImage(pImagineOriginala, this.picPreview.Width, this.picPreview.Height, true);
        }
    }
}
