namespace ArrangementTool
{
    partial class MainPage
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.verticalSlotsNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.horizontalSlotsNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.touchCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.radioImageChange = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioRotationChange = new System.Windows.Forms.RadioButton();
            this.test = new System.Windows.Forms.Label();
            this.stageIndex = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalSlotsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalSlotsNum)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.verticalSlotsNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.horizontalSlotsNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number of Slots";
            // 
            // verticalSlotsNum
            // 
            this.verticalSlotsNum.Location = new System.Drawing.Point(90, 56);
            this.verticalSlotsNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.verticalSlotsNum.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.verticalSlotsNum.Name = "verticalSlotsNum";
            this.verticalSlotsNum.Size = new System.Drawing.Size(79, 21);
            this.verticalSlotsNum.TabIndex = 3;
            this.verticalSlotsNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.verticalSlotsNum.ValueChanged += new System.EventHandler(this.verticalSlotsNum_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vertical :";
            // 
            // horizontalSlotsNum
            // 
            this.horizontalSlotsNum.Location = new System.Drawing.Point(90, 25);
            this.horizontalSlotsNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.horizontalSlotsNum.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.horizontalSlotsNum.Name = "horizontalSlotsNum";
            this.horizontalSlotsNum.Size = new System.Drawing.Size(79, 21);
            this.horizontalSlotsNum.TabIndex = 1;
            this.horizontalSlotsNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.horizontalSlotsNum.ValueChanged += new System.EventHandler(this.horizontalSlotsNum_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horizontal :";
            // 
            // touchCount
            // 
            this.touchCount.Location = new System.Drawing.Point(103, 319);
            this.touchCount.Name = "touchCount";
            this.touchCount.Size = new System.Drawing.Size(67, 21);
            this.touchCount.TabIndex = 6;
            this.touchCount.Text = "0";
            this.touchCount.TextChanged += new System.EventHandler(this.touchCount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Touch Count :";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(216, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 585);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Picture Group";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(28, 564);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(117, 564);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 9;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // radioImageChange
            // 
            this.radioImageChange.AutoSize = true;
            this.radioImageChange.Checked = true;
            this.radioImageChange.Location = new System.Drawing.Point(17, 29);
            this.radioImageChange.Name = "radioImageChange";
            this.radioImageChange.Size = new System.Drawing.Size(145, 16);
            this.radioImageChange.TabIndex = 10;
            this.radioImageChange.TabStop = true;
            this.radioImageChange.Text = "Image Change Button";
            this.radioImageChange.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioRotationChange);
            this.groupBox4.Controls.Add(this.radioImageChange);
            this.groupBox4.Location = new System.Drawing.Point(12, 214);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 81);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Picture Change";
            // 
            // radioRotationChange
            // 
            this.radioRotationChange.AutoSize = true;
            this.radioRotationChange.Location = new System.Drawing.Point(16, 51);
            this.radioRotationChange.Name = "radioRotationChange";
            this.radioRotationChange.Size = new System.Drawing.Size(155, 16);
            this.radioRotationChange.TabIndex = 11;
            this.radioRotationChange.Text = "Rotation Change Button";
            this.radioRotationChange.UseVisualStyleBackColor = true;
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(60, 442);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(38, 12);
            this.test.TabIndex = 12;
            this.test.Text = "label6";
            // 
            // stageIndex
            // 
            this.stageIndex.Location = new System.Drawing.Point(103, 24);
            this.stageIndex.Name = "stageIndex";
            this.stageIndex.Size = new System.Drawing.Size(67, 21);
            this.stageIndex.TabIndex = 14;
            this.stageIndex.Text = "1";
            this.stageIndex.TextChanged += new System.EventHandler(this.stageIndex_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Stage Index :";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 627);
            this.Controls.Add(this.stageIndex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.test);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.touchCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPage";
            this.Text = "Arrangement Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalSlotsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalSlotsNum)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown verticalSlotsNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown horizontalSlotsNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox touchCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.RadioButton radioImageChange;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioRotationChange;
        private System.Windows.Forms.Label test;
        private System.Windows.Forms.TextBox stageIndex;
        private System.Windows.Forms.Label label6;
    }
}

