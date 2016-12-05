using System.Xml.Serialization;
using System;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
public enum Status {   
    ubezpieczona,    
    
    [System.Xml.Serialization.XmlEnumAttribute("członek rodziny")]
    czlonek_rodziny,    
    
    [System.Xml.Serialization.XmlEnumAttribute("prawo do świadczeń")]
    prawo_do_swiadczen,
}