using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class Wnioskodawca {
    private string _pesel;    
    private DateTime _data_urodzenia;    
    private string _imie;    
    private string _nazwisko;    
    private string _nr_telefonu;    
    private string _email;    
    private Status _status;    
    private PodstawaUprawnien _podstawa_uprawnien;    
    private bool _is_podstawa_uprawnien;    
    private string _zalacznik;
    private bool _is_uprawnienia = false;
    private bool _is_status = false;
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string pesel {
        get {
            return this._pesel;
        }
        set {
            this._pesel = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
    public DateTime data_urodzenia {
        get {
            return this._data_urodzenia;
        }
        set {
            this._data_urodzenia = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string imie {
        get {
            return this._imie;
        }
        set {
            this._imie = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string nazwisko {
        get {
            return this._nazwisko;
        }
        set {
            this._nazwisko = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string nr_telefonu {
        get {
            return this._nr_telefonu;
        }
        set {
            this._nr_telefonu = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string email {
        get {
            return this._email;
        }
        set {
            this._email = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Status status {
        get {
            return this._status;
        }
        set {
            this._status = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public PodstawaUprawnien podstawa_uprawnień {
        get {
            return this._podstawa_uprawnien;
        }
        set {
            this._podstawa_uprawnien = value;
        }
    }
        
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool is_podstawa_uprawnien {
        get {
            return this._is_podstawa_uprawnien;
        }
        set {
            this._is_podstawa_uprawnien = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string załącznik {
        get {
            return this._zalacznik;
        }
        set {
            this._zalacznik = value;
        }
    }

    [System.Xml.Serialization.XmlIgnore()]
    public bool is_uprawnienia
    {
        get
        {
            return this._is_uprawnienia;
        }
        set
        {
            this._is_uprawnienia = value;
        }
    }

    [System.Xml.Serialization.XmlIgnore()]
    public bool is_status
    {
        get
        {
            return this._is_status;
        }
        set
        {
            this._is_status = value;
        }
    }
}
