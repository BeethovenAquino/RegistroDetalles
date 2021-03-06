﻿namespace RegistroDetalle.UI.Consulta
{
    partial class ConsulPersona
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HastadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DesdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ConsulPersonasdataGridView = new System.Windows.Forms.DataGridView();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FiltrarcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Buscar1button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConsulPersonasdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Desde ";
            // 
            // HastadateTimePicker
            // 
            this.HastadateTimePicker.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HastadateTimePicker.Location = new System.Drawing.Point(300, 81);
            this.HastadateTimePicker.Name = "HastadateTimePicker";
            this.HastadateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.HastadateTimePicker.TabIndex = 17;
            // 
            // DesdedateTimePicker
            // 
            this.DesdedateTimePicker.Location = new System.Drawing.Point(61, 81);
            this.DesdedateTimePicker.Name = "DesdedateTimePicker";
            this.DesdedateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.DesdedateTimePicker.TabIndex = 16;
            // 
            // ConsulPersonasdataGridView
            // 
            this.ConsulPersonasdataGridView.AllowUserToDeleteRows = false;
            this.ConsulPersonasdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsulPersonasdataGridView.Location = new System.Drawing.Point(61, 132);
            this.ConsulPersonasdataGridView.Name = "ConsulPersonasdataGridView";
            this.ConsulPersonasdataGridView.ReadOnly = true;
            this.ConsulPersonasdataGridView.Size = new System.Drawing.Size(616, 308);
            this.ConsulPersonasdataGridView.TabIndex = 15;
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(374, 22);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(269, 20);
            this.CriteriotextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Criterio";
            // 
            // FiltrarcomboBox
            // 
            this.FiltrarcomboBox.FormattingEnabled = true;
            this.FiltrarcomboBox.Items.AddRange(new object[] {
            "ID",
            "Nombre",
            "Fecha",
            "Cedula",
            "Direccion",
            "Telefono",
            "Todo"});
            this.FiltrarcomboBox.Location = new System.Drawing.Point(77, 23);
            this.FiltrarcomboBox.Name = "FiltrarcomboBox";
            this.FiltrarcomboBox.Size = new System.Drawing.Size(121, 21);
            this.FiltrarcomboBox.TabIndex = 11;
            this.FiltrarcomboBox.SelectedIndexChanged += new System.EventHandler(this.FiltrarcomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtro";
            // 
            // Buscar1button
            // 
            this.Buscar1button.Image = global::RegistroDetalle.Properties.Resources.buscar;
            this.Buscar1button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Buscar1button.Location = new System.Drawing.Point(684, 11);
            this.Buscar1button.Name = "Buscar1button";
            this.Buscar1button.Size = new System.Drawing.Size(75, 67);
            this.Buscar1button.TabIndex = 14;
            this.Buscar1button.Text = "Buscar";
            this.Buscar1button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Buscar1button.UseVisualStyleBackColor = true;
            this.Buscar1button.Click += new System.EventHandler(this.Buscar1button_Click);
            // 
            // ConsulPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RegistroDetalle.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HastadateTimePicker);
            this.Controls.Add(this.DesdedateTimePicker);
            this.Controls.Add(this.ConsulPersonasdataGridView);
            this.Controls.Add(this.Buscar1button);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FiltrarcomboBox);
            this.Controls.Add(this.label1);
            this.Name = "ConsulPersona";
            this.Text = "ConsulPersona";
            ((System.ComponentModel.ISupportInitialize)(this.ConsulPersonasdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker HastadateTimePicker;
        private System.Windows.Forms.DateTimePicker DesdedateTimePicker;
        private System.Windows.Forms.DataGridView ConsulPersonasdataGridView;
        private System.Windows.Forms.Button Buscar1button;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FiltrarcomboBox;
        private System.Windows.Forms.Label label1;
    }
}