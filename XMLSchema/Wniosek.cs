using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute("wniosek", Namespace="", IsNullable=false)]
public partial class Wniosek {
    private Wnioskodawca _wnioskodawca;
    private Odbior _odbior;
    private PanstwoWyjazdu[] _panstwa_wyjazdu;
    private DateTime _data_zlozenia;
    private bool _is_data_zlozenia;
    
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Wnioskodawca wnioskodawca {
        get {
            return this._wnioskodawca;
        }
        set {
            this._wnioskodawca = value;
        }
    }
    
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Odbior odbior {
        get {
            return this._odbior;
        }
        set {
            this._odbior = value;
        }
    }
        
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("panstwo_wyjazdu", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public PanstwoWyjazdu[] panstwa_wyjazdu {
        get {
            return this._panstwa_wyjazdu;
        }
        set {
            this._panstwa_wyjazdu = value;
        }
    }
        
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="date")]
    public System.DateTime data_zlozenia {
        get {
            return this._data_zlozenia;
        }
        set {
            this._data_zlozenia = value;
        }
    }
        
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool is_data_zlozenia {
        get {
            return this._is_data_zlozenia;
        }
        set {
            this._is_data_zlozenia = value;
        }
    }

    public Wniosek()
    {
        wnioskodawca = new Wnioskodawca();
        odbior = new Odbior();
    }
}
