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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.graficaSOM = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.btnEntrenar = new System.Windows.Forms.Button();
			this.btnProbar = new System.Windows.Forms.Button();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.imagen = new System.Windows.Forms.PictureBox();
			this.lblPrediccion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.graficaSOM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
			this.SuspendLayout();
			// 
			// graficaSOM
			// 
			chartArea11.Name = "ChartArea1";
			this.graficaSOM.ChartAreas.Add(chartArea11);
			legend11.Name = "Legend1";
			this.graficaSOM.Legends.Add(legend11);
			this.graficaSOM.Location = new System.Drawing.Point(457, 116);
			this.graficaSOM.Name = "graficaSOM";
			series11.ChartArea = "ChartArea1";
			series11.Legend = "Legend1";
			series11.Name = "Series1";
			this.graficaSOM.Series.Add(series11);
			this.graficaSOM.Size = new System.Drawing.Size(300, 300);
			this.graficaSOM.TabIndex = 0;
			this.graficaSOM.Text = "graficaSOM";
			// 
			// btnEntrenar
			// 
			this.btnEntrenar.Location = new System.Drawing.Point(12, 12);
			this.btnEntrenar.Name = "btnEntrenar";
			this.btnEntrenar.Size = new System.Drawing.Size(75, 23);
			this.btnEntrenar.TabIndex = 1;
			this.btnEntrenar.Text = "ENTRENAR";
			this.btnEntrenar.UseVisualStyleBackColor = true;
			this.btnEntrenar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnEntrenar_MouseClick);
			// 
			// btnProbar
			// 
			this.btnProbar.Location = new System.Drawing.Point(12, 41);
			this.btnProbar.Name = "btnProbar";
			this.btnProbar.Size = new System.Drawing.Size(75, 23);
			this.btnProbar.TabIndex = 2;
			this.btnProbar.Text = "PROBAR";
			this.btnProbar.UseVisualStyleBackColor = true;
			this.btnProbar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnProbar_MouseClick);
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Location = new System.Drawing.Point(93, 12);
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
			this.btnLimpiar.TabIndex = 4;
			this.btnLimpiar.Text = "LIMPIAR";
			this.btnLimpiar.UseVisualStyleBackColor = true;
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.imagen);
			this.Controls.Add(this.btnLimpiar);
			this.Controls.Add(this.lblPrediccion);
			this.Controls.Add(this.btnProbar);
			this.Controls.Add(this.btnEntrenar);
			this.Controls.Add(this.graficaSOM);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.graficaSOM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart graficaSOM;
		private System.Windows.Forms.Button btnEntrenar;
		private System.Windows.Forms.Button btnProbar;
		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.PictureBox imagen;
		private System.Windows.Forms.Label lblPrediccion;
		private System.Windows.Forms.Label label1;
	}
}

