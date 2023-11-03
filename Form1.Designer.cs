namespace TPfinalProgramacion1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            button2 = new Button();
            btnAbrirFormularioLogin = new Button();
            comboBox1 = new ComboBox();
            form1BindingSource = new BindingSource(components);
            textBox4 = new TextBox();
            monthCalendar1 = new MonthCalendar();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(231, 121);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(231, 178);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(231, 229);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 129);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 4;
            label1.Text = "Ingrese DNI";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 186);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 5;
            label2.Text = "Ingrese Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 237);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 6;
            label3.Text = "Ingrese Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 291);
            label4.Name = "label4";
            label4.Size = new Size(156, 15);
            label4.TabIndex = 7;
            label4.Text = "Ingrese fecha de nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(358, 9);
            label5.Name = "label5";
            label5.Size = new Size(116, 15);
            label5.TabIndex = 8;
            label5.Text = "Inscripción Alumnos";
            label5.Click += label5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(298, 382);
            button1.Name = "button1";
            button1.Size = new Size(217, 48);
            button1.TabIndex = 10;
            button1.Text = "Inscribir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(128, 345);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 12;
            label6.Text = "Ingrese Carrera";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(533, 382);
            button2.Name = "button2";
            button2.Size = new Size(212, 48);
            button2.TabIndex = 13;
            button2.Text = "Visualizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnAbrirFormularioLogin
            // 
            btnAbrirFormularioLogin.Location = new Point(122, 382);
            btnAbrirFormularioLogin.Name = "btnAbrirFormularioLogin";
            btnAbrirFormularioLogin.Size = new Size(164, 48);
            btnAbrirFormularioLogin.TabIndex = 14;
            btnAbrirFormularioLogin.Text = "LogIn";
            btnAbrirFormularioLogin.UseVisualStyleBackColor = true;
            btnAbrirFormularioLogin.Click += btnAbrirFormularioLogin_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownHeight = 160;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownWidth = 290;
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.Items.AddRange(new object[] { "Desarrollo de Software", "Analista en Medio Ambiente", "Comercio Exterior", "Comercialización y Administración de Empresas", "Higiene y Seguridad en el Trabajo", "Microelectrónica", "Químico Superior Industrial", "Químico Superior Analista", "Sistema de Control" });
            comboBox1.Location = new Point(220, 342);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(174, 23);
            comboBox1.TabIndex = 15;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // form1BindingSource
            // 
            form1BindingSource.DataSource = typeof(Form1);
            // 
            // textBox4
            // 
            textBox4.Location = new Point(231, 283);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 3;
            textBox4.Visible = false;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(328, 144);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 16;
            monthCalendar1.Visible = false;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // button3
            // 
            button3.Location = new Point(231, 283);
            button3.Name = "button3";
            button3.Size = new Size(100, 23);
            button3.TabIndex = 17;
            button3.Text = "Calendario";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Image = Properties.Resources.beppo;
            pictureBox2.Location = new Point(442, 46);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(303, 292);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 19;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(monthCalendar1);
            Controls.Add(comboBox1);
            Controls.Add(btnAbrirFormularioLogin);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Inscripción  ISET N°25 \"Beppo Levi\"";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Label label6;
        private Button button2;
        private Button btnAbrirFormularioLogin;
        private ComboBox comboBox1;
        private BindingSource form1BindingSource;
        private TextBox textBox4;
        private MonthCalendar monthCalendar1;
        private Button button3;
        private PictureBox pictureBox2;
    }
}