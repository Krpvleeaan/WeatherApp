namespace Laverna_Test_1
{
    partial class Weather_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Enter_NameOfCity = new System.Windows.Forms.Label();
            this.richTextBox_NameOfCity = new System.Windows.Forms.RichTextBox();
            this.button_RefreshWeather = new System.Windows.Forms.Button();
            this.label_Temperature = new System.Windows.Forms.Label();
            this.label_Description = new System.Windows.Forms.Label();
            this.label_WindSpeed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Enter_NameOfCity
            // 
            this.label_Enter_NameOfCity.AutoSize = true;
            this.label_Enter_NameOfCity.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Enter_NameOfCity.Location = new System.Drawing.Point(40, 29);
            this.label_Enter_NameOfCity.Name = "label_Enter_NameOfCity";
            this.label_Enter_NameOfCity.Size = new System.Drawing.Size(295, 27);
            this.label_Enter_NameOfCity.TabIndex = 0;
            this.label_Enter_NameOfCity.Text = "Enter the name of the city";
            // 
            // richTextBox_NameOfCity
            // 
            this.richTextBox_NameOfCity.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_NameOfCity.Location = new System.Drawing.Point(45, 81);
            this.richTextBox_NameOfCity.Multiline = false;
            this.richTextBox_NameOfCity.Name = "richTextBox_NameOfCity";
            this.richTextBox_NameOfCity.Size = new System.Drawing.Size(290, 45);
            this.richTextBox_NameOfCity.TabIndex = 1;
            this.richTextBox_NameOfCity.Text = "";
            // 
            // button_RefreshWeather
            // 
            this.button_RefreshWeather.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.button_RefreshWeather.Location = new System.Drawing.Point(350, 72);
            this.button_RefreshWeather.Name = "button_RefreshWeather";
            this.button_RefreshWeather.Size = new System.Drawing.Size(272, 57);
            this.button_RefreshWeather.TabIndex = 2;
            this.button_RefreshWeather.Text = "Update information";
            this.button_RefreshWeather.UseVisualStyleBackColor = true;
            this.button_RefreshWeather.Click += new System.EventHandler(this.button_RefreshWeather_Click);
            // 
            // label_Temperature
            // 
            this.label_Temperature.AutoSize = true;
            this.label_Temperature.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label_Temperature.Location = new System.Drawing.Point(40, 165);
            this.label_Temperature.Name = "label_Temperature";
            this.label_Temperature.Size = new System.Drawing.Size(158, 27);
            this.label_Temperature.TabIndex = 3;
            this.label_Temperature.Text = "Temperature:";
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label_Description.Location = new System.Drawing.Point(40, 224);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(149, 27);
            this.label_Description.TabIndex = 4;
            this.label_Description.Text = "Description:";
            // 
            // label_WindSpeed
            // 
            this.label_WindSpeed.AutoSize = true;
            this.label_WindSpeed.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label_WindSpeed.Location = new System.Drawing.Point(40, 284);
            this.label_WindSpeed.Name = "label_WindSpeed";
            this.label_WindSpeed.Size = new System.Drawing.Size(151, 27);
            this.label_WindSpeed.TabIndex = 5;
            this.label_WindSpeed.Text = "Wind Speed:";
            // 
            // Weather_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(638, 344);
            this.Controls.Add(this.label_WindSpeed);
            this.Controls.Add(this.label_Description);
            this.Controls.Add(this.label_Temperature);
            this.Controls.Add(this.button_RefreshWeather);
            this.Controls.Add(this.richTextBox_NameOfCity);
            this.Controls.Add(this.label_Enter_NameOfCity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Weather_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weather_application";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Enter_NameOfCity;
        private System.Windows.Forms.RichTextBox richTextBox_NameOfCity;
        private System.Windows.Forms.Button button_RefreshWeather;
        private System.Windows.Forms.Label label_Temperature;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Label label_WindSpeed;
    }
}

