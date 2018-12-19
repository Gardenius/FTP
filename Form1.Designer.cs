namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("/");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Server_text = new System.Windows.Forms.TextBox();
            this.Username_text = new System.Windows.Forms.TextBox();
            this.Port_text = new System.Windows.Forms.TextBox();
            this.Password_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.Status_text = new System.Windows.Forms.RichTextBox();
            this.Connect_btn = new System.Windows.Forms.Button();
            this.Files_lst = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // Server_text
            // 
            this.Server_text.Location = new System.Drawing.Point(59, 12);
            this.Server_text.Name = "Server_text";
            this.Server_text.Size = new System.Drawing.Size(100, 20);
            this.Server_text.TabIndex = 0;
            // 
            // Username_text
            // 
            this.Username_text.Location = new System.Drawing.Point(229, 12);
            this.Username_text.Name = "Username_text";
            this.Username_text.Size = new System.Drawing.Size(100, 20);
            this.Username_text.TabIndex = 0;
            // 
            // Port_text
            // 
            this.Port_text.Location = new System.Drawing.Point(538, 12);
            this.Port_text.Name = "Port_text";
            this.Port_text.Size = new System.Drawing.Size(102, 20);
            this.Port_text.TabIndex = 0;
            // 
            // Password_text
            // 
            this.Password_text.Location = new System.Drawing.Point(397, 12);
            this.Password_text.Name = "Password_text";
            this.Password_text.Size = new System.Drawing.Size(100, 20);
            this.Password_text.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Port:";
            // 
            // treeView
            // 
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList1;
            this.treeView.Location = new System.Drawing.Point(15, 140);
            this.treeView.Name = "treeView";
            treeNode1.Name = "";
            treeNode1.Text = "/";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(350, 176);
            this.treeView.TabIndex = 5;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // Status_text
            // 
            this.Status_text.Location = new System.Drawing.Point(15, 38);
            this.Status_text.Name = "Status_text";
            this.Status_text.ReadOnly = true;
            this.Status_text.Size = new System.Drawing.Size(706, 96);
            this.Status_text.TabIndex = 6;
            this.Status_text.Text = "";
            this.Status_text.TextChanged += new System.EventHandler(this.Status_text_TextChanged);
            // 
            // Connect_btn
            // 
            this.Connect_btn.Location = new System.Drawing.Point(646, 9);
            this.Connect_btn.Name = "Connect_btn";
            this.Connect_btn.Size = new System.Drawing.Size(75, 23);
            this.Connect_btn.TabIndex = 7;
            this.Connect_btn.Text = "Connect";
            this.Connect_btn.UseVisualStyleBackColor = true;
            this.Connect_btn.Click += new System.EventHandler(this.Connect_btn_Click);
            // 
            // Files_lst
            // 
            this.Files_lst.Location = new System.Drawing.Point(371, 140);
            this.Files_lst.Name = "Files_lst";
            this.Files_lst.Size = new System.Drawing.Size(350, 176);
            this.Files_lst.TabIndex = 8;
            this.Files_lst.UseCompatibleStateImageBehavior = false;
            this.Files_lst.View = System.Windows.Forms.View.List;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dir_ico");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 328);
            this.Controls.Add(this.Files_lst);
            this.Controls.Add(this.Connect_btn);
            this.Controls.Add(this.Status_text);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password_text);
            this.Controls.Add(this.Port_text);
            this.Controls.Add(this.Username_text);
            this.Controls.Add(this.Server_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Server_text;
        private System.Windows.Forms.TextBox Username_text;
        private System.Windows.Forms.TextBox Port_text;
        private System.Windows.Forms.TextBox Password_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.RichTextBox Status_text;
        private System.Windows.Forms.Button Connect_btn;
        private System.Windows.Forms.ListView Files_lst;
        private System.Windows.Forms.ImageList imageList1;
    }
}

