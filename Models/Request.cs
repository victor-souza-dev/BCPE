namespace ExtractCssValuesToJson.Models; 
public class Request {
    public List<IFormFile> Archives { get; set; }
    public List<FormatConfigCss> Configs { get; set; }
}


public class FormatConfigCss {
    public string ClassName { get; set; }
    public List<KeyValueCss> KeyValue { get; set; }
}

public class KeyValueCss {
    public string Property { get; set; }
    public string ResultName { get; set; }
}