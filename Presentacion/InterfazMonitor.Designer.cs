namespace RestaurantePPAI.Presentacion
{
    partial class InterfazMonitor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaPedidos = new System.Windows.Forms.DataGridView();
            this.mesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgCampana = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCampana)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 99);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(355, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pedidos Listos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Restaurante Coronabyte";
            // 
            // grillaPedidos
            // 
            this.grillaPedidos.AllowUserToAddRows = false;
            this.grillaPedidos.AllowUserToDeleteRows = false;
            this.grillaPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaPedidos.BackgroundColor = System.Drawing.Color.White;
            this.grillaPedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grillaPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mesa,
            this.cantidad});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaPedidos.DefaultCellStyle = dataGridViewCellStyle4;
            this.grillaPedidos.EnableHeadersVisualStyles = false;
            this.grillaPedidos.GridColor = System.Drawing.Color.White;
            this.grillaPedidos.Location = new System.Drawing.Point(98, 149);
            this.grillaPedidos.MultiSelect = false;
            this.grillaPedidos.Name = "grillaPedidos";
            this.grillaPedidos.ReadOnly = true;
            this.grillaPedidos.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.grillaPedidos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grillaPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaPedidos.Size = new System.Drawing.Size(648, 313);
            this.grillaPedidos.TabIndex = 1;
            // 
            // mesa
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mesa.DefaultCellStyle = dataGridViewCellStyle2;
            this.mesa.HeaderText = "Mesa";
            this.mesa.Name = "mesa";
            this.mesa.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // imgCampana
            // 
            this.imgCampana.Image = global::RestaurantePPAI.Properties.Resources.notificacion;
            this.imgCampana.Location = new System.Drawing.Point(752, 106);
            this.imgCampana.Name = "imgCampana";
            this.imgCampana.Size = new System.Drawing.Size(100, 81);
            this.imgCampana.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCampana.TabIndex = 3;
            this.imgCampana.TabStop = false;
            this.imgCampana.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InterfazMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 509);
            this.Controls.Add(this.imgCampana);
            this.Controls.Add(this.grillaPedidos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InterfazMonitor";
            this.Text = "InterfazMonitor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCampana)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grillaPedidos;
        private System.Windows.Forms.PictureBox imgCampana;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
    }
}