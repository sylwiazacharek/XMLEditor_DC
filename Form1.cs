using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using XMLEditor.DGV;

namespace XMLEditor
{
    public partial class Form1 : Form
    {
        private List<String[]> edited;
        private List<String[]> state;
        private bool komunikaty = false;

        public Form1()
        {
            set_edited();
            set_state();

            InitializeComponent();

            this.podstawa_uprawnien_combo.Items.AddRange(new String[]{
                "decyzja wójta",
                "nieubezpieczony niepełnoletni obywatel",
                "nieubezpieczony niepełnoletni mieszkaniec",
                "nieubezpieczona kobieta w ciąży",
                "nieubezpieczona kobieta uchodźca",
                "nieubezpieczona z prawem do świadczeń",
                "absolwent szkoły ponadgimnazjalnej lub wyższej",
                "zasiłek chorobowy lub wypadkowy",
                "ubiegająca się o przyznanie emerytury lub renty"});

            this.wojewodztwo_combo.Items.AddRange(new String[]{
			    "dolnośląskie",
		   	    "kujawsko-pomorskie",
		       	"lubelskie",
	    		"lubuskie",
	    		"łódzkie",
    			"małopolskie",
	    		"mazowieckie",
		    	"opolskie",
    			"podkarpackie",
	    		"podlaskie",
		    	"pomorskie",
			    "śląskie",
    			"świętokrzyskie",
	    		"warmińsko-mazurskie",
		    	"wielkopolskie",
			    "zachodniopomorskie"});

            this.transport_combo.Items.AddRange(new String[]{
			    "samolot",
			    "autokar",
                "samochód",
                "rower",
                "pieszo",
                "prom"});

            this.data_urodzenia_picker.Value = System.DateTime.Now;
            this.aktualna_data_picker.Value = System.DateTime.Now;
            this.data_wyjazdu_picker.Value = System.DateTime.Now;
            this.data_powrotu_picker.Value = System.DateTime.Now;

            this.open_file_dialog.InitialDirectory = XMLEditorManager.data_path;
            this.save_file_dialog.InitialDirectory = XMLEditorManager.data_path;

            //adjust_columns();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn kraj = new DataGridViewTextBoxColumn();
            CalendarDGVColumn data_wyjazdu = new CalendarDGVColumn();
            CalendarDGVColumn data_powrotu = new CalendarDGVColumn();
            DataGridViewComboBoxColumn transport = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn dlugosc_pobytu = new DataGridViewTextBoxColumn();

            transport.Items.AddRange(new String[]{
			    "samolot",
			    "autokar",
                "samochód",
                "rower",
                "pieszo",
                "prom"});

            kraj.HeaderText = "Kraj";
            data_wyjazdu.HeaderText = "Data wyjazdu";
            data_powrotu.HeaderText = "Data powrotu";
            transport.HeaderText = "Środek transportu";
            dlugosc_pobytu.HeaderText = "Czas pobytu";

            kraj.Name = "kraj";
            data_wyjazdu.Name = "data_wyjazdu";
            data_powrotu.Name = "data_powrotu";
            transport.Name = "transport";
            dlugosc_pobytu.Name = "pobyt";

            this.data_grid_view.Columns.Add(kraj);
            this.data_grid_view.Columns.Add(data_wyjazdu);
            this.data_grid_view.Columns.Add(data_powrotu);
            this.data_grid_view.Columns.Add(transport);
            this.data_grid_view.Columns.Add(dlugosc_pobytu);

            this.data_grid_view.RowCount = 1;
            this.data_grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void set_edited()
        {
            edited = new List<String[]>();

            edited.Add(new String[] { "aktualna data", "F" });
            edited.Add(new String[] { "pesel", "F" });
            edited.Add(new String[] { "imie", "F" });
            edited.Add(new String[] { "nazwisko", "F" });
            edited.Add(new String[] { "data urodzenia", "F" });
            edited.Add(new String[] { "telefon email", "F" });
            edited.Add(new String[] { "status", "F" });
            edited.Add(new String[] { "podstawa uprawnien", "T" });
            edited.Add(new String[] { "sposob odbioru", "F" });
            edited.Add(new String[] { "nazwa", "T" });
            edited.Add(new String[] { "panstwo", "F" });
            edited.Add(new String[] { "wojewodztwo", "F" });
            edited.Add(new String[] { "miasto", "F" });
            edited.Add(new String[] { "kod pocztowy", "F" });
            edited.Add(new String[] { "ulica", "F" });
            edited.Add(new String[] { "numer domu", "F" });
            edited.Add(new String[] { "telefon", "T" });
        }

        private void set_state()
        {
            state = new List<String[]>();

            state.Add(new String[] { "aktualna data", "F" });
            state.Add(new String[] { "pesel", "F" });
            state.Add(new String[] { "imie", "F" });
            state.Add(new String[] { "nazwisko", "F" });
            state.Add(new String[] { "data urodzenia", "F" });
            state.Add(new String[] { "telefon email", "F" });
            state.Add(new String[] { "status", "F" });
            state.Add(new String[] { "sposob odbioru", "F" });
            state.Add(new String[] { "nazwa", "T" });
            state.Add(new String[] { "panstwo", "F" });
            state.Add(new String[] { "wojewodztwo", "F" });
            state.Add(new String[] { "miasto", "F" });
            state.Add(new String[] { "kod pocztowy", "F" });
            state.Add(new String[] { "ulica", "F" });
            state.Add(new String[] { "numer domu", "F" });
            state.Add(new String[] { "numer lokalu", "F" });
            state.Add(new String[] { "telefon", "F" });
            state.Add(new String[] { "zalacznik", "F" });
        }

        private String check_edited(String key)
        {
            foreach (String[] item in edited)
            {
                if (item[0].Equals(key))
                {
                    if (item[1].Equals("F"))
                    {
                        return "F";
                    }
                    else
                    {
                        return "T";
                    }
                }
            }

            return null;
        }

        private String check_state(String key)
        {
            foreach (String[] item in state)
            {
                if (item[0].Equals(key))
                {
                    if (item[1].Equals("F"))
                    {
                        return "F";
                    }
                    else
                    {
                        return "T";
                    }
                }
            }

            return null;
        }

        private void set_edited(String key, String value)
        {
            foreach (String[] item in edited)
            {
                if (item[0].Equals(key))
                {
                    item[1] = value;
                }
            }
        }

        private void set_state(String key, String value)
        {
            foreach (String[] item in state)
            {
                if (item[0].Equals(key))
                {
                    item[1] = value;
                }
            }
        }


        /*private void adjust_columns()
        {
            foreach (ColumnHeader column in data_grid_view.Columns)
            {
                int max_value = -1;

                foreach (ListViewItem cell in data_grid_view.Items)
                {
                    if (cell.SubItems[column.DisplayIndex].Text.Length > max_value)
                    {
                        max_value = cell.SubItems[column.DisplayIndex].Text.Length;
                    }
                }

                if (max_value > column.Text.Length)
                {
                    column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }*/


        private void fill_wnioskodawca(Wnioskodawca wnioskodawca)
        {
            this.pesel_text.Text = wnioskodawca.pesel;
            this.pesel_text.BackColor = Color.FromName("Window");

            this.data_urodzenia_picker.Value = wnioskodawca.data_urodzenia;

            this.imie_text.Text = wnioskodawca.imie;
            this.imie_text.BackColor = Color.FromName("Window");

            this.nazwisko_text.Text = wnioskodawca.nazwisko;
            this.nazwisko_text.BackColor = Color.FromName("Window");

            if (wnioskodawca.nr_telefonu == null)
            {
                this.telefon_email_text.Text = wnioskodawca.email;
            }
            else
            {
                this.telefon_email_text.Text = wnioskodawca.nr_telefonu;
            }
            this.telefon_email_text.BackColor = Color.FromName("Window");

            this.zalacznik_text.Text = wnioskodawca.załącznik;
            this.zalacznik_text.BackColor = Color.FromName("Window");
        }

        private void fill_status(Wnioskodawca wnioskodawca)
        {
            switch (wnioskodawca.status)
            {
                case Status.ubezpieczona:
                    this.ubezpieczona_radio.Checked = true;
                    this.podstawa_uprawnien_combo.Enabled = false;
                    break;
                case Status.czlonek_rodziny:
                    this.rodzina_radio.Checked = true;
                    this.podstawa_uprawnien_combo.Enabled = false;
                    break;
                case Status.prawo_do_swiadczen:
                    this.prawo_do_swiadczen_radio.Checked = true;
                    this.podstawa_uprawnien_combo.Enabled = true;

                    switch (wnioskodawca.podstawa_uprawnień)
                    {
                        case PodstawaUprawnien.absolwent_szkoly_ponadgimnazjalnej_lub_wyzszej:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("absolwent szkoły ponadgimnazjalnej lub wyższej");
                            break;
                        case PodstawaUprawnien.decyzja_wojta:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("decyzja wójta");
                            break;
                        case PodstawaUprawnien.nieubezpieczona_kobieta_uchodzca:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("nieubezpieczona kobieta uchodźca");
                            break;
                        case PodstawaUprawnien.nieubezpieczona_kobieta_w_ciazy:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("nieubezpieczona kobieta w ciąży");
                            break;
                        case PodstawaUprawnien.nieubezpieczona_z_prawem_do_swiadczen:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("nieubezpieczona z prawem do świadczeń");
                            break;
                        case PodstawaUprawnien.nieubezpieczony_niepelnoletni_mieszkaniec:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("nieubezpieczony niepełnoletni mieszkaniec");
                            break;
                        case PodstawaUprawnien.nieubezpieczony_niepelnoletni_obywatel:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("nieubezpieczony niepełnoletni obywatel");
                            break;
                        case PodstawaUprawnien.ubiegajaca_sie_o_przyznanie_emerytury_lub_renty:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("ubiegająca się o przyznanie emerytury lub renty");
                            break;
                        case PodstawaUprawnien.zasilek_chorobowy_lub_wypadkowy:
                            this.podstawa_uprawnien_combo.SelectedIndex =
                                this.podstawa_uprawnien_combo.FindStringExact("zasiłek chorobowy lub wypadkowy");
                            break;
                    }
                    break;
            }
        }

        private void fill_odbior(Odbior odbior)
        {
            Adres odbior_adres = null;

            switch (odbior.sposob_odbioru)
            {
                case SposobOdbioru.osobiscie:
                    odbior_adres = odbior.oddzial.adres;
                    this.osobiscie_radio.Checked = true;
                    this.wojewodztwo_combo.Enabled = true;
                    this.telefon_kontaktowy_text.Enabled = true;
                    this.oddzial_text.Enabled = true;
                    this.oddzial_text.Text = odbior.oddzial.nazwa;
                    break;
                case SposobOdbioru.posrednictwo:
                    odbior_adres = odbior.oddzial.adres;
                    this.osoba_upowazniona_radio.Checked = true;
                    this.wojewodztwo_combo.Enabled = true;
                    this.telefon_kontaktowy_text.Enabled = true;
                    this.oddzial_text.Enabled = true;
                    this.oddzial_text.Text = odbior.oddzial.nazwa;
                    break;
                case SposobOdbioru.poczta:
                    odbior_adres = odbior.adres;
                    this.poczta_radio.Checked = true;
                    this.wojewodztwo_combo.Enabled = false;
                    this.telefon_kontaktowy_text.Enabled = false;
                    this.oddzial_text.Enabled = false;
                    break;
            }
            this.oddzial_text.BackColor = Color.FromName("Window");

            this.telefon_kontaktowy_text.Text = odbior_adres.telefon;
            this.telefon_kontaktowy_text.BackColor = Color.FromName("Window");

            this.ulica_text.Text = odbior_adres.ulica;
            this.ulica_text.BackColor = Color.FromName("Window");

            this.nr_domu_text.Text = odbior_adres.numer_domu;
            this.nr_domu_text.BackColor = Color.FromName("Window");

            this.nr_lokalu_text.Text = odbior_adres.numer_lokalu;
            this.nr_lokalu_text.BackColor = Color.FromName("Window");

            this.kod_pocztowy_text.Text = odbior_adres.kod_pocztowy;
            this.kod_pocztowy_text.BackColor = Color.FromName("Window");

            this.miejscowosc_text.Text = odbior_adres.miasto;
            this.miejscowosc_text.BackColor = Color.FromName("Window");

            this.panstwo_text.Text = odbior_adres.panstwo;
            this.panstwo_text.BackColor = Color.FromName("Window");

            switch (odbior_adres.wojewodztwo)
            {
                case Wojewodztwo.dolnoslaskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("dolnośląskie");
                    break;
                case Wojewodztwo.kujawsko_pomorskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("kujawsko-pomorskie");
                    break;
                case Wojewodztwo.lodzkie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("łódzkie");
                    break;
                case Wojewodztwo.lubelskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("lubelskie");
                    break;
                case Wojewodztwo.lubuskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("lubuskie");
                    break;
                case Wojewodztwo.malopolskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("małopolskie");
                    break;
                case Wojewodztwo.mazowieckie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("mazowieckie");
                    break;
                case Wojewodztwo.opolskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("opolskie");
                    break;
                case Wojewodztwo.podkarpackie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("podkarpackie");
                    break;
                case Wojewodztwo.podlaskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("podlaskie");
                    break;
                case Wojewodztwo.pomorskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("pomorskie");
                    break;
                case Wojewodztwo.slaskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("śląskie");
                    break;
                case Wojewodztwo.swietokrzyskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("świętokrzyskie");
                    break;
                case Wojewodztwo.warminsko_mazurskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("warmińsko-mazurskie");
                    break;
                case Wojewodztwo.wielkopolskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("wielkopolskie");
                    break;
                case Wojewodztwo.zachodniopomorskie:
                    this.wojewodztwo_combo.SelectedIndex = this.wojewodztwo_combo.FindStringExact("zachodniopomorskie");
                    break;
            }
        }

        private void fill_panstwa(PanstwoWyjazdu[] panstwa_wyjazdu)
        {
            if (panstwa_wyjazdu != null)
            {
                foreach (PanstwoWyjazdu kraj in panstwa_wyjazdu)
                {
                    ListViewItem item = new ListViewItem(new String[]{
                    kraj.kraj,
                    kraj.data_wyjazdu.ToShortDateString(),
                    kraj.data_powrotu.ToShortDateString(),
                    kraj.srodek_transportu.ToString(),
                    kraj.data_powrotu.Subtract(kraj.data_wyjazdu).TotalDays.ToString()+" dni"});

                    //this.kraje_list.Items.Add(item);
                }

                //adjust_columns();
            }
        }

        private void fill_form(Wniosek wniosek)
        {
            this.aktualna_data_picker.Value = wniosek.data_zlozenia;

            this.fill_wnioskodawca(wniosek.wnioskodawca);
            this.fill_status(wniosek.wnioskodawca);
            this.fill_odbior(wniosek.odbior);
            this.fill_panstwa(wniosek.panstwa_wyjazdu);
        }

        private void clear_form()
        {
            this.data_urodzenia_picker.Value = System.DateTime.Now;
            this.aktualna_data_picker.Value = System.DateTime.Now;
            //this.data_wyjazdu_picker.Value = System.DateTime.Now;
            //this.data_powrotu_picker.Value = System.DateTime.Now;

            this.pesel_text.Text = "";
            this.imie_text.Text = "";
            this.nazwisko_text.Text = "";
            this.telefon_email_text.Text = "";

            foreach (Control control in this.status_panel.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton button = (RadioButton)control;
                    button.Checked = false;
                }
            }

            this.podstawa_uprawnien_combo.Enabled = false;
            this.podstawa_uprawnien_combo.SelectedIndex = -1;

            foreach (Control control in this.odbior_panel.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton button = (RadioButton)control;
                    button.Checked = false;
                }
            }

