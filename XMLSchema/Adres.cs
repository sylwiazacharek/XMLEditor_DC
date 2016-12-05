using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class Adres {    
    private string _panstwo;    
    private Wojewodztwo _wojewodztwo;    
    private string _miasto;    
    private string _kod_pocztowy;    
    private string _ulica;    
    private string _numer_domu;    
    private string _numer_lokalu;    
    private string _telefon;
    private bool _is_wojewodztwo = false;
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string panstwo {
        get {
            return this._panstwo;
        }
        set {
            this._panstwo = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Wojewodztwo wojewodztwo {
        get {
            return this._wojewodztwo;
        }
        set {
            this._wojewodztwo = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string miasto {
        get {
            return this._miasto;
        }
        set {
            this._miasto = value;
        }
    }
       
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string kod_pocztowy {
        get {
            return this._kod_pocztowy;
        }
        set {
            this._kod_pocztowy = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ulica {
        get {
            return this._ulica;
        }
        set {
            this._ulica = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="positiveInteger")]
    public string numer_domu {
        get {
            return this._numer_domu;
        }
        set {
            this._numer_domu = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="positiveInteger")]
    public string numer_lokalu {
        get {
            return this._numer_lokalu;
        }
        set {
            this._numer_lokalu = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string telefon {
        get {
            return this._telefon;
        }
        set {
            this._telefon = value;
        }
    }

    [System.Xml.Serialization.XmlIgnore()]
    public bool is_wojewodztwo
    {
        get
        {
            return this._is_wojewodztwo;
        }
        set
        {
            this._is_wojewodztwo = value;
        }
    }
}
