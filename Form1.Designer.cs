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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.btnProbar = new System.Windows.Forms.Button();
			this.imagen = new System.Windows.Forms.PictureBox();
			this.lblPrediccion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblInfo = new System.Windows.Forms.Label();
			this.chSOM = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.btnTrain = new System.Windows.Forms.Button();
			this.chartPesos = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chSOM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartPesos)).BeginInit();
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
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(549, 21);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(82, 13);
			this.lblInfo.TabIndex = 8;
			this.lblInfo.Text = "                         ";
			// 
			// chSOM
			// 
			chartArea1.Name = "ChartArea1";
			this.chSOM.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chSOM.Legends.Add(legend1);
			this.chSOM.Location = new System.Drawing.Point(457, 113);
			this.chSOM.Name = "chSOM";
			this.chSOM.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chSOM.Series.Add(series1);
			this.chSOM.Size = new System.Drawing.Size(300, 300);
			this.chSOM.TabIndex = 9;
			this.chSOM.Text = "chart1";
			// 
			// btnTrain
			// 
			this.btnTrain.Location = new System.Drawing.Point(12, 45);
			this.btnTrain.Name = "btnTrain";
			this.btnTrain.Size = new System.Drawing.Size(75, 23);
			this.btnTrain.TabIndex = 10;
			this.btnTrain.Text = "ENTRENAR";
			this.btnTrain.UseVisualStyleBackColor = true;
			this.btnTrain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnTrain_MouseClick);
			// 
			// chartPesos
			// 
			chartArea2.Name = "ChartArea1";
			this.chartPesos.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.chartPesos.Legends.Add(legend2);
			this.chartPesos.Location = new System.Drawing.Point(843, 113);
			this.chartPesos.Name = "chartPesos";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.chartPesos.Series.Add(series2);
			this.chartPesos.Size = new System.Drawing.Size(300, 300);
			this.chartPesos.TabIndex = 11;
			this.chartPesos.Text = "chart1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1188, 450);
			this.Controls.Add(this.chartPesos);
			this.Controls.Add(this.btnTrain);
			this.Controls.Add(this.chSOM);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.imagen);
			this.Controls.Add(this.lblPrediccion);
			this.Controls.Add(this.btnProbar);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chSOM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartPesos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnProbar;
		private System.Windows.Forms.PictureBox imagen;
		private System.Windows.Forms.Label lblPrediccion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.DataVisualization.Charting.Chart chSOM;
		private System.Windows.Forms.Button btnTrain;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartPesos;
	}
}

