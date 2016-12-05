using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace XMLEditor
{
    class XMLEditorManager
    {
        public static String data_path = Directory.GetCurrentDirectory() + "\\data";
        public static Wniosek wniosek = new Wniosek();
        public static String is_valid = null;

        public static MemoryStream validate()
        {
            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true });
            XmlSerializer serializer = new XmlSerializer(typeof(Wniosek));

            serializer.Serialize(writer, wniosek);

            XmlReaderSettings reader_settings = new XmlReaderSettings();

            reader_settings.ValidationType = ValidationType.Schema;
            stream.Position = 0;

            XmlReader reader = XmlReader.Create(stream, reader_settings);
            XmlDocument document = new XmlDocument();

            document.Load(reader);
            document.Schemas.Add(null, data_path + "\\ekuz_schema.xsd");

            ValidationEventHandler handler = new ValidationEventHandler(validation_handler);

            is_valid = null;

            document.Validate(handler);

            return stream;
        }

        public static String get_error_field(String message)
        {
            if (message.Contains("invalid according to its datatype"))
            {
                return message.Split('\'')[1];
            }

            if (message.Contains("invalid child element"))
            {
                return message.Split('\'')[3] + " (" + message.Split('\'')[1] + ")";
            }

            return null;
        }

        public static String openXML(String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Wniosek));

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(stream);

                wniosek = new Wniosek();
                wniosek = (Wniosek)serializer.Deserialize(reader);
            }

            wniosek.wnioskodawca.is_status = true;

            if (wniosek.wnioskodawca.status == Status.prawo_do_swiadczen)
            {
                wniosek.wnioskodawca.is_uprawnienia = true;
            }

            wniosek.odbior.is_odbior = true;

            if (wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
            {
                wniosek.odbior.oddzial.adres.is_wojewodztwo = true;
                wniosek.odbior.adres = null;
            }


            String result = validate_wniosek(wniosek);

            validate().Close();

            if (result == null && is_valid != null)
            {
                return "  " + get_error_field(is_valid) + "\n";
            }
            else
            {
                return result;
            }
        }

        public static void saveXML(String path)
        {
            using (MemoryStream stream = validate())
            {
                String result = validate_wniosek(wniosek);

                if (is_valid == null && result == null)
                {
                    using (FileStream file = new FileStream(path, FileMode.Create))
                    {
                        stream.Position = 0;
                        stream.CopyTo(file);
                    }
                }
                else
                {
                    if (result != null)
                    {
                        MessageBox.Show("Błąd danych: nieprawidłowe dane. Pole:\n" + result, "Błąd", MessageBoxButtons.OK);
                    }
                    else if (is_valid != null)
                    {
                        MessageBox.Show("Błąd walidacji: błędne pole. Pole:" + get_error_field(is_valid), "Błąd", MessageBoxButtons.OK);
                    }
                }
            }
        }

        static void validation_handler(object sender, ValidationEventArgs e)
        {
            is_valid += e.Message;

            XmlSchemaValidationException ee = (XmlSchemaValidationException)e.Exception;
            XmlNode n = (XmlNode)ee.SourceObject;
        }

        public static String validate_wniosek(Wniosek wniosek)
        {
            String ret = null;

            try
            {
                XMLEditorManager.validate_pesel(wniosek.wnioskodawca.pesel);
            }
            catch (Exception e)
            {
                ret += "  pesel\n";
            }

            try
            {
                XMLEditorManager.validate_nazwa_wlasna(wniosek.wnioskodawca.imie);
            }
            catch (Exception e)
            {
                ret += "  imię\n";
            }

            try
            {
                XMLEditorManager.validate_nazwa_wlasna(wniosek.wnioskodawca.nazwisko);
            }
            catch (Exception e)
            {
                ret += "  nazwisko\n";
            }

            try
            {
                XMLEditorManager.validate_email(wniosek.wnioskodawca.email);
            }
            catch (Exception e)
            {
                try
                {
                    XMLEditorManager.validate_telefon(wniosek.wnioskodawca.nr_telefonu);

                    ret += "  adres email\n";
                }
                catch (Exception ex)
                {
                    ret += "  numer telefonu/adres email\n";
                }
            }

            if (wniosek.wnioskodawca.is_status == false)
            {
                ret += "  status\n";
            }
            else if (wniosek.wnioskodawca.status == Status.prawo_do_swiadczen && wniosek.wnioskodawca.is_uprawnienia == false)
            {
                ret += "  podstawa uprawnień\n";
            }

            Adres adres;

            if (wniosek.odbior.is_odbior == true && wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
            {
                adres = wniosek.odbior.oddzial.adres;
            }
            else
            {
                adres = wniosek.odbior.adres;
            }

            if (wniosek.odbior.is_odbior == false)
            {
                ret += "  sposób odbioru\n";
            }
            else if (wniosek.odbior.sposob_odbioru != SposobOdbioru.poczta)
            {
                if (adres.is_wojewodztwo == false)
                {
                    ret += "  województwo\n";
                }

                try
                {
                    XMLEditorManager.validate_nazwa_wlasna(wniosek.odbior.oddzial.nazwa);
                }
                catch (Exception e)
                {
                    ret += "  oddział\n";
                }
            }

            if (adres.ulica == null)
            {
                ret += "  ulica\n";
            }

            try
            {
                XMLEditorManager.validate_numer(adres.numer_domu);
            }
            catch (Exception e)
            {
                ret += "  numer domu\n";
            }

            try
            {
                XMLEditorManager.validate_numer(adres.numer_lokalu, "lokal");
            }
            catch (Exception e)
            {
                ret += "  numer lokalu\n";
            }

            try
            {
                XMLEditorManager.validate_kod_pocztowy(adres.kod_pocztowy);
            }
            catch (Exception e)
            {
                ret += "  kod pocztowy\n";
            }

            try
            {
                XMLEditorManager.validate_nazwa_wlasna(adres.miasto);
            }
            catch (Exception e)
            {
                ret += "  miasto\n";
            }

            try
            {
                XMLEditorManager.validate_nazwa_wlasna(adres.panstwo);
            }
            catch (Exception e)
            {
                ret += "  państwo\n";
            }

            if (adres.telefon != null && adres.telefon.Length > 0)
            {
                try
                {
                    XMLEditorManager.validate_telefon(adres.telefon);
                }
                catch (Exception e)
                {
                    ret += "  telefon kontakowy\n";
                }
            }

            return ret;
        }

        public static void validate_pesel(String pesel)
        {
            bool regex;
            String ret = null;

            if (pesel == null)
            {
                regex = false;
                ret = "";
            }
            else
            {
                regex = Regex.IsMatch(pesel, "\\d{11}");
            }

            if (regex == false)
            {
                if (pesel == null || pesel.Length != 11)
                {
                    ret += "Błąd danych: niewłaściwa długość numeru PESEL.\nNumer PESEL powinien zawierać dokładnie 11 cyfr.\n";
                }
                else
                {
                    ret += "Błąd danych: niewłaściwe znaki w numerze PESEL.\nNumer PESEL powinien zawierać tylko cyfry.\n";
                }
            }

            if (ret != null)
            {
                throw new Exception(ret);
            }
        }

        public static void validate_email(String email)
        {
            bool regex;
            String ret = null;

            if (email == null)
            {
                regex = false;
                ret = "";
            }
            else
            {
                regex = Regex.IsMatch(email, "[^@ ]+@[^\\.]+\\..+");
            }

            if (regex == false)
            {
                if (email == null || email.Length < 1)
                {
                    ret += "Błąd danych: nieprawidłowy adres email.\nAdres email nie może być pusty.\n";
                }
                else
                {
                    ret += "Błąd danych: nieprawidłowy adres email.\nAdres email powinien mieć formę *@*.* .\n";
                }
            }


            if (ret != null)
            {
                throw new Exception(ret);
            }
        }

        public static void validate_telefon(String telefon)
        {
            bool regex;
            String ret = null;

            if (telefon == null)
            {
                regex = false;
                ret = "";
            }
            else
            {
                regex = Regex.IsMatch(telefon, "\\(\\d{3}\\)\\d{9}");
            }

            if (regex == false)
            {
                if (telefon == null || telefon.Length < 1)
                {
                    ret += "Błąd danych: nieprawidłowy numer telefonu.\nNumer telefonu nie może być pusty.\n";
                }
                else
                {
                    ret = "Błąd danych: nieprawidłowy numer telefonu.\nNumer telefonu powinien mieć formę (000)000000000.\n";
                }
            }

            if (ret != null)
            {
                throw new Exception(ret);
            }
        }

        public static void validate_numer(String number, String place = "dom")
        {
            bool regex;
            String ret = null;

            if (number == null)
            {
                regex = false;
                ret = "";
            }
            else
            {
                regex = Regex.IsMatch(number, "\\d+[A-Za-z]?");
            }

            if (place.Equals("lokal") && number == null)
            {
                ret = null;
            }
            else if (regex == false)
            {
                if (number == null || number.Length < 1)
                {
                    ret += "Błąd danych: niewłaściwy numer " + place + "u.\nNumer " + place + "u nie może być pusty.\n";
                }
                else
                {
                    ret = "Błąd danych: niewłaściwy numer " + place + "u.\nNumer " + place + "u powinien być większy niż 0.\n";
                }
            }

            if (ret != null)
            {
                throw new Exception(ret);
            }
        }

        public static void validate_kod_pocztowy(String kod_pocztowy)
        {
            bool regex;
            String ret = null;

            if (kod_pocztowy == null)
            {
                regex = false;
                ret = "";
            }
            else
            {
                regex = Regex.IsMatch(kod_pocztowy, "\\d{2}-\\d{3}");
            }

            if (regex == false)
            {
                if (kod_pocztowy == null || kod_pocztowy.Length < 1)
                {
                    ret = "Błąd danych: nieprawidłowy kod pocztowy.\nKod pocztowy nie może być pusty.\n";
                }
                else
                {
                    ret = "Błąd danych: nieprawidłowy kod pocztowy.\nKod pocztowy powinien mieć formę 00-000.\n";
                }
            }

            if (ret != null)
            {
                throw new Exception(ret);
            }
        }

        public static void validate_nazwa_wlasna(String nazwa, String pole = "nazwa")
        {
            bool regex;
            String ret = null;

            if (nazwa == null)
            {
                regex = false;
                ret = "";
            }
            else
            {
                regex = Regex.IsMatch(nazwa, "([A-ZĄĆĘŁŃÓŚŻŹ][A-ZĄĆĘŁŃÓŚŻŹa-ząćęłńóśżź]+)|([A-ZĄĆĘŁŃÓŚŻŹ][a-ząćęłńóśżź]+-[A-ZĄĆĘŁŃÓŚŻŹ][a-ząćęłńóśżź]+)");
            }

            if (regex == false)
            {
                if (nazwa == null || nazwa.Length < 1)
                {
                    ret += "Błąd danych: niewłaściwa długość " + pole + ".\n" + pole + " nie może być puste.\n";
                }
                else
                {
                    ret += "Błąd danych: niewłaściwe znaki w " + pole + ".\n" + pole + " powinien zawierać tylko litery.\n";
                }
            }

            if (ret != null)
            {
                throw new Exception(ret);
            }
        }


        public static String nazwa_wlasna(String text)
        {
            String res = "";

            foreach (String part in text.Split(' '))
            {
                if (part != null && !part.Equals(""))
                {
                    res += part.Substring(0, 1).ToUpper() + part.Substring(1) + " ";
                }
            }

            res = res.Trim();

            return res;
        }
    }
}
