namespace MouseLabyrinth.UI
{
	partial class MainForm
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
			if(disposing && (components != null))
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
			System.Windows.Forms.Label label1;
			this._btnStartMouse = new System.Windows.Forms.Button();
			this._btnStopMouse = new System.Windows.Forms.Button();
			this._txtMouseStepCount = new System.Windows.Forms.TextBox();
			this._labyrinthView = new LabyrinthView();
			this._btnResetGame = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label1.Location = new System.Drawing.Point(512, 130);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(75, 22);
			label1.TabIndex = 4;
			label1.Text = "Шагов";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// _btnStartMouse
			// 
			this._btnStartMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnStartMouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this._btnStartMouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnStartMouse.Location = new System.Drawing.Point(512, 12);
			this._btnStartMouse.Name = "_btnStartMouse";
			this._btnStartMouse.Size = new System.Drawing.Size(75, 40);
			this._btnStartMouse.TabIndex = 1;
			this._btnStartMouse.Text = "Пуск";
			this._btnStartMouse.UseVisualStyleBackColor = true;
			this._btnStartMouse.Click += new System.EventHandler(this._btnStartMouse_Click);
			// 
			// _btnStopMouse
			// 
			this._btnStopMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnStopMouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this._btnStopMouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnStopMouse.Location = new System.Drawing.Point(512, 58);
			this._btnStopMouse.Name = "_btnStopMouse";
			this._btnStopMouse.Size = new System.Drawing.Size(75, 40);
			this._btnStopMouse.TabIndex = 2;
			this._btnStopMouse.Text = "Стоп";
			this._btnStopMouse.UseVisualStyleBackColor = true;
			this._btnStopMouse.Click += new System.EventHandler(this._btnStopMouse_Click);
			// 
			// _txtMouseStepCount
			// 
			this._txtMouseStepCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._txtMouseStepCount.BackColor = System.Drawing.Color.Black;
			this._txtMouseStepCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtMouseStepCount.Enabled = false;
			this._txtMouseStepCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._txtMouseStepCount.ForeColor = System.Drawing.Color.White;
			this._txtMouseStepCount.Location = new System.Drawing.Point(512, 157);
			this._txtMouseStepCount.Name = "_txtMouseStepCount";
			this._txtMouseStepCount.ReadOnly = true;
			this._txtMouseStepCount.Size = new System.Drawing.Size(75, 31);
			this._txtMouseStepCount.TabIndex = 3;
			this._txtMouseStepCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _labyrinthView
			// 
			this._labyrinthView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._labyrinthView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._labyrinthView.Location = new System.Drawing.Point(12, 12);
			this._labyrinthView.Name = "_labyrinthView";
			this._labyrinthView.Size = new System.Drawing.Size(490, 445);
			this._labyrinthView.TabIndex = 0;
			// 
			// _btnResetGame
			// 
			this._btnResetGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnResetGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this._btnResetGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnResetGame.Location = new System.Drawing.Point(512, 417);
			this._btnResetGame.Name = "_btnResetGame";
			this._btnResetGame.Size = new System.Drawing.Size(75, 40);
			this._btnResetGame.TabIndex = 5;
			this._btnResetGame.Text = "Сброс";
			this._btnResetGame.UseVisualStyleBackColor = true;
			this._btnResetGame.Click += new System.EventHandler(this._btnResetGame_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(599, 469);
			this.Controls.Add(this._btnResetGame);
			this.Controls.Add(label1);
			this.Controls.Add(this._txtMouseStepCount);
			this.Controls.Add(this._btnStopMouse);
			this.Controls.Add(this._btnStartMouse);
			this.Controls.Add(this._labyrinthView);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "MainForm";
			this.Text = "Мышь в лабиринте";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private LabyrinthView _labyrinthView;
		private System.Windows.Forms.Button _btnStartMouse;
		private System.Windows.Forms.Button _btnStopMouse;
		private System.Windows.Forms.TextBox _txtMouseStepCount;
		private System.Windows.Forms.Button _btnResetGame;
	}
}

