namespace GameOfLife
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxGrid = new System.Windows.Forms.PictureBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.NumericPace = new System.Windows.Forms.NumericUpDown();
            this.randBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGrid
            // 
            this.pictureBoxGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGrid.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxGrid.Name = "pictureBoxGrid";
            this.pictureBoxGrid.Size = new System.Drawing.Size(864, 666);
            this.pictureBoxGrid.TabIndex = 0;
            this.pictureBoxGrid.TabStop = false;
            this.pictureBoxGrid.SizeChanged += new System.EventHandler(this.PictureBoxGrid_SizeChanged);
            this.pictureBoxGrid.Click += new System.EventHandler(this.PictureBoxGrid_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartBtn.Location = new System.Drawing.Point(12, 684);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(402, 40);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // NumericPace
            // 
            this.NumericPace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericPace.Location = new System.Drawing.Point(756, 692);
            this.NumericPace.Name = "NumericPace";
            this.NumericPace.Size = new System.Drawing.Size(120, 26);
            this.NumericPace.TabIndex = 2;
            this.NumericPace.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericPace.ValueChanged += new System.EventHandler(this.NumericPace_ValueChanged);
            // 
            // randBtn
            // 
            this.randBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.randBtn.Location = new System.Drawing.Point(587, 684);
            this.randBtn.Name = "randBtn";
            this.randBtn.Size = new System.Drawing.Size(163, 40);
            this.randBtn.TabIndex = 3;
            this.randBtn.Text = "Randomize";
            this.randBtn.UseVisualStyleBackColor = true;
            this.randBtn.Click += new System.EventHandler(this.RandBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.Location = new System.Drawing.Point(421, 685);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(160, 39);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 736);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.randBtn);
            this.Controls.Add(this.NumericPace);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.pictureBoxGrid);
            this.Name = "MainForm";
            this.Text = "Game of Life";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGrid;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.NumericUpDown NumericPace;
        private System.Windows.Forms.Button randBtn;
        private System.Windows.Forms.Button clearBtn;
    }
}

