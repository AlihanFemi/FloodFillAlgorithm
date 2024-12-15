using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class ImageSelection : Form
    {
        public ImageSelection()
        {
            InitializeComponent();
            LoadImages();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (imageView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select an image!");
                return;
            }
            ListViewItem selectedImage = imageView.SelectedItems[0];

            State.originalImage = (Bitmap)ImageList.Images[selectedImage.ImageKey];
            State.canvas = (Bitmap)ImageList.Images[selectedImage.ImageKey];

            this.Close();
        }
        private void LoadImages()
        {
            ImageList.Images.Add("BigShape", Image.FromFile("../../images/BigShape.png"));
            ImageList.Images.Add("Broken", Image.FromFile("../../images/Broken.png"));
            ImageList.Images.Add("SmallShape", Image.FromFile("../../images/SmallShape.png"));
            ImageList.Images.Add("SmallShapeBroken", Image.FromFile("../../images/SmallShapeBroken.png"));


            imageView.Items.Add(new ListViewItem("Big Shape", "BigShape"));
            imageView.Items.Add(new ListViewItem("Broken", "Broken"));
            imageView.Items.Add(new ListViewItem("Small Shape", "SmallShape"));
            imageView.Items.Add(new ListViewItem("Small Shape Broken", "SmallShapeBroken"));
        }
    }
}
