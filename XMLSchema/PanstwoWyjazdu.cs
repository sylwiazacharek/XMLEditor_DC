using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PanstwoWyjazdu {    
    private string _kraj;    
    private DateTime _data_wyjazdu;    
    private DateTime _data_powrotu;    
    private SrodekTransportu _srodek_transportu;
    private bool _is_transport = false;
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string kraj {
        get {
            return this._kraj;
        }
        set {
            this._kraj = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
    public DateTime data_wyjazdu {
        get {
            return this._data_wyjazdu;
        }
        set {
            this._data_wyjazdu = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
    public DateTime data_powrotu {
        get {
            return this._data_powrotu;
        }
        set {
            this._data_powrotu = value;
        }
    }
        
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public SrodekTransportu srodek_transportu {
        get {
            return this._srodek_transportu;
        }
        set {
            this._srodek_transportu = value;
        }
    }

    [System.Xml.Serialization.XmlIgnore()]
    public bool is_transport
    {
        get
        {
            return this._is_transport;
        }
        set
        {
            this._is_transport = value;
        }
    }
}
