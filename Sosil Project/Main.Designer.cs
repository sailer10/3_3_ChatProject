namespace Sosil_Project
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("내 프로필", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("친구 목록", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("내 아이디");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Server"}, -1, System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.panelFriends = new System.Windows.Forms.Panel();
            this.lsvFriends = new System.Windows.Forms.ListView();
            this.ch_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelSetting = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lstTextFamily = new System.Windows.Forms.ListBox();
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFriend = new System.Windows.Forms.TextBox();
            this.lstTextSize = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imlImages = new System.Windows.Forms.ImageList(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panelSchedule = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lsvSchedule = new System.Windows.Forms.ListView();
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chContents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtContents = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelFriends.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.panelSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.btnSchedule);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.btnMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 588);
            this.panel1.TabIndex = 0;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.Orange;
            this.btnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnSchedule.Image")));
            this.btnSchedule.Location = new System.Drawing.Point(3, 81);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.btnSchedule.MaximumSize = new System.Drawing.Size(75, 75);
            this.btnSchedule.MinimumSize = new System.Drawing.Size(75, 75);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(75, 75);
            this.btnSchedule.TabIndex = 3;
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Orange;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.Location = new System.Drawing.Point(3, 159);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 75);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.Orange;
            this.btnMain.Image = ((System.Drawing.Image)(resources.GetObject("btnMain.Image")));
            this.btnMain.Location = new System.Drawing.Point(3, 3);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(75, 75);
            this.btnMain.TabIndex = 0;
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(127, 77);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(137, 15);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "여기에 아이디 표시";
            // 
            // panelFriends
            // 
            this.panelFriends.Controls.Add(this.lsvFriends);
            this.panelFriends.Location = new System.Drawing.Point(115, 20);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(348, 556);
            this.panelFriends.TabIndex = 2;
            // 
            // lsvFriends
            // 
            this.lsvFriends.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Name});
            this.lsvFriends.Font = new System.Drawing.Font("굴림", 12F);
            listViewGroup1.Header = "내 프로필";
            listViewGroup1.Name = "lvgMyGroup";
            listViewGroup2.Header = "친구 목록";
            listViewGroup2.Name = "lvgFriends";
            this.lsvFriends.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lsvFriends.HideSelection = false;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup2;
            this.lsvFriends.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lsvFriends.Location = new System.Drawing.Point(15, 19);
            this.lsvFriends.Name = "lsvFriends";
            this.lsvFriends.Scrollable = false;
            this.lsvFriends.Size = new System.Drawing.Size(250, 444);
            this.lsvFriends.SmallImageList = this.imageList1;
            this.lsvFriends.TabIndex = 2;
            this.lsvFriends.UseCompatibleStateImageBehavior = false;
            this.lsvFriends.View = System.Windows.Forms.View.Details;
            this.lsvFriends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvFriends_MouseDoubleClick);
            // 
            // ch_Name
            // 
            this.ch_Name.Text = "이름";
            this.ch_Name.Width = 215;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "calendar-2-line.png");
            this.imageList1.Images.SetKeyName(1, "calendar-fill.png");
            this.imageList1.Images.SetKeyName(2, "chat-1-fill.png");
            this.imageList1.Images.SetKeyName(3, "chat-1-line.png");
            this.imageList1.Images.SetKeyName(4, "settings-4-fill.png");
            this.imageList1.Images.SetKeyName(5, "settings-4-line.png");
            this.imageList1.Images.SetKeyName(6, "user-fill.png");
            this.imageList1.Images.SetKeyName(7, "user-line.png");
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.SystemColors.Control;
            this.panelSetting.Controls.Add(this.label8);
            this.panelSetting.Controls.Add(this.lstTextFamily);
            this.panelSetting.Controls.Add(this.btnAddFriend);
            this.panelSetting.Controls.Add(this.btnApply);
            this.panelSetting.Controls.Add(this.label4);
            this.panelSetting.Controls.Add(this.txtFriend);
            this.panelSetting.Controls.Add(this.lstTextSize);
            this.panelSetting.Controls.Add(this.label3);
            this.panelSetting.Controls.Add(this.label2);
            this.panelSetting.Controls.Add(this.label1);
            this.panelSetting.Controls.Add(this.lblID);
            this.panelSetting.Location = new System.Drawing.Point(497, 3);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(327, 588);
            this.panelSetting.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "내 아이디 :";
            // 
            // lstTextFamily
            // 
            this.lstTextFamily.FormattingEnabled = true;
            this.lstTextFamily.ItemHeight = 15;
            this.lstTextFamily.Items.AddRange(new object[] {
            "굴림",
            "궁서",
            "돋움",
            "Times New Roman"});
            this.lstTextFamily.Location = new System.Drawing.Point(41, 163);
            this.lstTextFamily.Name = "lstTextFamily";
            this.lstTextFamily.Size = new System.Drawing.Size(228, 49);
            this.lstTextFamily.TabIndex = 9;
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Location = new System.Drawing.Point(164, 483);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(100, 34);
            this.btnAddFriend.TabIndex = 8;
            this.btnAddFriend.Text = "추가";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(169, 313);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 34);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "설정 적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "친구추가";
            // 
            // txtFriend
            // 
            this.txtFriend.Location = new System.Drawing.Point(42, 436);
            this.txtFriend.Name = "txtFriend";
            this.txtFriend.Size = new System.Drawing.Size(227, 25);
            this.txtFriend.TabIndex = 5;
            // 
            // lstTextSize
            // 
            this.lstTextSize.FormattingEnabled = true;
            this.lstTextSize.ItemHeight = 15;
            this.lstTextSize.Items.AddRange(new object[] {
            "9",
            "10",
            "12",
            "14",
            "16"});
            this.lstTextSize.Location = new System.Drawing.Point(41, 247);
            this.lstTextSize.Name = "lstTextSize";
            this.lstTextSize.Size = new System.Drawing.Size(228, 49);
            this.lstTextSize.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F);
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "설정";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "글씨크기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "글꼴";
            // 
            // imlImages
            // 
            this.imlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlImages.ImageStream")));
            this.imlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imlImages.Images.SetKeyName(0, "user-line.png");
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("굴림", 10F);
            this.dateTimePicker1.CustomFormat = "yyyy년M월d일";
            this.dateTimePicker1.Font = new System.Drawing.Font("굴림", 10F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(19, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(298, 27);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "tt hh:mm";
            this.dateTimePicker2.Font = new System.Drawing.Font("굴림", 10F);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(19, 69);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(156, 27);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // panelSchedule
            // 
            this.panelSchedule.Controls.Add(this.label7);
            this.panelSchedule.Controls.Add(this.label6);
            this.panelSchedule.Controls.Add(this.label5);
            this.panelSchedule.Controls.Add(this.lsvSchedule);
            this.panelSchedule.Controls.Add(this.txtContents);
            this.panelSchedule.Controls.Add(this.btnDelete);
            this.panelSchedule.Controls.Add(this.btnAddSchedule);
            this.panelSchedule.Controls.Add(this.dateTimePicker2);
            this.panelSchedule.Controls.Add(this.dateTimePicker1);
            this.panelSchedule.Location = new System.Drawing.Point(850, 12);
            this.panelSchedule.Name = "panelSchedule";
            this.panelSchedule.Size = new System.Drawing.Size(350, 548);
            this.panelSchedule.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "일정 등록";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "등록된 일정";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "내용";
            // 
            // lsvSchedule
            // 
            this.lsvSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDate,
            this.chContents});
            this.lsvSchedule.HideSelection = false;
            this.lsvSchedule.Location = new System.Drawing.Point(19, 253);
            this.lsvSchedule.Name = "lsvSchedule";
            this.lsvSchedule.Size = new System.Drawing.Size(298, 232);
            this.lsvSchedule.TabIndex = 9;
            this.lsvSchedule.UseCompatibleStateImageBehavior = false;
            this.lsvSchedule.View = System.Windows.Forms.View.Details;
            // 
            // chDate
            // 
            this.chDate.Text = "날짜";
            this.chDate.Width = 142;
            // 
            // chContents
            // 
            this.chContents.Text = "할 일";
            this.chContents.Width = 138;
            // 
            // txtContents
            // 
            this.txtContents.Font = new System.Drawing.Font("굴림", 10F);
            this.txtContents.Location = new System.Drawing.Point(19, 125);
            this.txtContents.Name = "txtContents";
            this.txtContents.Size = new System.Drawing.Size(298, 27);
            this.txtContents.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(190, 491);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 43);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "일정삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(190, 158);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(127, 43);
            this.btnAddSchedule.TabIndex = 6;
            this.btnAddSchedule.Text = "등록";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 588);
            this.Controls.Add(this.panelSchedule);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.panelFriends);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panelFriends.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelSetting.PerformLayout();
            this.panelSchedule.ResumeLayout(false);
            this.panelSchedule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Panel panelFriends;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ListView lsvFriends;
        private System.Windows.Forms.ColumnHeader ch_Name;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imlImages;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTextSize;
        private System.Windows.Forms.Button btnAddFriend;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFriend;
        private System.Windows.Forms.ListBox lstTextFamily;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panelSchedule;
        private System.Windows.Forms.ListView lsvSchedule;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chContents;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
    }
}