            this.wojewodztwo_combo.Enabled = false;
            this.wojewodztwo_combo.SelectedIndex = -1;
            this.oddzial_text.Enabled = false;
            this.telefon_kontaktowy_text.Enabled = false;

            this.ulica_text.Text = "";
            this.nr_domu_text.Text = "";
            this.nr_lokalu_text.Text = "";
            this.telefon_kontaktowy_text.Text = "";
            this.kod_pocztowy_text.Text = "";
            this.miejscowosc_text.Text = "";
            this.panstwo_text.Text = "";
            this.oddzial_text.Text = "";
            this.telefon_kontaktowy_text.Text = "";
            //this.kraj_wyjazdu_text.Text = "";
            //this.transport_combo.SelectedIndex = -1;
            this.zalacznik_text.Text = "";

            //this.kraje_list.Items.Clear();

            foreach (String[] item in edited)
            {
                item[1] = "F";
            }
            foreach (String[] item in state)
            {
                item[1] = "F";
            }

            this.data_grid_view.Rows.Clear();
            this.data_grid_view.RowCount = 1;
            this.data_grid_view.Refresh();
        }


        private bool can_validate()
        {
            bool res = true;

            foreach (String[] item in edited)
            {
                if (item[1].Equals("F"))
                {
                    res = false;
                }
            }

            return res;
        }

