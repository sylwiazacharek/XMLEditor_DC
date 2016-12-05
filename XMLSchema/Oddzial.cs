using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class Oddzial {    
    private string _nazwa;    
    private Adres _adres;    
    
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string nazwa {
        get {
            return this._nazwa;
        }
        set {
            this._nazwa = value;
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

    public Oddzial()
    {
        adres = new Adres();
        nazwa = "";
    }
}
