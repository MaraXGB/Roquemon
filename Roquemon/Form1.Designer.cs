﻿namespace Roquemon
{
    partial class Roquemon
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.Jugador1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BJugador1 = new System.Windows.Forms.Button();
            this.PlantamonI = new System.Windows.Forms.RadioButton();
            this.FuegomonI = new System.Windows.Forms.RadioButton();
            this.AguamonI = new System.Windows.Forms.RadioButton();
            this.Roquemon1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Habilidad2 = new System.Windows.Forms.RadioButton();
            this.Habilidad1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Jugador2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Bjugador2 = new System.Windows.Forms.Button();
            this.PlantamonD = new System.Windows.Forms.RadioButton();
            this.FuegomonD = new System.Windows.Forms.RadioButton();
            this.AguamonD = new System.Windows.Forms.RadioButton();
            this.Roquemon2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Habilidad4 = new System.Windows.Forms.RadioButton();
            this.Habilidad3 = new System.Windows.Forms.RadioButton();
            this.Combatir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Jugador1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Jugador2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.ForeColor = System.Drawing.Color.GreenYellow;
            this.progressBar1.Location = new System.Drawing.Point(101, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar1.Size = new System.Drawing.Size(218, 22);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 100;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(95, 30);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar2.Size = new System.Drawing.Size(218, 22);
            this.progressBar2.TabIndex = 1;
            this.progressBar2.Value = 100;
            // 
            // Jugador1
            // 
            this.Jugador1.BackColor = System.Drawing.Color.Transparent;
            this.Jugador1.Controls.Add(this.groupBox5);
            this.Jugador1.Controls.Add(this.Roquemon1);
            this.Jugador1.Controls.Add(this.progressBar1);
            this.Jugador1.Controls.Add(this.groupBox3);
            this.Jugador1.Controls.Add(this.label2);
            this.Jugador1.Location = new System.Drawing.Point(20, 23);
            this.Jugador1.Name = "Jugador1";
            this.Jugador1.Size = new System.Drawing.Size(395, 290);
            this.Jugador1.TabIndex = 2;
            this.Jugador1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.BJugador1);
            this.groupBox5.Controls.Add(this.PlantamonI);
            this.groupBox5.Controls.Add(this.FuegomonI);
            this.groupBox5.Controls.Add(this.AguamonI);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(11, 24);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(361, 255);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seleccione un Roquemon";
            // 
            // BJugador1
            // 
            this.BJugador1.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BJugador1.Location = new System.Drawing.Point(214, 179);
            this.BJugador1.Name = "BJugador1";
            this.BJugador1.Size = new System.Drawing.Size(108, 55);
            this.BJugador1.TabIndex = 6;
            this.BJugador1.Text = "YO TE ELIJO";
            this.BJugador1.UseVisualStyleBackColor = true;
            this.BJugador1.Click += new System.EventHandler(this.button2_Click);
            // 
            // PlantamonI
            // 
            this.PlantamonI.AutoSize = true;
            this.PlantamonI.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlantamonI.Location = new System.Drawing.Point(134, 130);
            this.PlantamonI.Name = "PlantamonI";
            this.PlantamonI.Size = new System.Drawing.Size(108, 32);
            this.PlantamonI.TabIndex = 2;
            this.PlantamonI.TabStop = true;
            this.PlantamonI.Text = "Plantamon";
            this.PlantamonI.UseVisualStyleBackColor = true;
            this.PlantamonI.CheckedChanged += new System.EventHandler(this.PlantamonI_CheckedChanged);
            // 
            // FuegomonI
            // 
            this.FuegomonI.AutoSize = true;
            this.FuegomonI.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FuegomonI.Location = new System.Drawing.Point(134, 92);
            this.FuegomonI.Name = "FuegomonI";
            this.FuegomonI.Size = new System.Drawing.Size(108, 32);
            this.FuegomonI.TabIndex = 1;
            this.FuegomonI.TabStop = true;
            this.FuegomonI.Text = "Fuegomón";
            this.FuegomonI.UseVisualStyleBackColor = true;
            this.FuegomonI.CheckedChanged += new System.EventHandler(this.FuegomonI_CheckedChanged);
            // 
            // AguamonI
            // 
            this.AguamonI.AutoSize = true;
            this.AguamonI.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AguamonI.Location = new System.Drawing.Point(134, 51);
            this.AguamonI.Name = "AguamonI";
            this.AguamonI.Size = new System.Drawing.Size(100, 32);
            this.AguamonI.TabIndex = 0;
            this.AguamonI.TabStop = true;
            this.AguamonI.Text = "Aguamón";
            this.AguamonI.UseVisualStyleBackColor = true;
            this.AguamonI.CheckedChanged += new System.EventHandler(this.AguamonI_CheckedChanged);
            // 
            // Roquemon1
            // 
            this.Roquemon1.AutoSize = true;
            this.Roquemon1.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roquemon1.Location = new System.Drawing.Point(6, 24);
            this.Roquemon1.Name = "Roquemon1";
            this.Roquemon1.Size = new System.Drawing.Size(100, 28);
            this.Roquemon1.TabIndex = 5;
            this.Roquemon1.Text = "Roquemon1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Habilidad2);
            this.groupBox3.Controls.Add(this.Habilidad1);
            this.groupBox3.Location = new System.Drawing.Point(13, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(359, 189);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Habilidades";
            // 
            // Habilidad2
            // 
            this.Habilidad2.AutoSize = true;
            this.Habilidad2.Location = new System.Drawing.Point(119, 112);
            this.Habilidad2.Name = "Habilidad2";
            this.Habilidad2.Size = new System.Drawing.Size(14, 13);
            this.Habilidad2.TabIndex = 2;
            this.Habilidad2.TabStop = true;
            this.Habilidad2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Habilidad2.UseVisualStyleBackColor = true;
            this.Habilidad2.CheckedChanged += new System.EventHandler(this.Habilidad2_CheckedChanged);
            // 
            // Habilidad1
            // 
            this.Habilidad1.AutoSize = true;
            this.Habilidad1.Location = new System.Drawing.Point(119, 55);
            this.Habilidad1.Name = "Habilidad1";
            this.Habilidad1.Size = new System.Drawing.Size(14, 13);
            this.Habilidad1.TabIndex = 1;
            this.Habilidad1.TabStop = true;
            this.Habilidad1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Habilidad1.UseVisualStyleBackColor = true;
            this.Habilidad1.CheckedChanged += new System.EventHandler(this.Habilidad1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(316, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // Jugador2
            // 
            this.Jugador2.BackColor = System.Drawing.Color.Transparent;
            this.Jugador2.Controls.Add(this.groupBox6);
            this.Jugador2.Controls.Add(this.Roquemon2);
            this.Jugador2.Controls.Add(this.label3);
            this.Jugador2.Controls.Add(this.groupBox4);
            this.Jugador2.Controls.Add(this.progressBar2);
            this.Jugador2.Location = new System.Drawing.Point(409, 23);
            this.Jugador2.Name = "Jugador2";
            this.Jugador2.Size = new System.Drawing.Size(394, 290);
            this.Jugador2.TabIndex = 3;
            this.Jugador2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.Bjugador2);
            this.groupBox6.Controls.Add(this.PlantamonD);
            this.groupBox6.Controls.Add(this.FuegomonD);
            this.groupBox6.Controls.Add(this.AguamonD);
            this.groupBox6.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 24);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(361, 256);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Seleccione un Roquemon";
            // 
            // Bjugador2
            // 
            this.Bjugador2.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bjugador2.Location = new System.Drawing.Point(224, 180);
            this.Bjugador2.Name = "Bjugador2";
            this.Bjugador2.Size = new System.Drawing.Size(108, 55);
            this.Bjugador2.TabIndex = 6;
            this.Bjugador2.Text = "YO TE ELIJO";
            this.Bjugador2.UseVisualStyleBackColor = true;
            this.Bjugador2.Click += new System.EventHandler(this.Bjugador2_Click);
            // 
            // PlantamonD
            // 
            this.PlantamonD.AutoSize = true;
            this.PlantamonD.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlantamonD.Location = new System.Drawing.Point(118, 131);
            this.PlantamonD.Name = "PlantamonD";
            this.PlantamonD.Size = new System.Drawing.Size(108, 32);
            this.PlantamonD.TabIndex = 2;
            this.PlantamonD.TabStop = true;
            this.PlantamonD.Text = "Plantamon";
            this.PlantamonD.UseVisualStyleBackColor = true;
            this.PlantamonD.CheckedChanged += new System.EventHandler(this.PlantamonD_CheckedChanged);
            // 
            // FuegomonD
            // 
            this.FuegomonD.AutoSize = true;
            this.FuegomonD.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FuegomonD.Location = new System.Drawing.Point(122, 93);
            this.FuegomonD.Name = "FuegomonD";
            this.FuegomonD.Size = new System.Drawing.Size(108, 32);
            this.FuegomonD.TabIndex = 1;
            this.FuegomonD.TabStop = true;
            this.FuegomonD.Text = "Fuegomón";
            this.FuegomonD.UseVisualStyleBackColor = true;
            this.FuegomonD.CheckedChanged += new System.EventHandler(this.FuegomonD_CheckedChanged);
            // 
            // AguamonD
            // 
            this.AguamonD.AutoSize = true;
            this.AguamonD.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AguamonD.Location = new System.Drawing.Point(122, 52);
            this.AguamonD.Name = "AguamonD";
            this.AguamonD.Size = new System.Drawing.Size(100, 32);
            this.AguamonD.TabIndex = 0;
            this.AguamonD.TabStop = true;
            this.AguamonD.Text = "Aguamón";
            this.AguamonD.UseVisualStyleBackColor = true;
            this.AguamonD.CheckedChanged += new System.EventHandler(this.AguamonD_CheckedChanged);
            // 
            // Roquemon2
            // 
            this.Roquemon2.AutoSize = true;
            this.Roquemon2.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roquemon2.Location = new System.Drawing.Point(6, 24);
            this.Roquemon2.Name = "Roquemon2";
            this.Roquemon2.Size = new System.Drawing.Size(100, 28);
            this.Roquemon2.TabIndex = 6;
            this.Roquemon2.Text = "Roquemon2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(319, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Habilidad4);
            this.groupBox4.Controls.Add(this.Habilidad3);
            this.groupBox4.Location = new System.Drawing.Point(15, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 143);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Habilidades";
            // 
            // Habilidad4
            // 
            this.Habilidad4.AutoSize = true;
            this.Habilidad4.Location = new System.Drawing.Point(114, 112);
            this.Habilidad4.Name = "Habilidad4";
            this.Habilidad4.Size = new System.Drawing.Size(14, 13);
            this.Habilidad4.TabIndex = 3;
            this.Habilidad4.TabStop = true;
            this.Habilidad4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Habilidad4.UseVisualStyleBackColor = true;
            this.Habilidad4.CheckedChanged += new System.EventHandler(this.Habilidad4_CheckedChanged);
            // 
            // Habilidad3
            // 
            this.Habilidad3.AutoSize = true;
            this.Habilidad3.Location = new System.Drawing.Point(114, 55);
            this.Habilidad3.Name = "Habilidad3";
            this.Habilidad3.Size = new System.Drawing.Size(14, 13);
            this.Habilidad3.TabIndex = 2;
            this.Habilidad3.TabStop = true;
            this.Habilidad3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Habilidad3.UseVisualStyleBackColor = true;
            this.Habilidad3.CheckedChanged += new System.EventHandler(this.Habilidad3_CheckedChanged);
            // 
            // Combatir
            // 
            this.Combatir.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combatir.Location = new System.Drawing.Point(341, 345);
            this.Combatir.Name = "Combatir";
            this.Combatir.Size = new System.Drawing.Size(146, 39);
            this.Combatir.TabIndex = 5;
            this.Combatir.Text = "COMBATIR";
            this.Combatir.UseVisualStyleBackColor = true;
            this.Combatir.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Kozuka Gothic Pro R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(795, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------------------------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Roquemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(815, 485);
            this.Controls.Add(this.Combatir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Jugador2);
            this.Controls.Add(this.Jugador1);
            this.Name = "Roquemon";
            this.Text = "Form1";
            this.Jugador1.ResumeLayout(false);
            this.Jugador1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Jugador2.ResumeLayout(false);
            this.Jugador2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.GroupBox Jugador1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Habilidad2;
        private System.Windows.Forms.RadioButton Habilidad1;
        private System.Windows.Forms.GroupBox Jugador2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton Habilidad4;
        private System.Windows.Forms.RadioButton Habilidad3;
        private System.Windows.Forms.Button Combatir;
        private System.Windows.Forms.Label Roquemon1;
        private System.Windows.Forms.Label Roquemon2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton PlantamonI;
        private System.Windows.Forms.RadioButton FuegomonI;
        private System.Windows.Forms.RadioButton AguamonI;
        private System.Windows.Forms.Button BJugador1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button Bjugador2;
        private System.Windows.Forms.RadioButton PlantamonD;
        private System.Windows.Forms.RadioButton FuegomonD;
        private System.Windows.Forms.RadioButton AguamonD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