        private bool can_save()
        {
            bool res = true;

            foreach (String[] item in state)
            {
                if (item[1].Equals("F"))
                {
                    res = false;
                }
            }

            return res;
        }


        private void choose_xml_button_Click(object sender, EventArgs e)
        {
            DialogResult result = open_file_dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                String file = open_file_dialog.FileName;

                clear_form();

                String file_result = XMLEditorManager.openXML(file);

                if (file_result == null)
                {
                    fill_form(XMLEditorManager.wniosek);

                    foreach (String[] item in edited)
                    {
                        item[1] = "T";
                    }

                    foreach (String[] item in state)
                    {
                        item[1] = "T";
                    }
                }
                else
                {
                    MessageBox.Show("Błąd pliku: nieprawidłowe dane:\n" + file_result, "Błąd", MessageBoxButtons.OK);
                }
            }
        }

        private void save_xml_button_Click(object sender, EventArgs e)
        {
            if (can_save() == true)
            {
                save_file_dialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                DialogResult result = save_file_dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string file = save_file_dialog.FileName;

                    XMLEditorManager.saveXML(file);
                }
            }
            else
            {
                String fields = null;

                foreach (String[] item in state)
                {
                    if (item[1].Equals("F"))
                    {
                        fields += "  " + item[0] + "\n";
                    }
                }

                MessageBox.Show("Nie można zapisać pliku. Niepoprawne pola:\n" + fields, "Error", MessageBoxButtons.OK);
            }
        }


        private void status_panel_CheckedChanged(object sender, EventArgs e)
        {
            String text = "";

            foreach (Control control in this.status_panel.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton button = (RadioButton)control;

                    if (button.Checked == true)
                    {
                        text = button.Text;
                    }
                }
            }

            if (text.Equals(this.ubezpieczona_radio.Text))
            {
                XMLEditorManager.wniosek.wnioskodawca.status = Status.ubezpieczona;
                XMLEditorManager.wniosek.wnioskodawca.is_status = true;

                this.podstawa_uprawnien_combo.Enabled = false;

                set_edited("status", "T");
            }
            else if (text.Equals(this.rodzina_radio.Text))
            {
                XMLEditorManager.wniosek.wnioskodawca.status = Status.czlonek_rodziny;
                XMLEditorManager.wniosek.wnioskodawca.is_status = true;

                this.podstawa_uprawnien_combo.Enabled = false;

                set_edited("status", "T");
            }
            else if (text.Equals(this.prawo_do_swiadczen_radio.Text))
            {
                XMLEditorManager.wniosek.wnioskodawca.status = Status.prawo_do_swiadczen;
                XMLEditorManager.wniosek.wnioskodawca.is_status = true;

                this.podstawa_uprawnien_combo.Enabled = true;

                set_edited("status", "T");
                set_edited("podstawa uprawnien", "F");
            }

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            if (XMLEditorManager.is_valid == null)
            {
                this.status_panel.BackColor = Color.FromName("Control");

                set_state("status", "T");

                if (komunikaty == true)
                {
                    MessageBox.Show("Status wnioskodawcy: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                this.status_panel.BackColor = Color.LightPink;
                set_state("status", "F");
                MessageBox.Show("Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid), "Błąd", MessageBoxButtons.OK);
            }
        }

        private void odbior_panel_CheckedChanged(object sender, EventArgs e)
        {
            String text = "";

            foreach (Control control in this.odbior_panel.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton button = (RadioButton)control;

                    if (button.Checked == true)
                    {
                        text = button.Text;
                    }
                }
            }

            if (text.Equals(this.osobiscie_radio.Text))
            {
                XMLEditorManager.wniosek.odbior.sposob_odbioru = SposobOdbioru.osobiscie;
                XMLEditorManager.wniosek.odbior.is_odbior = true;

                if (XMLEditorManager.wniosek.odbior.oddzial == null)
                {
                    XMLEditorManager.wniosek.odbior.oddzial = new Oddzial();
                }

                XMLEditorManager.wniosek.odbior.adres = null;

                this.oddzial_text.Enabled = true;
                this.wojewodztwo_combo.Enabled = true;
                this.telefon_kontaktowy_text.Enabled = true;

                set_edited("sposob odbioru", "T");
                set_edited("nazwa", "F");
                set_state("sposob odbioru", "T");
                set_state("nazwa", "F");
            }
            else if (text.Equals(this.osoba_upowazniona_radio.Text))
            {
                XMLEditorManager.wniosek.odbior.sposob_odbioru = SposobOdbioru.posrednictwo;
                XMLEditorManager.wniosek.odbior.is_odbior = true;

                if (XMLEditorManager.wniosek.odbior.oddzial == null)
                {
                    XMLEditorManager.wniosek.odbior.oddzial = new Oddzial();
                }

                XMLEditorManager.wniosek.odbior.adres = null;

                this.oddzial_text.Enabled = true;
                this.wojewodztwo_combo.Enabled = true;
                this.telefon_kontaktowy_text.Enabled = true;

                set_edited("sposob odbioru", "T");
                set_edited("nazwa", "F");
                set_state("sposob odbioru", "T");
                set_state("nazwa", "F");
            }
            else if (text.Equals(this.poczta_radio.Text))
            {
                XMLEditorManager.wniosek.odbior.sposob_odbioru = SposobOdbioru.poczta;
                XMLEditorManager.wniosek.odbior.is_odbior = true;
                XMLEditorManager.wniosek.odbior.oddzial = null;

                this.oddzial_text.Enabled = false;
                this.wojewodztwo_combo.Enabled = false;
                this.telefon_kontaktowy_text.Enabled = false;

                set_edited("sposob odbioru", "T");
                set_state("sposob odbioru", "T");
            }

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            if (XMLEditorManager.is_valid == null)
            {
                this.odbior_panel.BackColor = Color.FromName("Control");

                if (komunikaty == true)
                {
                    MessageBox.Show("Sposób odbioru: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                this.odbior_panel.BackColor = Color.LightPink;
                set_state("sposob odbioru", "F");
                set_state("nazwa", "T");
                MessageBox.Show("Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid), "Błąd", MessageBoxButtons.OK);
            }
        }

        private void set_address()
        {
            String text = null;

            foreach (Control control in this.odbior_panel.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton button = (RadioButton)control;

                    if (button.Checked == true)
                    {
                        text = button.Text;
                    }
                }
            }

            if (text == null)
            {
                foreach (Control control in this.odbior_panel.Controls)
                {
                    if (control.GetType() == typeof(RadioButton))
                    {
                        RadioButton button = (RadioButton)control;

                        if (button.Text.Equals(this.osobiscie_radio.Text))
                        {
                            button.Checked = true;
                        }
                    }
                }
            }
        }


        private void aktualna_data_picker_ValueChanged(object sender, EventArgs e)
        {
            XMLEditorManager.wniosek.data_zlozenia = this.aktualna_data_picker.Value;

            set_edited("aktualna data", "T");
            set_state("aktualna data", "T");

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            if (XMLEditorManager.is_valid == null)
            {
                this.aktualna_data_picker.BackColor = Color.FromName("Window");

                if (komunikaty == true)
                {
                    MessageBox.Show("Aktualna data: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                this.aktualna_data_picker.BackColor = Color.LightPink;
                set_state("aktualna data", "F");
                MessageBox.Show("Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid), "Błąd", MessageBoxButtons.OK);
            }
        }

        private void data_urodzenia_picker_ValueChanged(object sender, EventArgs e)
        {
            XMLEditorManager.wniosek.wnioskodawca.data_urodzenia = this.data_urodzenia_picker.Value;

            set_edited("data urodzenia", "T");
            set_state("data urodzenia", "T");

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            if (XMLEditorManager.is_valid == null)
            {
                this.data_urodzenia_picker.BackColor = Color.FromName("Window");

                if (komunikaty == true)
                {
                    MessageBox.Show("Data urodzenia: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                this.data_urodzenia_picker.BackColor = Color.LightPink;
                set_state("data urodzenia", "F");
                MessageBox.Show("Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid), "Błąd", MessageBoxButtons.OK);
            }
        }


        private void podstawa_uprawnien_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.podstawa_uprawnien_combo.SelectedText)
            {
                case "absolwent szkoły ponadgimnazjalnej lub wyższej":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.absolwent_szkoly_ponadgimnazjalnej_lub_wyzszej;
                    break;
                case "decyzja wójta":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.decyzja_wojta;
                    break;
                case "nieubezpieczona kobieta uchodźca":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.nieubezpieczona_kobieta_uchodzca;
                    break;
                case "nieubezpieczona kobieta w ciąży":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.nieubezpieczona_kobieta_w_ciazy;
                    break;
                case "nieubezpieczona z prawem do świadczeń":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.nieubezpieczona_z_prawem_do_swiadczen;
                    break;
                case "nieubezpieczony niepełnoletni mieszkaniec":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.nieubezpieczony_niepelnoletni_mieszkaniec;
                    break;
                case "nieubezpieczony niepełnoletni obywatel":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.nieubezpieczony_niepelnoletni_obywatel;
                    break;
                case "ubiegająca się o przyznanie emerytury lub renty":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.ubiegajaca_sie_o_przyznanie_emerytury_lub_renty;
                    break;
                case "zasiłek chorobowy lub wypadkowy":
                    XMLEditorManager.wniosek.wnioskodawca.podstawa_uprawnień = PodstawaUprawnien.zasilek_chorobowy_lub_wypadkowy;
                    break;
            }

            XMLEditorManager.wniosek.wnioskodawca.is_podstawa_uprawnien = true;

            set_edited("podstawa uprawnien", "T");

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            if (XMLEditorManager.is_valid == null)
            {
                if (komunikaty == true)
                {
                    MessageBox.Show("Podstawa uprawnień: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid), "Błąd", MessageBoxButtons.OK);
            }
        }

        private void wojewodztwo_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Wojewodztwo wojewodztwo = Wojewodztwo.wielkopolskie;

            switch (this.wojewodztwo_combo.SelectedText)
            {
                case "dolnośląskie":
                    wojewodztwo = Wojewodztwo.dolnoslaskie;
                    break;
                case "kujawsko-pomorskie":
                    wojewodztwo = Wojewodztwo.kujawsko_pomorskie;
                    break;
                case "łódzkie":
                    wojewodztwo = Wojewodztwo.lodzkie;
                    break;
                case "lubelskie":
                    wojewodztwo = Wojewodztwo.lubelskie;
                    break;
                case "lubuskie":
                    wojewodztwo = Wojewodztwo.lubuskie;
                    break;
                case "małopolskie":
                    wojewodztwo = Wojewodztwo.malopolskie;
                    break;
                case "mazowieckie":
                    wojewodztwo = Wojewodztwo.mazowieckie;
                    break;
                case "opolskie":
                    wojewodztwo = Wojewodztwo.opolskie;
                    break;
                case "podkarpackie":
                    wojewodztwo = Wojewodztwo.podkarpackie;
                    break;
                case "podlaskie":
                    wojewodztwo = Wojewodztwo.podlaskie;
                    break;
                case "pomorskie":
                    wojewodztwo = Wojewodztwo.pomorskie;
                    break;
                case "śląskie":
                    wojewodztwo = Wojewodztwo.slaskie;
                    break;
                case "świętokrzyskie":
                    wojewodztwo = Wojewodztwo.swietokrzyskie;
                    break;
                case "warmińsko-mazurskie":
                    wojewodztwo = Wojewodztwo.warminsko_mazurskie;
                    break;
                case "wielkopolskie":
                    wojewodztwo = Wojewodztwo.wielkopolskie;
                    break;
                case "zachodniopomorskie":
                    wojewodztwo = Wojewodztwo.zachodniopomorskie;
                    break;
            }

            if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
            {
                XMLEditorManager.wniosek.odbior.oddzial.adres.wojewodztwo = wojewodztwo;
                XMLEditorManager.wniosek.odbior.oddzial.adres.is_wojewodztwo = true;
            }
            else
            {
                XMLEditorManager.wniosek.odbior.adres.wojewodztwo = wojewodztwo;
                XMLEditorManager.wniosek.odbior.adres.is_wojewodztwo = true;
            }

            set_edited("wojewodztwo", "T");

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            if (XMLEditorManager.is_valid == null)
            {
                if (komunikaty == true)
                {
                    MessageBox.Show("Województwo: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid), "Błąd", MessageBoxButtons.OK);
            }
        }


        private void pesel_text_Leave(object sender, EventArgs e)
        {
            String result = null;

            set_edited("pesel", "T");

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_pesel(this.pesel_text.Text);

                if (XMLEditorManager.is_valid == null)
                {
                    this.pesel_text.BackColor = Color.FromName("Window");
                    XMLEditorManager.wniosek.wnioskodawca.pesel = this.pesel_text.Text;
                    set_state("pesel", "T");

                    if (komunikaty == true)
                    {
                        MessageBox.Show("PESEL: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.pesel_text.BackColor = Color.LightPink;
                set_edited("pesel", "F");
                set_state("pesel", "F");
                XMLEditorManager.wniosek.wnioskodawca.pesel = null;
            }
        }

        private void imie_text_Leave(object sender, EventArgs e)
        {
            String result = null;

            set_edited("imie", "T");

            String nazwa_wlasna = XMLEditorManager.nazwa_wlasna(this.imie_text.Text);

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_nazwa_wlasna(nazwa_wlasna, "imię");

                if (XMLEditorManager.is_valid == null)
                {
                    this.imie_text.BackColor = Color.FromName("Window");
                    XMLEditorManager.wniosek.wnioskodawca.imie = nazwa_wlasna;
                    this.imie_text.Text = nazwa_wlasna;
                    set_state("imie", "T");

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Imię: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.imie_text.BackColor = Color.LightPink;
                set_edited("imie", "F");
                set_state("imie", "F");
                XMLEditorManager.wniosek.wnioskodawca.imie = null;
            }
        }

        private void nazwisko_text_Leave(object sender, EventArgs e)
        {
            String result = null;

            set_edited("nazwisko", "T");

            String nazwa_wlasna = XMLEditorManager.nazwa_wlasna(this.nazwisko_text.Text);

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_nazwa_wlasna(nazwa_wlasna, "nazwisko");

                if (XMLEditorManager.is_valid == null)
                {
                    this.nazwisko_text.BackColor = Color.FromName("Window");
                    XMLEditorManager.wniosek.wnioskodawca.nazwisko = nazwa_wlasna;
                    this.nazwisko_text.Text = nazwa_wlasna;
                    set_state("nazwisko", "T");

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Nazwisko: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.nazwisko_text.BackColor = Color.LightPink;
                set_edited("nazwisko", "F");
                set_state("nazwisko", "F");
                XMLEditorManager.wniosek.wnioskodawca.nazwisko = null;
            }
        }

        private void telefon_email_text_Leave(object sender, EventArgs e)
        {
            String result = null;

            set_edited("telefon email", "T");

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            try
            {
                XMLEditorManager.validate_telefon(this.telefon_email_text.Text);

                if (XMLEditorManager.is_valid == null)
                {
                    this.telefon_email_text.BackColor = Color.FromName("Window");
                    XMLEditorManager.wniosek.wnioskodawca.nr_telefonu = this.telefon_email_text.Text;
                    set_state("telefon email", "T");

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Numer telefonu/email: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    XMLEditorManager.validate_email(this.telefon_email_text.Text);

                    if (XMLEditorManager.is_valid == null)
                    {
                        this.telefon_email_text.BackColor = Color.FromName("Window");
                        XMLEditorManager.wniosek.wnioskodawca.email = this.telefon_email_text.Text;
                        set_state("telefon email", "T");

                        if (komunikaty == true)
                        {
                            MessageBox.Show("Numer telefonu/email: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                    }
                }
                catch (Exception exe)
                {
                    this.telefon_email_text.BackColor = Color.LightPink;
                    set_edited("telefon email", "F");
                    set_state("telefon email", "F");
                    XMLEditorManager.wniosek.wnioskodawca.nr_telefonu = null;
                    XMLEditorManager.wniosek.wnioskodawca.email = null;
                }
            }
        }

        private void oddzial_text_Leave(object sender, EventArgs e)
        {
            String result = null;

            set_edited("nazwa", "T");

            String nazwa_wlasna = XMLEditorManager.nazwa_wlasna(this.oddzial_text.Text);

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_nazwa_wlasna(nazwa_wlasna, "oddział");

                if (XMLEditorManager.is_valid == null)
                {
                    this.oddzial_text.BackColor = Color.FromName("Window");
                    XMLEditorManager.wniosek.odbior.oddzial.nazwa = nazwa_wlasna;
                    this.oddzial_text.Text = nazwa_wlasna;
                    set_state("nazwa", "T");

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Oddział: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.oddzial_text.BackColor = Color.LightPink;
                set_edited("nazwa", "F");
                set_state("nazwa", "F");
                XMLEditorManager.wniosek.odbior.oddzial.nazwa = null;
            }
        }

        private void ulica_text_Leave(object sender, EventArgs e)
        {
            set_address();

            String result = null;

            set_edited("ulica", "T");

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                if (this.ulica_text.Text.Length < 1)
                {
                    throw new Exception("Błąd danych: nieprawidłowa nazwa ulicy.\nNazwa ulicy nie może być pusta.\n");
                }

                if (XMLEditorManager.is_valid == null)
                {
                    this.ulica_text.BackColor = Color.FromName("Window");
                    set_state("ulica", "T");

                    if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                    {
                        XMLEditorManager.wniosek.odbior.oddzial.adres.ulica = this.ulica_text.Text;
                    }
                    else
                    {
                        XMLEditorManager.wniosek.odbior.adres.ulica = this.ulica_text.Text;
                    }

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Ulica: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.ulica_text.BackColor = Color.LightPink;

                set_edited("ulica", "F");
                set_state("ulica", "F");
            }
        }

        private void nr_domu_text_Leave(object sender, EventArgs e)
        {
            set_address();

            String result = null;

            set_edited("numer domu", "T");

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_numer(this.nr_domu_text.Text);

                if (XMLEditorManager.is_valid == null)
                {
                    this.nr_domu_text.BackColor = Color.FromName("Window");
                    set_state("numer domu", "T");

                    if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                    {
                        XMLEditorManager.wniosek.odbior.oddzial.adres.numer_domu = this.nr_domu_text.Text;
                    }
                    else
                    {
                        XMLEditorManager.wniosek.odbior.adres.numer_domu = this.nr_domu_text.Text;
                    }

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Numer domu: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.nr_domu_text.BackColor = Color.LightPink;

                if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                {
                    XMLEditorManager.wniosek.odbior.oddzial.adres.numer_domu = null;
                }
                else
                {
                    XMLEditorManager.wniosek.odbior.adres.numer_domu = null;
                }

                set_edited("numer domu", "F");
                set_state("numer domu", "F");
            }
        }

        private void nr_lokalu_text_Leave(object sender, EventArgs e)
        {
            set_address();

            String result = null;

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_numer(this.nr_lokalu_text.Text, "lokal");

                if (XMLEditorManager.is_valid == null)
                {
                    this.nr_lokalu_text.BackColor = Color.FromName("Window");
                    set_state("numer lokalu", "T");

                    if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                    {
                        XMLEditorManager.wniosek.odbior.oddzial.adres.numer_lokalu = this.nr_lokalu_text.Text;
                    }
                    else
                    {
                        XMLEditorManager.wniosek.odbior.adres.numer_lokalu = this.nr_lokalu_text.Text;
                    }

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Numer lokalu: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.nr_lokalu_text.BackColor = Color.LightPink;
                set_state("numer lokalu", "F");

                if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                {
                    XMLEditorManager.wniosek.odbior.oddzial.adres.numer_lokalu = null;
                }
                else
                {
                    XMLEditorManager.wniosek.odbior.adres.numer_lokalu = null;
                }
            }
        }

        private void kod_pocztowy_text_Leave(object sender, EventArgs e)
        {
            set_address();

            set_edited("kod pocztowy", "T");

            String result = null;

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_kod_pocztowy(this.kod_pocztowy_text.Text);

                if (XMLEditorManager.is_valid == null)
                {
                    this.kod_pocztowy_text.BackColor = Color.FromName("Window");
                    set_state("kod pocztowy", "T");

                    if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                    {
                        XMLEditorManager.wniosek.odbior.oddzial.adres.kod_pocztowy = this.kod_pocztowy_text.Text;
                    }
                    else
                    {
                        XMLEditorManager.wniosek.odbior.adres.kod_pocztowy = this.kod_pocztowy_text.Text;
                    }

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Kod pocztowy: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.kod_pocztowy_text.BackColor = Color.LightPink;

                if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                {
                    XMLEditorManager.wniosek.odbior.oddzial.adres.kod_pocztowy = null;
                }
                else
                {
                    XMLEditorManager.wniosek.odbior.adres.kod_pocztowy = null;
                }

                set_edited("kod pocztowy", "F");
                set_state("kod pocztowy", "F");
            }
        }

        private void miejscowosc_text_Leave(object sender, EventArgs e)
        {
            set_address();

            set_edited("miasto", "T");

            String nazwa_wlasna = XMLEditorManager.nazwa_wlasna(this.miejscowosc_text.Text);
            String result = null;

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_nazwa_wlasna(nazwa_wlasna, "miejscowość");

                if (XMLEditorManager.is_valid == null)
                {
                    this.miejscowosc_text.BackColor = Color.FromName("Window");
                    set_state("miasto", "T");

                    if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                    {
                        XMLEditorManager.wniosek.odbior.oddzial.adres.miasto = nazwa_wlasna;
                    }
                    else
                    {
                        XMLEditorManager.wniosek.odbior.adres.miasto = nazwa_wlasna;
                    }

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Miejscowość: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.miejscowosc_text.BackColor = Color.LightPink;

                if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                {
                    XMLEditorManager.wniosek.odbior.oddzial.adres.miasto = null;
                }
                else
                {
                    XMLEditorManager.wniosek.odbior.adres.miasto = null;
                }

                set_edited("miasto", "F");
                set_state("miasto", "F");
            }
        }

        private void panstwo_text_Leave(object sender, EventArgs e)
        {
            set_address();

            set_edited("panstwo", "T");

            String nazwa_wlasna = XMLEditorManager.nazwa_wlasna(this.panstwo_text.Text);
            String result = null;

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_nazwa_wlasna(nazwa_wlasna, "państwo");

                if (XMLEditorManager.is_valid == null)
                {
                    this.panstwo_text.BackColor = Color.FromName("Window");
                    set_state("panstwo", "T");

                    if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                    {
                        XMLEditorManager.wniosek.odbior.oddzial.adres.panstwo = nazwa_wlasna;
                    }
                    else
                    {
                        XMLEditorManager.wniosek.odbior.adres.panstwo = nazwa_wlasna;
                    }

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Państwo: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.panstwo_text.BackColor = Color.LightPink;

                if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                {
                    XMLEditorManager.wniosek.odbior.oddzial.adres.panstwo = null;
                }
                else
                {
                    XMLEditorManager.wniosek.odbior.adres.panstwo = null;
                }

                set_edited("panstwo", "F");
                set_state("panstwo", "F");
            }
        }

        private void zalacznik_text_Leave(object sender, EventArgs e)
        {
            String result = null;

            if (can_validate() == true)
            {
                XMLEditorManager.validate().Close();
            }
            else
            {
                XMLEditorManager.is_valid = null;
            }

            if (XMLEditorManager.is_valid == null)
            {
                this.zalacznik_text.BackColor = Color.FromName("Window");
                XMLEditorManager.wniosek.wnioskodawca.załącznik = this.zalacznik_text.Text;
                set_state("zalacznik", "T");

                if (komunikaty == true)
                {
                    MessageBox.Show("Załącznik: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
            }

            if (result != null)
            {
                this.zalacznik_text.BackColor = Color.LightPink;
                set_state("zalacznik", "F");
                XMLEditorManager.wniosek.wnioskodawca.załącznik = null;
            }
        }

        private void telefon_kontaktowy_text_Leave(object sender, EventArgs e)
        {
            set_edited("telefon", "T");

            String result = null;

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_telefon(this.telefon_kontaktowy_text.Text);

                if (XMLEditorManager.is_valid == null)
                {
                    this.telefon_kontaktowy_text.BackColor = Color.FromName("Window");
                    set_state("telefon", "T");

                    if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                    {
                        XMLEditorManager.wniosek.odbior.oddzial.adres.telefon = this.telefon_kontaktowy_text.Text;
                    }
                    else
                    {
                        XMLEditorManager.wniosek.odbior.adres.telefon = this.telefon_kontaktowy_text.Text;
                    }

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Telefon kontaktowy: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                this.telefon_kontaktowy_text.BackColor = Color.LightPink;

                if (XMLEditorManager.wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
                {
                    XMLEditorManager.wniosek.odbior.oddzial.adres.telefon = null;
                }
                else
                {
                    XMLEditorManager.wniosek.odbior.adres.telefon = null;
                }

                set_edited("telefon", "F");
                set_state("telefon", "F");
            }
        }

        private String kraj_wyjazdu_validate(String kraj)
        {
            String nazwa_wlasna = XMLEditorManager.nazwa_wlasna(kraj);
            String result = null;

            try
            {
                if (can_validate() == true)
                {
                    XMLEditorManager.validate().Close();
                }
                else
                {
                    XMLEditorManager.is_valid = null;
                }

                XMLEditorManager.validate_nazwa_wlasna(nazwa_wlasna, "kraj wyjazdu");

                if (XMLEditorManager.is_valid == null)
                {
                    result = nazwa_wlasna;

                    if (komunikaty == true)
                    {
                        MessageBox.Show("Kraj wyjazdu: walidacja przebiegła pomyślnie.", "Info", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    result += "Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid);
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }


        /*private void dodaj_button_Click(object sender, EventArgs e)
        {
            if ((int)this.data_powrotu_picker.Value.Subtract(this.data_wyjazdu_picker.Value).TotalDays < 0)
            {
                MessageBox.Show("Data powrotu musi być późniejsza niż data wyjazdu", "Błąd", MessageBoxButtons.OK);

                this.data_wyjazdu_picker.Value = System.DateTime.Now;
                this.data_powrotu_picker.Value = System.DateTime.Now;
            }
            else
            {
                List<String> new_record_params = new List<String>();

                List<PanstwoWyjazdu> kraje;
                PanstwoWyjazdu kraj = new PanstwoWyjazdu();

                kraj.kraj = this.kraj_wyjazdu_text.Text;
                new_record_params.Add(kraj.kraj);

                kraj.data_wyjazdu = this.data_wyjazdu_picker.Value;
                new_record_params.Add(kraj.data_wyjazdu.ToShortDateString());

                kraj.data_powrotu = this.data_powrotu_picker.Value;
                new_record_params.Add(kraj.data_powrotu.ToShortDateString());

                switch ((String)this.transport_combo.SelectedItem)
                {
                    case "autokar":
                        kraj.srodek_transportu = SrodekTransportu.autokar;
                        break;
                    case "pieszo":
                        kraj.srodek_transportu = SrodekTransportu.pieszo;
                        break;
                    case "prom":
                        kraj.srodek_transportu = SrodekTransportu.prom;
                        break;
                    case "rower":
                        kraj.srodek_transportu = SrodekTransportu.rower;
                        break;
                    case "samochód":
                        kraj.srodek_transportu = SrodekTransportu.samochod;
                        break;
                    case "samolot":
                        kraj.srodek_transportu = SrodekTransportu.samolot;
                        break;
                }
                new_record_params.Add(kraj.srodek_transportu.ToString());

                double days = kraj.data_powrotu.Subtract(kraj.data_wyjazdu).TotalDays;
                new_record_params.Add(days.ToString() + " dni");

                ListViewItem item = new ListViewItem(new_record_params.ToArray());

                //this.kraje_list.Items.Add(item);

                //adjust_columns();

                if (XMLEditorManager.wniosek.panstwa_wyjazdu == null)
                {
                    kraje = new List<PanstwoWyjazdu>();
                }
                else
                {
                    kraje = XMLEditorManager.wniosek.panstwa_wyjazdu.ToList();
                }

                kraje.Add(kraj);

                XMLEditorManager.wniosek.panstwa_wyjazdu = kraje.ToArray();

                this.kraj_wyjazdu_text.Text = "";
                this.data_wyjazdu_picker.Value = System.DateTime.Now;
                this.data_powrotu_picker.Value = System.DateTime.Now;
                this.transport_combo.SelectedIndex = -1;
            }
        }*/

        private void komunikaty_check_CheckedChanged(object sender, EventArgs e)
        {
            komunikaty = komunikaty_check.Checked;
        }

        private void validate_button_Click(object sender, EventArgs e)
        {
            String result = XMLEditorManager.validate_wniosek(XMLEditorManager.wniosek);

            XMLEditorManager.validate().Close();

            if (result != null)
            {
                MessageBox.Show("Błąd danych: nieprawidłowe dane. Pole:\n" + result, "Błąd", MessageBoxButtons.OK);
            }
            else if (XMLEditorManager.is_valid != null)
            {
                MessageBox.Show("Błąd walidacji: błędne pole. Pole: " + XMLEditorManager.get_error_field(XMLEditorManager.is_valid), "Błąd", MessageBoxButtons.OK);
            }
        }


        private void data_grid_view_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            String column = this.data_grid_view.Columns[e.ColumnIndex].Name;

            if (column.Equals("data_wyjazdu") || column.Equals("data_powrotu"))
            {
                DateTime data_wyjazdu = (DateTime)this.data_grid_view.Rows[e.RowIndex].Cells["data_wyjazdu"].Value;
                DateTime data_powrotu = (DateTime)this.data_grid_view.Rows[e.RowIndex].Cells["data_powrotu"].Value;

                int days = (int)data_powrotu.Subtract(data_wyjazdu).TotalDays;

                if (days < 0)
                {
                    MessageBox.Show("Data powrotu musi być późniejsza niż data wyjazdu", "Błąd", MessageBoxButtons.OK);

                    this.data_grid_view.Rows[e.RowIndex].Cells["data_wyjazdu"].Style.BackColor = Color.LightPink;
                    this.data_grid_view.Rows[e.RowIndex].Cells["data_powrotu"].Style.BackColor = Color.LightPink;
                    this.data_grid_view.Rows[e.RowIndex].Cells["pobyt"].Value = "";
                }
                else
                {
                    this.data_grid_view.Rows[e.RowIndex].Cells["data_wyjazdu"].Style.BackColor = Color.FromName("Window");
                    this.data_grid_view.Rows[e.RowIndex].Cells["data_powrotu"].Style.BackColor = Color.FromName("Window");
                    this.data_grid_view.Rows[e.RowIndex].Cells["pobyt"].Value = days.ToString() + " dni";
                }
            }
            else if (column.Equals("kraj"))
            {
                String result = (String)this.data_grid_view.Rows[e.RowIndex].Cells["kraj"].Value;

                result = kraj_wyjazdu_validate(result);

                if (result.Contains("Błąd"))
                {
                    this.data_grid_view.Rows[e.RowIndex].Cells["kraj"].Style.BackColor = Color.LightPink;
                }
                else
                {
                    this.data_grid_view.Rows[e.RowIndex].Cells["kraj"].Style.BackColor = Color.FromName("Window");
                    this.data_grid_view.Rows[e.RowIndex].Cells["kraj"].Value = result;
                }
            }

        }
    }
}