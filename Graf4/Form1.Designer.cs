namespace Graf4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioDot = new System.Windows.Forms.RadioButton();
            this.radioEdge = new System.Windows.Forms.RadioButton();
            this.radioSquare = new System.Windows.Forms.RadioButton();
            this.buttonReset = new System.Windows.Forms.Button();
            this.intersection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(677, 520);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // radioDot
            // 
            this.radioDot.AutoSize = true;
            this.radioDot.Location = new System.Drawing.Point(773, 22);
            this.radioDot.Margin = new System.Windows.Forms.Padding(2);
            this.radioDot.Name = "radioDot";
            this.radioDot.Size = new System.Drawing.Size(55, 17);
            this.radioDot.TabIndex = 1;
            this.radioDot.TabStop = true;
            this.radioDot.Text = "Точка";
            this.radioDot.UseVisualStyleBackColor = true;
            // 
            // radioEdge
            // 
            this.radioEdge.AutoSize = true;
            this.radioEdge.Location = new System.Drawing.Point(773, 44);
            this.radioEdge.Margin = new System.Windows.Forms.Padding(2);
            this.radioEdge.Name = "radioEdge";
            this.radioEdge.Size = new System.Drawing.Size(68, 17);
            this.radioEdge.TabIndex = 2;
            this.radioEdge.TabStop = true;
            this.radioEdge.Text = "Отрезок";
            this.radioEdge.UseVisualStyleBackColor = true;
            // 
            // radioSquare
            // 
            this.radioSquare.AutoSize = true;
            this.radioSquare.Location = new System.Drawing.Point(773, 67);
            this.radioSquare.Margin = new System.Windows.Forms.Padding(2);
            this.radioSquare.Name = "radioSquare";
            this.radioSquare.Size = new System.Drawing.Size(68, 17);
            this.radioSquare.TabIndex = 3;
            this.radioSquare.TabStop = true;
            this.radioSquare.Text = "Полигон";
            this.radioSquare.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(773, 510);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(86, 24);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Очистить";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // intersection
            // 
            this.intersection.Location = new System.Drawing.Point(773, 482);
            this.intersection.Name = "intersection";
            this.intersection.Size = new System.Drawing.Size(86, 23);
            this.intersection.TabIndex = 5;
            this.intersection.Text = "Intersection";
            this.intersection.UseVisualStyleBackColor = true;
            this.intersection.Click += new System.EventHandler(this.Intersection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(728, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intersection);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.radioSquare);
            this.Controls.Add(this.radioEdge);
            this.Controls.Add(this.radioDot);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioDot;
        private System.Windows.Forms.RadioButton radioEdge;
        private System.Windows.Forms.RadioButton radioSquare;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button intersection;
        private System.Windows.Forms.Label label1;
    }
}

