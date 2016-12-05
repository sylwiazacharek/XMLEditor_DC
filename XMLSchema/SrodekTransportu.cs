using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
public enum SrodekTransportu {
    samolot,
    autokar,

    [System.Xml.Serialization.XmlEnumAttribute("samochód")]
    samochod,

    rower,   
    pieszo,
    prom,
}
