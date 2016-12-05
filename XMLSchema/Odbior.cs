using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class Odbior {    
    private SposobOdbioru _sposob_odbioru;    
    private Oddzial _oddzial;    
    private Adres _adres;   
    private bool _is_odbior = false;
    
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public SposobOdbioru sposob_odbioru {
        get {
            return this._sposob_odbioru;
        }
        set {
            this._sposob_odbioru = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Oddzial oddzial {
        get {
            return this._oddzial;
        }
        set {
            this._oddzial = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Adres adres {
        get {
            return this._adres;
        }
        set {
            this._adres = value;
        }
    }

    [System.Xml.Serialization.XmlIgnore()]
    public bool is_odbior
    {
        get
        {
            return this._is_odbior;
        }
        set
        {
            this._is_odbior = value;
        }
    }

    public Odbior()
    {
        adres = new Adres();
    }
}
