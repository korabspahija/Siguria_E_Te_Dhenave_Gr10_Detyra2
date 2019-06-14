﻿namespace TCP_Klienti
{
    partial class Client
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
            this.BWchatLog = new System.ComponentModel.BackgroundWorker();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPorti = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReceiveAnswer = new System.Windows.Forms.TextBox();
            this.grbRegjistrimi = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNotaMesatare = new System.Windows.Forms.TextBox();
            this.txtLendaPreferuar = new System.Windows.Forms.TextBox();
            this.txtEmriMbiemri = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPaga = new System.Windows.Forms.Label();
            this.lblTitulli = new System.Windows.Forms.Label();
            this.lblEmriMbiemri = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtUserName1 = new System.Windows.Forms.TextBox();
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.lblUserName1 = new System.Windows.Forms.Label();
            this.grbRegjistrimi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(453, 15);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 34);
            this.btnConnect.TabIndex = 21;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.Location = new System.Drawing.Point(114, 15);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(145, 26);
            this.txtIP.TabIndex = 20;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPorti
            // 
            this.txtPorti.Enabled = false;
            this.txtPorti.Location = new System.Drawing.Point(326, 15);
            this.txtPorti.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPorti.Name = "txtPorti";
            this.txtPorti.Size = new System.Drawing.Size(100, 26);
            this.txtPorti.TabIndex = 17;
            this.txtPorti.Text = "7000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Porti:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "IP Adresa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 506);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Përgjegja nga SERVERI";
            // 
            // txtReceiveAnswer
            // 
            this.txtReceiveAnswer.Location = new System.Drawing.Point(26, 531);
            this.txtReceiveAnswer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReceiveAnswer.Multiline = true;
            this.txtReceiveAnswer.Name = "txtReceiveAnswer";
            this.txtReceiveAnswer.Size = new System.Drawing.Size(890, 102);
            this.txtReceiveAnswer.TabIndex = 15;
            // 
            // grbRegjistrimi
            // 
            this.grbRegjistrimi.Controls.Add(this.btnSave);
            this.grbRegjistrimi.Controls.Add(this.txtPassword);
            this.grbRegjistrimi.Controls.Add(this.txtUserName);
            this.grbRegjistrimi.Controls.Add(this.txtEmail);
            this.grbRegjistrimi.Controls.Add(this.txtNotaMesatare);
            this.grbRegjistrimi.Controls.Add(this.txtLendaPreferuar);
            this.grbRegjistrimi.Controls.Add(this.txtEmriMbiemri);
            this.grbRegjistrimi.Controls.Add(this.lblPassword);
            this.grbRegjistrimi.Controls.Add(this.lblEmail);
            this.grbRegjistrimi.Controls.Add(this.lblPaga);
            this.grbRegjistrimi.Controls.Add(this.lblTitulli);
            this.grbRegjistrimi.Controls.Add(this.lblEmriMbiemri);
            this.grbRegjistrimi.Controls.Add(this.lblUserName);
            this.grbRegjistrimi.Location = new System.Drawing.Point(2, 105);
            this.grbRegjistrimi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbRegjistrimi.Name = "grbRegjistrimi";
            this.grbRegjistrimi.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbRegjistrimi.Size = new System.Drawing.Size(474, 388);
            this.grbRegjistrimi.TabIndex = 22;
            this.grbRegjistrimi.TabStop = false;
            this.grbRegjistrimi.Text = "Regjistrimi i mësimdhënësit";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(354, 331);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Ruaje";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(174, 280);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(292, 26);
            this.txtPassword.TabIndex = 39;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(174, 228);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(292, 26);
            this.txtUserName.TabIndex = 38;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(174, 182);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(292, 26);
            this.txtEmail.TabIndex = 37;
            // 
            // txtNotaMesatare
            // 
            this.txtNotaMesatare.Location = new System.Drawing.Point(174, 138);
            this.txtNotaMesatare.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNotaMesatare.Name = "txtNotaMesatare";
            this.txtNotaMesatare.Size = new System.Drawing.Size(292, 26);
            this.txtNotaMesatare.TabIndex = 36;
            this.txtNotaMesatare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaga_KeyPress);
            // 
            // txtLendaPreferuar
            // 
            this.txtLendaPreferuar.Location = new System.Drawing.Point(174, 92);
            this.txtLendaPreferuar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLendaPreferuar.Name = "txtLendaPreferuar";
            this.txtLendaPreferuar.Size = new System.Drawing.Size(292, 26);
            this.txtLendaPreferuar.TabIndex = 35;
            // 
            // txtEmriMbiemri
            // 
            this.txtEmriMbiemri.Location = new System.Drawing.Point(174, 46);
            this.txtEmriMbiemri.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmriMbiemri.Name = "txtEmriMbiemri";
            this.txtEmriMbiemri.Size = new System.Drawing.Size(292, 26);
            this.txtEmriMbiemri.TabIndex = 34;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 280);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 20);
            this.lblPassword.TabIndex = 33;
            this.lblPassword.Text = "Password:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(21, 182);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(105, 20);
            this.lblEmail.TabIndex = 32;
            this.lblEmail.Text = "Email adresa:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaga
            // 
            this.lblPaga.AutoSize = true;
            this.lblPaga.Location = new System.Drawing.Point(21, 138);
            this.lblPaga.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaga.Name = "lblPaga";
            this.lblPaga.Size = new System.Drawing.Size(118, 20);
            this.lblPaga.TabIndex = 31;
            this.lblPaga.Text = "Nota Mesatare:";
            this.lblPaga.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulli
            // 
            this.lblTitulli.AutoSize = true;
            this.lblTitulli.Location = new System.Drawing.Point(21, 95);
            this.lblTitulli.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulli.Name = "lblTitulli";
            this.lblTitulli.Size = new System.Drawing.Size(140, 20);
            this.lblTitulli.TabIndex = 30;
            this.lblTitulli.Text = "Lenda e preferuar:";
            this.lblTitulli.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmriMbiemri
            // 
            this.lblEmriMbiemri.AutoSize = true;
            this.lblEmriMbiemri.Location = new System.Drawing.Point(19, 46);
            this.lblEmriMbiemri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmriMbiemri.Name = "lblEmriMbiemri";
            this.lblEmriMbiemri.Size = new System.Drawing.Size(104, 20);
            this.lblEmriMbiemri.TabIndex = 29;
            this.lblEmriMbiemri.Text = "Emri Mbiemri:";
            this.lblEmriMbiemri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(21, 231);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(93, 20);
            this.lblUserName.TabIndex = 28;
            this.lblUserName.Text = "User Name:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Controls.Add(this.txtPassword1);
            this.groupBox2.Controls.Add(this.txtUserName1);
            this.groupBox2.Controls.Add(this.lblPassword1);
            this.groupBox2.Controls.Add(this.lblUserName1);
            this.groupBox2.Location = new System.Drawing.Point(484, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(434, 388);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autentifikimi";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(294, 331);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 35);
            this.btnLogin.TabIndex = 45;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(112, 141);
            this.txtPassword1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(292, 26);
            this.txtPassword1.TabIndex = 44;
            // 
            // txtUserName1
            // 
            this.txtUserName1.Location = new System.Drawing.Point(112, 95);
            this.txtUserName1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName1.Name = "txtUserName1";
            this.txtUserName1.Size = new System.Drawing.Size(292, 26);
            this.txtUserName1.TabIndex = 43;
            // 
            // lblPassword1
            // 
            this.lblPassword1.AutoSize = true;
            this.lblPassword1.Location = new System.Drawing.Point(8, 141);
            this.lblPassword1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword1.Name = "lblPassword1";
            this.lblPassword1.Size = new System.Drawing.Size(82, 20);
            this.lblPassword1.TabIndex = 42;
            this.lblPassword1.Text = "Password:";
            // 
            // lblUserName1
            // 
            this.lblUserName1.AutoSize = true;
            this.lblUserName1.Location = new System.Drawing.Point(8, 98);
            this.lblUserName1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName1.Name = "lblUserName1";
            this.lblUserName1.Size = new System.Drawing.Size(93, 20);
            this.lblUserName1.TabIndex = 41;
            this.lblUserName1.Text = "User Name:";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 649);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbRegjistrimi);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtPorti);
            this.Controls.Add(this.txtReceiveAnswer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Client";
            this.Text = "FIEK-TCP Klienti";
            this.grbRegjistrimi.ResumeLayout(false);
            this.grbRegjistrimi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BWchatLog;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPorti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReceiveAnswer;
        private System.Windows.Forms.GroupBox grbRegjistrimi;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNotaMesatare;
        private System.Windows.Forms.TextBox txtLendaPreferuar;
        private System.Windows.Forms.TextBox txtEmriMbiemri;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPaga;
        private System.Windows.Forms.Label lblTitulli;
        private System.Windows.Forms.Label lblEmriMbiemri;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtUserName1;
        private System.Windows.Forms.Label lblPassword1;
        private System.Windows.Forms.Label lblUserName1;


    }
}

