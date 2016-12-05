namespace XMLEditor
{
    partial class Form1
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
            this.open_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.choose_xml_button = new System.Windows.Forms.Button();
            this.data_urodzenia_picker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ubezpieczona_radio = new System.Windows.Forms.RadioButton();
            this.pesel_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.imie_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nazwisko_text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.telefon_email_text = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rodzina_radio = new System.Windows.Forms.RadioButton();
            this.prawo_do_swiadczen_radio = new System.Windows.Forms.RadioButton();
            this.podstawa_uprawnien_combo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.osobiscie_radio = new System.Windows.Forms.RadioButton();
            this.osoba_upowazniona_radio = new System.Windows.Forms.RadioButton();
            this.poczta_radio = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.nr_domu_text = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ulica_text = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nr_lokalu_text = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.kod_pocztowy_text = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.miejscowosc_text = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panstwo_text = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.aktualna_data_picker = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.status_panel = new System.Windows.Forms.Panel();
            this.odbior_panel = new System.Windows.Forms.Panel();
            this.wojewodztwo_combo = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.telefon_kontaktowy_text = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.oddzial_text = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.zalacznik_text = new System.Windows.Forms.TextBox();
            this.save_xml_button = new System.Windows.Forms.Button();
            this.save_file_dialog = new System.Windows.Forms.SaveFileDialog();
            this.komunikaty_check = new System.Windows.Forms.CheckBox();
            this.validate_button = new System.Windows.Forms.Button();
            this.data_grid_view = new System.Windows.Forms.DataGridView();
            this.status_panel.SuspendLayout();
            this.odbior_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // open_file_dialog
            // 
            this.open_file_dialog.FileName = "open_file";
            // 
            // choose_xml_button
            // 
            this.choose_xml_button.Location = new System.Drawing.Point(538, 842);
            this.choose_xml_button.Name = "choose_xml_button";
            this.choose_xml_button.Size = new System.Drawing.Size(108, 31);
            this.choose_xml_button.TabIndex = 0;
            this.choose_xml_button.Text = "Choose XML";
            this.choose_xml_button.UseVisualStyleBackColor = true;
            this.choose_xml_button.Click += new System.EventHandler(this.choose_xml_button_Click);
            // 
            // data_urodzenia_picker
            // 
            this.data_urodzenia_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_urodzenia_picker.Location = new System.Drawing.Point(539, 57);
            this.data_urodzenia_picker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.data_urodzenia_picker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.data_urodzenia_picker.Name = "data_urodzenia_picker";
            this.data_urodzenia_picker.Size = new System.Drawing.Size(107, 22);
            this.data_urodzenia_picker.TabIndex = 1;
            this.data_urodzenia_picker.Value = new System.DateTime(2016, 11, 14, 0, 0, 0, 0);
            this.data_urodzenia_picker.ValueChanged += new System.EventHandler(this.data_urodzenia_picker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dane wnioskodawcy";
            // 
            // ubezpieczona_radio
            // 
            this.ubezpieczona_radio.AutoSize = true;
            this.ubezpieczona_radio.Location = new System.Drawing.Point(3, 39);
            this.ubezpieczona_radio.Name = "ubezpieczona_radio";
            this.ubezpieczona_radio.Size = new System.Drawing.Size(163, 21);
            this.ubezpieczona_radio.TabIndex = 3;
            this.ubezpieczona_radio.TabStop = true;
            this.ubezpieczona_radio.Text = "Osoba ubezpieczona";
            this.ubezpieczona_radio.UseVisualStyleBackColor = true;
            this.ubezpieczona_radio.CheckedChanged += new System.EventHandler(this.status_panel_CheckedChanged);
            // 
            // pesel_text
            // 
            this.pesel_text.BackColor = System.Drawing.SystemColors.Window;
            this.pesel_text.Location = new System.Drawing.Point(12, 57);
            this.pesel_text.Name = "pesel_text";
            this.pesel_text.Size = new System.Drawing.Size(521, 22);
            this.pesel_text.TabIndex = 4;
            this.pesel_text.Leave += new System.EventHandler(this.pesel_text_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "PESEL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data urodzenia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Imię";
            // 
            // imie_text
            // 
            this.imie_text.Location = new System.Drawing.Point(12, 102);
            this.imie_text.Name = "imie_text";
            this.imie_text.Size = new System.Drawing.Size(293, 22);
            this.imie_text.TabIndex = 7;
            this.imie_text.Leave += new System.EventHandler(this.imie_text_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nazwisko";
            // 
            // nazwisko_text
            // 
            this.nazwisko_text.Location = new System.Drawing.Point(311, 102);
            this.nazwisko_text.Name = "nazwisko_text";
            this.nazwisko_text.Size = new System.Drawing.Size(335, 22);
            this.nazwisko_text.TabIndex = 9;
            this.nazwisko_text.Leave += new System.EventHandler(this.nazwisko_text_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Numer telefonu kontaktowego / adres e-mail";
            // 
            // telefon_email_text
            // 
            this.telefon_email_text.Location = new System.Drawing.Point(12, 147);
            this.telefon_email_text.Name = "telefon_email_text";
            this.telefon_email_text.Size = new System.Drawing.Size(634, 22);
            this.telefon_email_text.TabIndex = 11;
            this.telefon_email_text.Leave += new System.EventHandler(this.telefon_email_text_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(318, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Status wnioskodawcy - zaznaczyć właściwe";
            // 
            // rodzina_radio
            // 
            this.rodzina_radio.AutoSize = true;
            this.rodzina_radio.Location = new System.Drawing.Point(3, 66);
            this.rodzina_radio.Name = "rodzina_radio";
            this.rodzina_radio.Size = new System.Drawing.Size(266, 21);
            this.rodzina_radio.TabIndex = 14;
            this.rodzina_radio.TabStop = true;
            this.rodzina_radio.Text = "Członek rodziny osoby ubezpieczonej";
            this.rodzina_radio.UseVisualStyleBackColor = true;
            this.rodzina_radio.CheckedChanged += new System.EventHandler(this.status_panel_CheckedChanged);
            // 
            // prawo_do_swiadczen_radio
            // 
            this.prawo_do_swiadczen_radio.AutoSize = true;
            this.prawo_do_swiadczen_radio.Location = new System.Drawing.Point(302, 39);
            this.prawo_do_swiadczen_radio.Name = "prawo_do_swiadczen_radio";
            this.prawo_do_swiadczen_radio.Size = new System.Drawing.Size(335, 21);
            this.prawo_do_swiadczen_radio.TabIndex = 15;
            this.prawo_do_swiadczen_radio.TabStop = true;
            this.prawo_do_swiadczen_radio.Text = "Osoba nieubezpieczona z prawem do świadczeń";
            this.prawo_do_swiadczen_radio.UseVisualStyleBackColor = true;
            this.prawo_do_swiadczen_radio.CheckedChanged += new System.EventHandler(this.status_panel_CheckedChanged);
            // 
            // podstawa_uprawnien_combo
            // 
            this.podstawa_uprawnien_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.podstawa_uprawnien_combo.DropDownWidth = 240;
            this.podstawa_uprawnien_combo.Enabled = false;
            this.podstawa_uprawnien_combo.FormattingEnabled = true;
            this.podstawa_uprawnien_combo.Location = new System.Drawing.Point(458, 60);
            this.podstawa_uprawnien_combo.Name = "podstawa_uprawnien_combo";
            this.podstawa_uprawnien_combo.Size = new System.Drawing.Size(182, 24);
            this.podstawa_uprawnien_combo.TabIndex = 16;
            this.podstawa_uprawnien_combo.SelectedIndexChanged += new System.EventHandler(this.podstawa_uprawnien_combo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(314, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Podstawa uprawnień";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(326, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Sposób odbioru EKUZ - zaznaczyć właściwe";
            // 
            // osobiscie_radio
            // 
            this.osobiscie_radio.AutoSize = true;
            this.osobiscie_radio.Location = new System.Drawing.Point(5, 29);
            this.osobiscie_radio.Name = "osobiscie_radio";
            this.osobiscie_radio.Size = new System.Drawing.Size(91, 21);
            this.osobiscie_radio.TabIndex = 19;
            this.osobiscie_radio.TabStop = true;
            this.osobiscie_radio.Text = "Osobiście";
            this.osobiscie_radio.UseVisualStyleBackColor = true;
            this.osobiscie_radio.CheckedChanged += new System.EventHandler(this.odbior_panel_CheckedChanged);
            // 
            // osoba_upowazniona_radio
            // 
            this.osoba_upowazniona_radio.AutoSize = true;
            this.osoba_upowazniona_radio.Location = new System.Drawing.Point(5, 56);
            this.osoba_upowazniona_radio.Name = "osoba_upowazniona_radio";
            this.osoba_upowazniona_radio.Size = new System.Drawing.Size(276, 21);
            this.osoba_upowazniona_radio.TabIndex = 20;
            this.osoba_upowazniona_radio.TabStop = true;
            this.osoba_upowazniona_radio.Text = "Za pośrednictwem osoby upoważnionej";
            this.osoba_upowazniona_radio.UseVisualStyleBackColor = true;
            this.osoba_upowazniona_radio.CheckedChanged += new System.EventHandler(this.odbior_panel_CheckedChanged);
            // 
            // poczta_radio
            // 
            this.poczta_radio.AutoSize = true;
            this.poczta_radio.Location = new System.Drawing.Point(5, 83);
            this.poczta_radio.Name = "poczta_radio";
            this.poczta_radio.Size = new System.Drawing.Size(189, 21);
            this.poczta_radio.TabIndex = 21;
            this.poczta_radio.TabStop = true;
            this.poczta_radio.Text = "Przesłać pocztą na adres";
            this.poczta_radio.UseVisualStyleBackColor = true;
            this.poczta_radio.CheckedChanged += new System.EventHandler(this.odbior_panel_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(263, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Nr domu";
            // 
            // nr_domu_text
            // 
            this.nr_domu_text.Location = new System.Drawing.Point(263, 128);
            this.nr_domu_text.Name = "nr_domu_text";
            this.nr_domu_text.Size = new System.Drawing.Size(90, 22);
            this.nr_domu_text.TabIndex = 24;
            this.nr_domu_text.Leave += new System.EventHandler(this.nr_domu_text_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Ulica";
            // 
            // ulica_text
            // 
            this.ulica_text.Location = new System.Drawing.Point(5, 128);
            this.ulica_text.Name = "ulica_text";
            this.ulica_text.Size = new System.Drawing.Size(252, 22);
            this.ulica_text.TabIndex = 22;
            this.ulica_text.Leave += new System.EventHandler(this.ulica_text_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(359, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "Nr lokalu";
            // 
            // nr_lokalu_text
            // 
            this.nr_lokalu_text.Location = new System.Drawing.Point(359, 128);
            this.nr_lokalu_text.Name = "nr_lokalu_text";
            this.nr_lokalu_text.Size = new System.Drawing.Size(90, 22);
            this.nr_lokalu_text.TabIndex = 26;
            this.nr_lokalu_text.Leave += new System.EventHandler(this.nr_lokalu_text_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 17);
            this.label13.TabIndex = 29;
            this.label13.Text = "Kod pocztowy";
            // 
            // kod_pocztowy_text
            // 
            this.kod_pocztowy_text.Location = new System.Drawing.Point(5, 173);
            this.kod_pocztowy_text.Name = "kod_pocztowy_text";
            this.kod_pocztowy_text.Size = new System.Drawing.Size(95, 22);
            this.kod_pocztowy_text.TabIndex = 28;
            this.kod_pocztowy_text.Leave += new System.EventHandler(this.kod_pocztowy_text_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(106, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 17);
            this.label14.TabIndex = 31;
            this.label14.Text = "Miejscowość / Poczta";
            // 
            // miejscowosc_text
            // 
            this.miejscowosc_text.Location = new System.Drawing.Point(106, 173);
            this.miejscowosc_text.Name = "miejscowosc_text";
            this.miejscowosc_text.Size = new System.Drawing.Size(315, 22);
            this.miejscowosc_text.TabIndex = 30;
            this.miejscowosc_text.Leave += new System.EventHandler(this.miejscowosc_text_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(427, 153);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 17);
            this.label15.TabIndex = 33;
            this.label15.Text = "Państwo";
            // 
            // panstwo_text
            // 
            this.panstwo_text.Location = new System.Drawing.Point(427, 173);
            this.panstwo_text.Name = "panstwo_text";
            this.panstwo_text.Size = new System.Drawing.Size(213, 22);
            this.panstwo_text.TabIndex = 32;
            this.panstwo_text.Leave += new System.EventHandler(this.panstwo_text_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 489);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 17);
            this.label20.TabIndex = 44;
            this.label20.Text = "Kraje wyjazdu";
            // 
            // aktualna_data_picker
            // 
            this.aktualna_data_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.aktualna_data_picker.Location = new System.Drawing.Point(539, 802);
            this.aktualna_data_picker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.aktualna_data_picker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.aktualna_data_picker.Name = "aktualna_data_picker";
            this.aktualna_data_picker.Size = new System.Drawing.Size(107, 22);
            this.aktualna_data_picker.TabIndex = 46;
            this.aktualna_data_picker.Value = new System.DateTime(2016, 11, 14, 0, 0, 0, 0);
            this.aktualna_data_picker.ValueChanged += new System.EventHandler(this.aktualna_data_picker_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(496, 802);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 17);
            this.label21.TabIndex = 47;
            this.label21.Text = "Data";
            // 
            // status_panel
            // 
            this.status_panel.Controls.Add(this.label8);
            this.status_panel.Controls.Add(this.label7);
            this.status_panel.Controls.Add(this.ubezpieczona_radio);
            this.status_panel.Controls.Add(this.podstawa_uprawnien_combo);
            this.status_panel.Controls.Add(this.prawo_do_swiadczen_radio);
            this.status_panel.Controls.Add(this.rodzina_radio);
            this.status_panel.Location = new System.Drawing.Point(6, 175);
            this.status_panel.Name = "status_panel";
            this.status_panel.Size = new System.Drawing.Size(657, 98);
            this.status_panel.TabIndex = 49;
            // 
            // odbior_panel
            // 
            this.odbior_panel.Controls.Add(this.wojewodztwo_combo);
            this.odbior_panel.Controls.Add(this.label24);
            this.odbior_panel.Controls.Add(this.telefon_kontaktowy_text);
            this.odbior_panel.Controls.Add(this.label23);
            this.odbior_panel.Controls.Add(this.label22);
            this.odbior_panel.Controls.Add(this.label9);
            this.odbior_panel.Controls.Add(this.oddzial_text);
            this.odbior_panel.Controls.Add(this.osobiscie_radio);
            this.odbior_panel.Controls.Add(this.osoba_upowazniona_radio);
            this.odbior_panel.Controls.Add(this.poczta_radio);
            this.odbior_panel.Controls.Add(this.ulica_text);
            this.odbior_panel.Controls.Add(this.label11);
            this.odbior_panel.Controls.Add(this.nr_domu_text);
            this.odbior_panel.Controls.Add(this.label10);
            this.odbior_panel.Controls.Add(this.nr_lokalu_text);
            this.odbior_panel.Controls.Add(this.label12);
            this.odbior_panel.Controls.Add(this.kod_pocztowy_text);
            this.odbior_panel.Controls.Add(this.label13);
            this.odbior_panel.Controls.Add(this.miejscowosc_text);
            this.odbior_panel.Controls.Add(this.label14);
            this.odbior_panel.Controls.Add(this.panstwo_text);
            this.odbior_panel.Controls.Add(this.label15);
            this.odbior_panel.Location = new System.Drawing.Point(6, 279);
            this.odbior_panel.Name = "odbior_panel";
            this.odbior_panel.Size = new System.Drawing.Size(657, 207);
            this.odbior_panel.TabIndex = 50;
            // 
            // wojewodztwo_combo
            // 
            this.wojewodztwo_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wojewodztwo_combo.DropDownWidth = 240;
            this.wojewodztwo_combo.Enabled = false;
            this.wojewodztwo_combo.FormattingEnabled = true;
            this.wojewodztwo_combo.Location = new System.Drawing.Point(414, 38);
            this.wojewodztwo_combo.Name = "wojewodztwo_combo";
            this.wojewodztwo_combo.Size = new System.Drawing.Size(226, 24);
            this.wojewodztwo_combo.TabIndex = 57;
            this.wojewodztwo_combo.SelectedIndexChanged += new System.EventHandler(this.wojewodztwo_combo_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(307, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 17);
            this.label24.TabIndex = 56;
            this.label24.Text = "w oddziale";
            // 
            // telefon_kontaktowy_text
            // 
            this.telefon_kontaktowy_text.Enabled = false;
            this.telefon_kontaktowy_text.Location = new System.Drawing.Point(455, 128);
            this.telefon_kontaktowy_text.Name = "telefon_kontaktowy_text";
            this.telefon_kontaktowy_text.Size = new System.Drawing.Size(185, 22);
            this.telefon_kontaktowy_text.TabIndex = 53;
            this.telefon_kontaktowy_text.Leave += new System.EventHandler(this.telefon_kontaktowy_text_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(455, 108);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(130, 17);
            this.label23.TabIndex = 54;
            this.label23.Text = "Telefon kontaktowy";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(315, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 17);
            this.label22.TabIndex = 52;
            this.label22.Text = "Województwo";
            // 
            // oddzial_text
            // 
            this.oddzial_text.Enabled = false;
            this.oddzial_text.Location = new System.Drawing.Point(319, 68);
            this.oddzial_text.Name = "oddzial_text";
            this.oddzial_text.Size = new System.Drawing.Size(321, 22);
            this.oddzial_text.TabIndex = 51;
            this.oddzial_text.Leave += new System.EventHandler(this.oddzial_text_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 802);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(142, 17);
            this.label25.TabIndex = 52;
            this.label25.Text = "Załącznik do wniosku";
            // 
            // zalacznik_text
            // 
            this.zalacznik_text.Location = new System.Drawing.Point(160, 802);
            this.zalacznik_text.Name = "zalacznik_text";
            this.zalacznik_text.Size = new System.Drawing.Size(330, 22);
            this.zalacznik_text.TabIndex = 51;
            this.zalacznik_text.Leave += new System.EventHandler(this.zalacznik_text_Leave);
            // 
            // save_xml_button
            // 
            this.save_xml_button.Location = new System.Drawing.Point(424, 842);
            this.save_xml_button.Name = "save_xml_button";
            this.save_xml_button.Size = new System.Drawing.Size(108, 31);
            this.save_xml_button.TabIndex = 53;
            this.save_xml_button.Text = "Save XML";
            this.save_xml_button.UseVisualStyleBackColor = true;
            this.save_xml_button.Click += new System.EventHandler(this.save_xml_button_Click);
            // 
            // komunikaty_check
            // 
            this.komunikaty_check.AutoSize = true;
            this.komunikaty_check.Location = new System.Drawing.Point(6, 852);
            this.komunikaty_check.Name = "komunikaty_check";
            this.komunikaty_check.Size = new System.Drawing.Size(292, 21);
            this.komunikaty_check.TabIndex = 54;
            this.komunikaty_check.Text = "Pokazuj komunikaty o poprawnej walidacji";
            this.komunikaty_check.UseVisualStyleBackColor = true;
            this.komunikaty_check.CheckedChanged += new System.EventHandler(this.komunikaty_check_CheckedChanged);
            // 
            // validate_button
            // 
            this.validate_button.Location = new System.Drawing.Point(310, 842);
            this.validate_button.Name = "validate_button";
            this.validate_button.Size = new System.Drawing.Size(108, 31);
            this.validate_button.TabIndex = 55;
            this.validate_button.Text = "Validate";
            this.validate_button.UseVisualStyleBackColor = true;
            this.validate_button.Click += new System.EventHandler(this.validate_button_Click);
            // 
            // data_grid_view
            // 
            this.data_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view.Location = new System.Drawing.Point(6, 509);
            this.data_grid_view.Name = "data_grid_view";
            this.data_grid_view.RowTemplate.Height = 24;
            this.data_grid_view.Size = new System.Drawing.Size(640, 287);
            this.data_grid_view.TabIndex = 57;
            this.data_grid_view.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_grid_view_CellEndEdit);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(658, 885);
            this.Controls.Add(this.data_grid_view);
            this.Controls.Add(this.validate_button);
            this.Controls.Add(this.komunikaty_check);
            this.Controls.Add(this.save_xml_button);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.zalacznik_text);
            this.Controls.Add(this.odbior_panel);
            this.Controls.Add(this.status_panel);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.aktualna_data_picker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.telefon_email_text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nazwisko_text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imie_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pesel_text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data_urodzenia_picker);
            this.Controls.Add(this.choose_xml_button);
            this.MinimumSize = new System.Drawing.Size(676, 919);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.status_panel.ResumeLayout(false);
            this.status_panel.PerformLayout();
            this.odbior_panel.ResumeLayout(false);
            this.odbior_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog open_file_dialog;
        private System.Windows.Forms.Button choose_xml_button;
        private System.Windows.Forms.DateTimePicker data_urodzenia_picker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ubezpieczona_radio;
        private System.Windows.Forms.TextBox pesel_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imie_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nazwisko_text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox telefon_email_text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rodzina_radio;
        private System.Windows.Forms.RadioButton prawo_do_swiadczen_radio;
        private System.Windows.Forms.ComboBox podstawa_uprawnien_combo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton osobiscie_radio;
        private System.Windows.Forms.RadioButton osoba_upowazniona_radio;
        private System.Windows.Forms.RadioButton poczta_radio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nr_domu_text;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ulica_text;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox nr_lokalu_text;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox kod_pocztowy_text;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox miejscowosc_text;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox panstwo_text;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker aktualna_data_picker;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel status_panel;
        private System.Windows.Forms.Panel odbior_panel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox oddzial_text;
        private System.Windows.Forms.ComboBox wojewodztwo_combo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox telefon_kontaktowy_text;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox zalacznik_text;
        private System.Windows.Forms.Button save_xml_button;
        private System.Windows.Forms.SaveFileDialog save_file_dialog;
        private System.Windows.Forms.CheckBox komunikaty_check;
        private System.Windows.Forms.Button validate_button;
        private System.Windows.Forms.DataGridView data_grid_view;
    }
}

