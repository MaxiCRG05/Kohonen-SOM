namespace SOM_Kohonen
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnProbar = new System.Windows.Forms.Button();
			this.imagen = new System.Windows.Forms.PictureBox();
			this.lblPrediccion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.mapaNeuronas = new System.Windows.Forms.PictureBox();
			this.lblInfo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mapaNeuronas)).BeginInit();
			this.SuspendLayout();
			// 
			// btnProbar
			// 
			this.btnProbar.Location = new System.Drawing.Point(12, 16);
			this.btnProbar.Name = "btnProbar";
			this.btnProbar.Size = new System.Drawing.Size(75, 23);
			this.btnProbar.TabIndex = 2;
			this.btnProbar.Text = "PROBAR";
			this.btnProbar.UseVisualStyleBackColor = true;
			this.btnProbar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnProbar_MouseClick);
			// 
			// imagen
			// 
			this.imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imagen.Cursor = System.Windows.Forms.Cursors.Cross;
			this.imagen.Image = global::SOM_Kohonen.Properties.Resources.color;
			this.imagen.Location = new System.Drawing.Point(12, 88);
			this.imagen.Name = "imagen";
			this.imagen.Size = new System.Drawing.Size(350, 350);
			this.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imagen.TabIndex = 5;
			this.imagen.TabStop = false;
			this.imagen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseClick);
			this.imagen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseDoubleClick);
			// 
			// lblPrediccion
			// 
			this.lblPrediccion.AutoSize = true;
			this.lblPrediccion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrediccion.Location = new System.Drawing.Point(542, 16);
			this.lblPrediccion.Name = "lblPrediccion";
			this.lblPrediccion.Size = new System.Drawing.Size(0, 19);
			this.lblPrediccion.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(453, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Predicción:";
			// 
			// mapaNeuronas
			// 
			this.mapaNeuronas.Location = new System.Drawing.Point(438, 103);
			this.mapaNeuronas.Name = "mapaNeuronas";
			this.mapaNeuronas.Size = new System.Drawing.Size(300, 300);
			this.mapaNeuronas.TabIndex = 7;
			this.mapaNeuronas.TabStop = false;
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(549, 21);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(82, 13);
			this.lblInfo.TabIndex = 8;
			this.lblInfo.Text = "                         ";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.mapaNeuronas);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.imagen);
			this.Controls.Add(this.lblPrediccion);
			this.Controls.Add(this.btnProbar);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mapaNeuronas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnProbar;
		private System.Windows.Forms.PictureBox imagen;
		private System.Windows.Forms.Label lblPrediccion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox mapaNeuronas;
		private System.Windows.Forms.Label lblInfo;
	}
}

