using System.Windows.Forms.VisualStyles;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI
{
    public class DataGridViewImageButtonCell : DataGridViewButtonCell
    {
        private bool _enabled;                // Is the button enabled
        private PushButtonState _buttonState; // What is the button state
        protected Image LocalButtonImageHot;      // The hot image
        protected Image LocalButtonImageNormal;   // The normal image
        protected Image LocalButtonImageDisabled; // The disabled image
        private int LocalButtonImageOffset;       // The amount of offset or border around the image

        public Image ImageHot
        {
            get { return this.LocalButtonImageHot; }
            set { this.LocalButtonImageHot = value; }
        }

        public Image ImageNormal
        {
            get { return this.LocalButtonImageNormal; }
            set { this.LocalButtonImageNormal = value; }
        }

        public Image ImageDisabled
        {
            get { return this.LocalButtonImageDisabled; }
            set { this.LocalButtonImageDisabled = value; }
        }

        public DataGridViewImageButtonCell()
        {
            // In my project, buttons are disabled by default
            _enabled = false;
            _buttonState = PushButtonState.Normal;

            // Changing this value affects the appearance of the image on the button.
            LocalButtonImageOffset = 2;
        }

        // Button Enabled Property
        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
                _buttonState = value ? PushButtonState.Normal : PushButtonState.Disabled;
            }
        }

        // PushButton State Property
        public PushButtonState ButtonState
        {
            get { return _buttonState; }
            set { _buttonState = value; }
        }

        // Image Property
        // Returns the correct image based on the control's state.
        public Image ButtonImage
        {
            get
            {
                Image ImagineCorecta = LocalButtonImageNormal;
                switch (_buttonState)
                {
                    case PushButtonState.Disabled:
                        ImagineCorecta = LocalButtonImageNormal; //_buttonImageDisabled;
                        break;
                    case PushButtonState.Hot:
                        ImagineCorecta = LocalButtonImageNormal; //_buttonImageHot;
                        break;
                    case PushButtonState.Normal:
                        ImagineCorecta = LocalButtonImageNormal;
                        break;
                    case PushButtonState.Pressed:
                        ImagineCorecta = LocalButtonImageNormal;
                        break;
                    case PushButtonState.Default:
                        ImagineCorecta = LocalButtonImageNormal;
                        break;
                    default:
                        ImagineCorecta = LocalButtonImageNormal;
                        break;
                }
                return ImagineCorecta;
            }
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            //base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // Draw the cell background, if specified.
            if ((paintParts & DataGridViewPaintParts.Background) ==
                DataGridViewPaintParts.Background)
            {
                SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);

                if (this.OwningRow.Selected)
                {
                    cellBackground = new SolidBrush(cellStyle.SelectionBackColor);
                }

                graphics.FillRectangle(cellBackground, cellBounds);
                cellBackground.Dispose();
            }

            // Draw the cell borders, if specified.
            if ((paintParts & DataGridViewPaintParts.Border) ==
                DataGridViewPaintParts.Border)
            {
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                    advancedBorderStyle);
            }

            //Daca nu avem imagine atunci nu desenam butonul
            if (ButtonImage != null)
            {
                // Calculate the area in which to draw the button.
                // Adjusting the following algorithm and values affects
                // how the image will appear on the button.
                Rectangle buttonArea = cellBounds;

                Rectangle buttonAdjustment =
                    BorderWidths(advancedBorderStyle);

                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                Rectangle imageArea = new Rectangle(
                    buttonArea.X + buttonArea.Width / 2 - 8 + LocalButtonImageOffset,
                    buttonArea.Y + LocalButtonImageOffset,
                    16,
                    16);

                ButtonRenderer.DrawButton(graphics, buttonArea, ButtonImage, imageArea, false, ButtonState);
            }
        }

        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
            this.ButtonState = PushButtonState.Pressed;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            this.ButtonState = PushButtonState.Normal;
            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(int rowIndex)
        {
            this.ButtonState = PushButtonState.Normal;
            base.OnMouseEnter(rowIndex);
        }

        protected override void OnMouseLeave(int rowIndex)
        {
            this.ButtonState = PushButtonState.Normal;
            base.OnMouseLeave(rowIndex);
        }
    }
}
