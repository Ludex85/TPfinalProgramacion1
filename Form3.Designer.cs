namespace TPfinalProgramacion1
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnIniciarSesion = new Button();
            bttonMostrar = new Button();
            bttonOcultar = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(295, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(295, 134);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(160, 23);
            textBox2.TabIndex = 1;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(199, 58);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 141);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(199, 320);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(354, 41);
            btnIniciarSesion.TabIndex = 4;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // bttonMostrar
            // 
            bttonMostrar.FlatAppearance.BorderColor = Color.LightSkyBlue;
            bttonMostrar.FlatAppearance.BorderSize = 0;
            bttonMostrar.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            bttonMostrar.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            bttonMostrar.FlatStyle = FlatStyle.Flat;
            bttonMostrar.Location = new Point(297, 162);
            bttonMostrar.Name = "bttonMostrar";
            bttonMostrar.Size = new Size(75, 23);
            bttonMostrar.TabIndex = 5;
            bttonMostrar.Text = "Mostrar";
            bttonMostrar.UseVisualStyleBackColor = true;
            bttonMostrar.Click += bttonMostrar_Click;
            // 
            // bttonOcultar
            // 
            bttonOcultar.Enabled = false;
            bttonOcultar.FlatAppearance.BorderColor = Color.LightSkyBlue;
            bttonOcultar.FlatAppearance.BorderSize = 0;
            bttonOcultar.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            bttonOcultar.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            bttonOcultar.FlatStyle = FlatStyle.Flat;
            bttonOcultar.Location = new Point(297, 163);
            bttonOcultar.Name = "bttonOcultar";
            bttonOcultar.Size = new Size(75, 23);
            bttonOcultar.TabIndex = 6;
            bttonOcultar.Text = "Ocultar";
            bttonOcultar.UseVisualStyleBackColor = true;
            bttonOcultar.Visible = false;
            bttonOcultar.Click += bttonOcultar_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(bttonOcultar);
            Controls.Add(bttonMostrar);
            Controls.Add(btnIniciarSesion);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button btnIniciarSesion;
        private Button bttonMostrar;
        private Button bttonOcultar;
    }
}